using FluentValidation;
using webApiWithDb.Models;

namespace webApiWithDb.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Firstname)
                .MinimumLength(2)
                .WithMessage("Firstname should be at least 2 characters.")
                .MaximumLength(51)
                .WithMessage("Firstname should not be more than 51 characters.");

            RuleFor(x => x.Lastname)
              .MinimumLength(2)
              .WithMessage("Lastname should be at least 2 characters.")
              .MaximumLength(51)
              .WithMessage("Lastname should not be more than 51 characters.");

            RuleFor(x => x.CreateDate)
              .LessThanOrEqualTo(System.DateTime.Now)
              .WithMessage("CreateDate can not be in future.");

            RuleFor(x => x.JobPosition)
             .MinimumLength(2)
             .WithMessage("Lastname should be at least 2 characters.")
             .MaximumLength(51)
             .WithMessage("Lastname should not be more than 51 characters.");

            RuleFor(x => x.Salary)
              .GreaterThanOrEqualTo(0)
              .WithMessage("Salary can't be less than 0.")
              .LessThanOrEqualTo(10000)
              .WithMessage("Salary can't be more than 10 000.");

            RuleFor(x => x.WorkExperince)
              .GreaterThanOrEqualTo(0)
              .WithMessage("Salary can't be less than 0.");

            RuleFor(x => x.AddressId)
              .GreaterThan(0)
              .WithMessage("Salary can't be less than 1.");
              

        }

    }
}
