using HealthCare.DAL.DTO.Responses;
using HealthCare.DAL.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare.BLL.MapsterConfigurations
{
    public static class MapsterConfig
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<Treatment, TreatmentResponseDTO>
                .NewConfig()
                .Map(d => d.Name, s => s.Name).TwoWays();
        }
    }
}
