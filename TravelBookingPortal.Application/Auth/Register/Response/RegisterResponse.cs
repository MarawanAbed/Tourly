
namespace TravelBookingPortal.Application.Auth.Register.Response
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }

        public string Id { get; set; }
        public string ErrorMessage { get; set; } // Add this property

    }
}
