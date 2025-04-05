

using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.CityRepo;
using TravelBookingPortal.Infrastructure.DbContext;
using TravelBookingPortal.Infrastructure.Repositories.CityRepo;
using TravelBookingPortal.Domain.Repositories.Auth;
using TravelBookingPortal.Infrastructure.Repositories.Auth;
using TravelBookingPortal.Infrastructure.Seeder.Bookings;
using TravelBookingPortal.Infrastructure.Seeder.Cities;
using TravelBookingPortal.Infrastructure.Seeder.HotelsAndRooms;
using TravelBookingPortal.Infrastructure.Seeder.ItinerariesAndItems;
using TravelBookingPortal.Infrastructure.Seeder.Preferences;
using TravelBookingPortal.Infrastructure.Seeder.Reviews;
using TravelBookingPortal.Infrastructure.Seeder.Roles;
using TravelBookingPortal.Infrastructure.Seeder.Travel;
using TravelBookingPortal.Infrastructure.Seeder.Users;
using TravelBookingPortal.Domain.Repositories.RoomRepo;
using TravelBookingPortal.Infrastructure.Repositories.RoomRepo;

using TravelBookingPortal.Infrastructure.Hubs;
using TravelBookingPortal.Domain.IHubs;


namespace TravelBookingPortal.Infrastructure.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TravelBookingPortalDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<TravelBookingPortalDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                // Use JWT
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
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

            services.AddScoped<IGenerateToken, GenerateToken>();
            services.AddScoped<IRegisterRepoistory, RegisterRepositoryImplementation>();
            services.AddScoped<ILoginRepository, LoginRepositoryImplementation>();
            services.AddScoped<ILogoutRepoistory, LogoutRepositoryImplementation>();
            services.AddScoped<ITravelBookingSeeder, TravelBookingSeeder>();
            services.AddScoped<IRoleSeeder, RoleSeeder>();
            services.AddScoped<IUserSeeder, UserSeeder>();
            services.AddScoped<IHotelAndRoomSeeder, HotelAndRoomSeeder>();
            services.AddScoped<IPreferenceSeeder, PreferenceSeeder>();
            services.AddScoped<IBookingSeeder, BookingSeeder>();
            services.AddScoped<IItineraryAndItemsSeeder, ItineraryAndItemsSeeder>();
            services.AddScoped<IReviewSeeder, ReviewSeeder>();
            services.AddScoped<ICitySeeder, CitySeeder>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IBookingHub, BookingHub>();

            // Add SignalR 
            services.AddSignalR();


        }


    }
}
