
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TravelBookingPortal.Infrastructure.Hubs;
using TravelBookingPortal.Infrastructure.Services.Payment;
using TravelBookingPortal.Application.Interfaces.Hubs;
using TravelBookingPortal.Application.Services.GenerateJwtToken;
using TravelBookingPortal.Application.Services.Register;
using TravelBookingPortal.Application.Services.ExternalAuth;
using TravelBookingPortal.Application.Services.Login;
using TravelBookingPortal.Application.Services.Logout;
using TravelBookingPortal.Application.Services.Payment;
using TravelBookingPortal.Application.Services.ContactUs;
using TravelBookingPortal.Infrastructure.Services.GenerateJwtToken;

using TravelBookingPortal.Infrastructure.Services.Email;
using TravelBookingPortal.Infrastructure.Services.Logout;
using TravelBookingPortal.Infrastructure.Services.Login;
using TravelBookingPortal.Infrastructure.Services.ExternalAuth;
using TravelBookingPortal.Infrastructure.Services.Register;




namespace TravelBookingPortal.Infrastructure.Extensions

{
    public static class ServicesCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                // Use JWT
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                })
                .AddGitHub(githubOptions =>
                {
                    githubOptions.ClientId = configuration["Authentication:GitHub:ClientId"];
                    githubOptions.ClientSecret = configuration["Authentication:GitHub:ClientSecret"];
                    githubOptions.Scope.Add("user:email"); // ?? this is the key!
                    githubOptions.SaveTokens = true;
                })
                .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;  // require https
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    // (exp)  ==> expiration
                    ValidateLifetime = true,

                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
            services.AddHttpClient();
            services.AddScoped<IGenerateJwtToken, GenerateJwtToken>(); 
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IExternalAuthService, ExternalAuthService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILogoutService, LogoutService>();

            services.AddHttpClient<IPaymentService, PaymobService>();
            services.AddScoped<IEmailService, EmailService>();


            services.AddScoped<IBookingStatusNotifier, BookingStatusNotifier>();
           
            // Add SignalR 
            services.AddSignalR();



        }


    }
}
