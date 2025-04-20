

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookingEntities = TravelBookingPortal.Domain.Entites.Booking.BookingEntities;
using HotelEntities = TravelBookingPortal.Domain.Entites.Hotel.HotelEntities;
using ReviewEntities = TravelBookingPortal.Domain.Entites.Review.ReviewEntities;
using RoomEntities = TravelBookingPortal.Domain.Entites.Room.RoomEntities;
using ItineraryEntities = TravelBookingPortal.Domain.Entites.Itinerary.ItineraryEntities;
using CityEntities = TravelBookingPortal.Domain.Entites.City.CityEntities;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Persistence.Persistence
{
    public class TravelBookingPortalDbContext(DbContextOptions<TravelBookingPortalDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<HotelEntities> Hotels { get; set; }
        public DbSet<BookingEntities> Bookings { get; set; }
        public DbSet<RoomEntities> Rooms { get; set; }
        public DbSet<ItineraryEntities> Itineraries { get; set; }
        public DbSet<ReviewEntities> Reviews { get; set; }
        public DbSet<CityEntities> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookingEntities>
                ().HasKey(b => b.BookingId);

            builder.Entity<CityEntities>().HasKey(c => c.CityId);
            builder.Entity<HotelEntities>().HasKey(h => h.HotelId);
            builder.Entity<RoomEntities>().HasKey(r => r.RoomId);
            builder.Entity<ItineraryEntities>().HasKey(i => i.ItineraryId);
            builder.Entity<ReviewEntities>().HasKey(r => r.ReviewId);


            builder.Entity<HotelEntities>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RoomEntities>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CityEntities>()
                .HasMany(c => c.Hotels)
                .WithOne(h => h.City)
                .HasForeignKey(h => h.CityId)
                .OnDelete(DeleteBehavior.Cascade);
            // Set BookingId to start from 2000
            builder.Entity<BookingEntities>()
                .Property(b => b.BookingId)
                .UseIdentityColumn(2000, 1);
        }
    }
}
