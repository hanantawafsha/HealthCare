using FluentValidation;
using HealthCare.DAL.DTO.Requests;

namespace HealthCare.DAL.Validators
{
    public class AppointmentRequestValidator : AbstractValidator<AppointmentRequestDto>
    {
        public AppointmentRequestValidator()
        {

            RuleFor(a => a.StartTime)
                   .NotEmpty().WithMessage("Start time is required");

            RuleFor(a => a.EndTime)
                   .NotEmpty().WithMessage("End time is required")
                   .GreaterThan(a => a.StartTime).WithMessage("End time must be greater than start time");
        }
    }
}
