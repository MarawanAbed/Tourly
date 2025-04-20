
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelBookingPortal.Application.Interfaces.Presistance;

namespace TravelBookingPortal.Application.Helper
{
    namespace TravelBookingPortal.Infrastructure.Helpers
    {
        public static class ServiceRegistrationHelper
        {
            public static void RegisterServices<T>(IServiceCollection services, IConfiguration configuration)
            {
                var serviceRegistrations = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                    .ToList();

                foreach (var registration in serviceRegistrations)
                {
                    var instance = (T)Activator.CreateInstance(registration);
                    if (instance is IPresistanceServicesExtensions presistanceService)
                    {
                        presistanceService.RegisterServices(services, configuration);
                    }
                }
            }
        }
    }
}
