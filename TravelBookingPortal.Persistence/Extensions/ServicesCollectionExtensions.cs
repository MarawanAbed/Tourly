


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
////////////////////////////////////////////////////
using TravelBookingPortal.Application.Interfaces.Presistance;
/////////////////////////////////////////////////////////////
using IAdminBooking = TravelBookingPortal.Application.Interfaces.Repositories.Admin.Booking.IBookingRepository;
using IAdminCity = TravelBookingPortal.Application.Interfaces.Repositories.Admin.City.ICityRepository;
using IAdminRoom = TravelBookingPortal.Application.Interfaces.Repositories.Admin.Room.IRoomRepository;
using IAdminUser = TravelBookingPortal.Application.Interfaces.Repositories.Admin.User.IUserRepository;
using IAdminHotel = TravelBookingPortal.Application.Interfaces.Repositories.Admin.Hotel.IHotelsRepository;

using TravelBookingPortal.Application.Interfaces.Repositories.Booking;
using TravelBookingPortal.Application.Interfaces.Repositories.City;
using TravelBookingPortal.Application.Interfaces.Repositories.Room;
using TravelBookingPortal.Application.Interfaces.Repositories.UserProfile;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;
using TravelBookingPortal.Application.Interfaces.Repositories.Review;

using TravelBookingPortal.Persistence.Persistence;
///////////////////////////////////////////////////////
using TravelBookingPortal.Persistence.Repositories.Booking;
using TravelBookingPortal.Persistence.Repositories.City;
using TravelBookingPortal.Persistence.Repositories.Itinerary;
using TravelBookingPortal.Persistence.Repositories.Review;
using TravelBookingPortal.Persistence.Repositories.Room;
using TravelBookingPortal.Persistence.Repositories.UserProfile;

using AdminBooking = TravelBookingPortal.Persistence.Repositories.Admin.Booking.BookingRepository;
using AdminCity = TravelBookingPortal.Persistence.Repositories.Admin.City.CityRepository;
using AdminHotel = TravelBookingPortal.Persistence.Repositories.Admin.Hotel.HotelRepository;
using AdminRoom = TravelBookingPortal.Persistence.Repositories.Admin.Room.RoomRepository;
using AdminUser = TravelBookingPortal.Persistence.Repositories.Admin.User.UserRepository;
//////////////////////////////////////////////////////////
using TravelBookingPortal.Persistence.Seeder.Bookings;
using TravelBookingPortal.Persistence.Seeder.Cities;
using TravelBookingPortal.Persistence.Seeder.HotelsAndRooms;
using TravelBookingPortal.Persistence.Seeder.ItinerariesAndItems;
using TravelBookingPortal.Persistence.Seeder.Reviews;
using TravelBookingPortal.Persistence.Seeder.Roles;
using TravelBookingPortal.Persistence.Seeder.Travel;
using TravelBookingPortal.Persistence.Seeder.Users;
//////////////////////////////////////////////////
using TravelBookingPortal.Domain.Entites.User;
using TravelBookingPortal.Application.Interfaces.Seeder.Bookings;
using TravelBookingPortal.Application.Interfaces.Seeder.Cities;
using TravelBookingPortal.Application.Interfaces.Seeder.HotelsAndRooms;
using TravelBookingPortal.Application.Interfaces.Seeder.ItinerariesAndItems;
using TravelBookingPortal.Application.Interfaces.Seeder.Reviews;
using TravelBookingPortal.Application.Interfaces.Seeder.Roles;
using TravelBookingPortal.Application.Interfaces.Seeder.Travel;
using TravelBookingPortal.Application.Interfaces.Seeder.Users;

namespace TravelBookingPortal.Persistence.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
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


            //repositories
            services.AddScoped<IItineraryRepository, ItineraryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IAdminBooking, AdminBooking>();
            services.AddScoped<IAdminCity, AdminCity>();
            services.AddScoped<IAdminHotel, AdminHotel>();
            services.AddScoped<IAdminRoom, AdminRoom>();
            services.AddScoped<IAdminUser, AdminUser>();



            //seeding
            services.AddScoped<ITravelBookingSeeder, TravelBookingSeeder>();
            services.AddScoped<IRoleSeeder, RoleSeeder>();
            services.AddScoped<IUserSeeder, UserSeeder>();
            services.AddScoped<IHotelAndRoomSeeder, HotelAndRoomSeeder>();
            services.AddScoped<IBookingSeeder, BookingSeeder>();
            services.AddScoped<IItineraryAndItemsSeeder, ItineraryAndItemsSeeder>();
            services.AddScoped<IReviewSeeder, ReviewSeeder>();
            services.AddScoped<ICitySeeder, CitySeeder>();
        }
    }
}
