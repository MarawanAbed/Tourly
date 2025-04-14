

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Infrastructure.DbContext
{
    public class TravelBookingPortalDbContext(DbContextOptions<TravelBookingPortalDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Preference> UserPreferences { get; set; }
        public DbSet<ItineraryItem> ItineraryItems { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //the reason for adding this line cuz i dont want in hotel two rooms with the same number 
            builder.Entity<Room>()
                .HasIndex(r => new { r.HotelId, r.RoomNumber })
                .IsUnique();

            builder.Entity<ItineraryItem>()
                .HasKey(i=>i.ItemId);

            builder.Entity<Preference>()
                .HasKey(UserPreference => UserPreference.PreferenceId);
        }
    }
}
