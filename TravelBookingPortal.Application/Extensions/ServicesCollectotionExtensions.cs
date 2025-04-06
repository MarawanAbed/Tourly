using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


using TravelBookingPortal.Domain.Repositories.ItineraryRepo;
//using TravelBookingPortal.Infrastructure.Repositories;
using TravelBookingPortal.Application.Payment.Command.Handler;
using TravelBookingPortal.Application.CityLogic.Queries.CityService.Abstraction;
using TravelBookingPortal.Application.CityLogic.Queries.CityService.Implementation;
using TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Abstraction;
using TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Implementation;


using TravelBookingPortal.Domain.IHubs;


namespace TravelBookingPortal.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServicesCollectionExtensions).Assembly;

            services.AddAutoMapper(applicationAssembly);

            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();

            







            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            services.AddHttpContextAccessor();
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

            //services.AddScoped<IItineraryRepository, ItineraryRepositoryImplementation>();

            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomServiceCommands, RoomServiceCommands>();
            services.AddHttpContextAccessor();


            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        }
    }
}
