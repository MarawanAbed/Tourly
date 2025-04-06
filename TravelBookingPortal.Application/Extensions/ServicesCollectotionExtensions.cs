using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TravelBookingPortal.Domain.Repositories.ItineraryRepo;
//using TravelBookingPortal.Infrastructure.Repositories;

namespace Restaurants.Application.Extensions
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
        }
    }
}
