using FluentValidation;
using BWE.Domain.Model;

namespace BWE.Application.Validator
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name must not be empty");
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name must not be empty");
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email must not be empty");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password must not be empty");
        }
    }
}
