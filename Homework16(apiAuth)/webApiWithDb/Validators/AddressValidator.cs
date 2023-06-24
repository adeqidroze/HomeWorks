using FluentValidation;
using webApiWithDb.Models;

namespace webApiWithDb.Validators
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.City)
               .MinimumLength(1)
               .WithMessage("City name should be longer than 1 character.")
               .NotEmpty()
               .WithMessage("City name can't be null");
             

            RuleFor(x => x.Country)
              .MinimumLength(1)
              .WithMessage("Lastname should be longer than 1 character.")
              .NotEmpty()
              .WithMessage("Country name can't be null");
   

            RuleFor(x => x.HomeNumber)
             .MinimumLength(1)
             .WithMessage("Lastname should be longer than 1 character.")
             .NotEmpty()
             .WithMessage("HomeNumber can't be null");
        }
    
    }
}
