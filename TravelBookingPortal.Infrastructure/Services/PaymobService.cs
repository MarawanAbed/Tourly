using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TravelBookingPortal.Application.Payment.PaymentService;

namespace TravelBookingPortal.Infrastructure.Services
{
    public class PaymobService : IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public PaymobService(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task<string> GeneratePaymentUrl(decimal amount, int bookingId)
        {
            var apiKey = _config["Paymob:ApiKey"]; // ضيفي دول في appsettings
            var authUrl = "https://accept.paymob.com/api/auth/tokens";

            var authResponse = await _httpClient.PostAsJsonAsync(authUrl, new { api_key = apiKey });
            var authContent = await authResponse.Content.ReadFromJsonAsync<AuthResponse>();

            string token = authContent.token;

            // بعدها بتكملي بإنشاء Order, PaymentKey, وLink بنفس الخطوات من توثيق Paymob

            return "https://accept.paymob.com/acceptance/iframe/xxxx?payment_token=yyy"; // النتيجة النهائية
        }

        private class AuthResponse
        {
            public string token { get; set; }
        }
    }

}
    


