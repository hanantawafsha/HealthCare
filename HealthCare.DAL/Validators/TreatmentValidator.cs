using FluentValidation;
using HealthCare.DAL.DTO.Requests;

namespace HealthCare.DAL.Validators
{
    internal class TreatmentValidator : AbstractValidator<TreatmentRequestDTO>
    {
        private readonly int _minLength = 5;
        private readonly int _maxLength = 100;
        public TreatmentValidator()
        {
            RuleFor(t => t.Description).NotEmpty()
                .Must(e => e.Length > _minLength && e.Length < _maxLength)
                .WithMessage("Please enter the description, it should be between {_minLength} and {_maxLength} characters");
        }
    }
}
