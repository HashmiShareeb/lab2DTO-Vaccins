using System.Data;

namespace lab2DTO.Validator
{
    public class VaccinValidator : AbstractValidator<VaccinRegistration>
    {
        public VaccinValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.EMail).NotEmpty().Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email is required");
            RuleFor(x => x.YearOfBirth).NotEmpty().GreaterThan(1900).LessThan(2023).WithMessage("VaccinType is required");
        }

    }
}
