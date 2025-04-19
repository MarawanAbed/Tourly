using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using TravelBookingPortal.Application.Payment.PaymentService;

namespace TravelBookingPortal.Infrastructure.Services.Payment
{
    public class PaymobService : IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public PaymobService(IConfiguration config, HttpClient httpClient)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));


            _httpClient.BaseAddress = new Uri("https://accept.paymob.com/api/");
        }

        public async Task<string> GeneratePaymentUrl(decimal amount, int bookingId)
        {


            var apiKey = _config["Paymob:ApiKey"] ?? throw new InvalidOperationException("Paymob:ApiKey is missing in configuration.");
            var integrationId = _config["Paymob:IntegrationId"] ?? throw new InvalidOperationException("Paymob:IntegrationId is missing in configuration.");
            var iframeId = _config["Paymob:IframeId"] ?? throw new InvalidOperationException("Paymob:IframeId is missing in configuration.");


            var authUrl = "auth/tokens";
            var authResponse = await _httpClient.PostAsJsonAsync(authUrl, new { api_key = apiKey });
            if (!authResponse.IsSuccessStatusCode)
            {
                var errorContent = await authResponse.Content.ReadAsStringAsync();
                throw new Exception($"Failed to authenticate with Paymob. Status: {authResponse.StatusCode}, Details: {errorContent}");
            }
            var authContent = await authResponse.Content.ReadFromJsonAsync<AuthResponse>();

            string token = authContent.token;


            var orderUrl = "ecommerce/orders";
            var orderRequest = new
            {
                auth_token = token,
                amount_cents = (int)(amount * 100),
                currency = "EGP",
                delivery_needed = false,
                merchant_order_id = bookingId.ToString() // Ensure uniqueness
            };
            var orderResponse = await _httpClient.PostAsJsonAsync(orderUrl, orderRequest);
            if (!orderResponse.IsSuccessStatusCode)
            {
                var errorContent = await orderResponse.Content.ReadAsStringAsync();
                throw new Exception($"Failed to create order. Status: {orderResponse.StatusCode}, Details: {errorContent}");
            }
            var orderContent = await orderResponse.Content.ReadFromJsonAsync<OrderResponse>();
            long orderId = orderContent.id;


            var paymentUrl = "acceptance/payment_keys";
            var paymentKeyRequest = new
            {
                auth_token = token,
                amount_cents = (int)(amount * 100),
                currency = "EGP",
                order_id = orderId,
                integration_id = integrationId,
                billing_data = new
                {
                    apartment = "NA",
                    email = "user@example.com",
                    floor = "NA",
                    first_name = "Test",
                    street = "123 Test St",
                    building = "NA",
                    phone_number = "+201000000000",
                    shipping_method = "PKG",
                    postal_code = "12345",
                    city = "Cairo",
                    country = "EG",
                    last_name = "User",
                    state = "Cairo"
                },
            };
            var paymentKeyResponse = await _httpClient.PostAsJsonAsync(paymentUrl, paymentKeyRequest);
            if (!paymentKeyResponse.IsSuccessStatusCode)
            {
                var errorContent = await paymentKeyResponse.Content.ReadAsStringAsync();
                throw new Exception($"Failed to get payment key. Status: {paymentKeyResponse.StatusCode}, Details: {errorContent}");
            }
            var paymentKeyContent = await paymentKeyResponse.Content.ReadFromJsonAsync<PaymentKeyResponse>();
            string paymentKey = paymentKeyContent.token;


            return $"https://accept.paymob.com/api/acceptance/iframes/{iframeId}?payment_token={paymentKey}";
        }

        private class AuthResponse
        {
            public string token { get; set; }
        }

        private class OrderResponse
        {
            public long id { get; set; }
        }

        private class PaymentKeyResponse
        {
            public string token { get; set; }
        }
    }
}