using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TravelBookingPortal.Application.Admin.Booking.Mapper;


namespace TravelBookingPortal.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServicesCollectionExtensions).Assembly;

            services.AddAutoMapper(applicationAssembly);
            services.AddAutoMapper(x =>
            {
                x.AddProfile(new BookingProfile());
                
            });

            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            services.AddLogging();

            services.AddMemoryCache();  


        }
    }
}
