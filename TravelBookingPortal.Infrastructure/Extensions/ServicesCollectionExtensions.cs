using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelBookingPortal.Domain.Enitites.User;
using TravelBookingPortal.Domain.Repositories.ItineraryRepo;
using TravelBookingPortal.Infrastructure.DbContext;
using TravelBookingPortal.Infrastructure.Repositories.Itinerary;
using TravelBookingPortal.Infrastructure.Seeder;
using TravelBookingPortal.Infrastructure.Seeder.Bookings;
using TravelBookingPortal.Infrastructure.Seeder.Cities;
using TravelBookingPortal.Infrastructure.Seeder.HotelsAndRooms;
using TravelBookingPortal.Infrastructure.Seeder.ItinerariesAndItems;
using TravelBookingPortal.Infrastructure.Seeder.Preferences;
using TravelBookingPortal.Infrastructure.Seeder.Reviews;
using TravelBookingPortal.Infrastructure.Seeder.Roles;
using TravelBookingPortal.Infrastructure.Seeder.Users;

namespace Restaurants.Infrastructure.Extensions
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

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<TravelBookingPortalDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IItineraryRepository, ItineraryRepositoryImplementation>();

            services.AddScoped<ITravelBookingSeeder, TravelBookingSeeder>();
            services.AddScoped<IRoleSeeder, RoleSeeder>();
            services.AddScoped<IUserSeeder, UserSeeder>();
            services.AddScoped<IHotelAndRoomSeeder, HotelAndRoomSeeder>();
            services.AddScoped<IPreferenceSeeder, PreferenceSeeder>();
            services.AddScoped<IBookingSeeder, BookingSeeder>();
            services.AddScoped<IItineraryAndItemsSeeder, ItineraryAndItemsSeeder>();
            services.AddScoped<IReviewSeeder, ReviewSeeder>();
            services.AddScoped<ICitySeeder, CitySeeder>();

            services.AddLogging();
            services.AddMemoryCache();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }


    }
}
