using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TravelBookingPortal.Application.CityLogic.Queries.CityService.Abstraction;
using TravelBookingPortal.Application.CityLogic.Queries.CityService.Implementation;
using TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Abstraction;
using TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Implementation;
using TravelBookingPortal.Application.RoomLogic.Queries.RoomService.Abstraction;
using TravelBookingPortal.Application.RoomLogic.Queries.RoomService.Implementation;
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
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomServiceCommands, RoomServiceCommands>();
            services.AddHttpContextAccessor();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
        }
    }
}