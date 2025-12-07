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

            TypeAdapterConfig<Appointment, AppointmentDTO>
                        .NewConfig()
                        .Map(dest => dest.PatientName, src => src.Patient != null ? src.Patient.FullName : "Unknown")
                        .Map(dest => dest.DoctorName, src => src.Doctor != null ? src.Doctor.FullName : "Unknown");
        }
    }
}

