using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TravelBookingPortal.Application.Payment.Command.Handler;
using TravelBookingPortal.Domain.IHubs;

namespace TravelBookingPortal.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServicesCollectionExtensions).Assembly;
            //services.AddScoped<IRestaurantsServices, RestaurantsServices>();
            services.AddAutoMapper(applicationAssembly);
            //like that we tell automapper to scan all the assemblies in the solution
            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();
            services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ConfirmBookingCommandHandler).Assembly));
            





            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        }
    }
}