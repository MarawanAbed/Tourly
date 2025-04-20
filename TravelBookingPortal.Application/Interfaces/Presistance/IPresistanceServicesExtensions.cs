
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TravelBookingPortal.Application.Interfaces.Presistance
{
    public interface IPresistanceServicesExtensions
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);

    }
}
