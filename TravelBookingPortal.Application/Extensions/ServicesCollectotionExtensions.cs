using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TravelBookingPortal.Application.Payment.Command.Model;
using TravelBookingPortal.Application.RoomLogic.Commands.Handler;
using TravelBookingPortal.Application.RoomLogic.Commands.Models;
using TravelBookingPortal.Domain.IHubs;
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

            services.AddHttpContextAccessor();
            services.AddLogging();

            services.AddMemoryCache();
            services.AddTransient<IRequestHandler<ConfirmBookingAfterPaymentCommand, Unit>, ConfirmBookingAfterPaymentHandler>();
            
            



        }
    }
}
