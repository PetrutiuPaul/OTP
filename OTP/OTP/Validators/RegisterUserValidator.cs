using FluentValidation;
using OTP.Contracts.Requests;

namespace OTP.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().Matches("^[a-zA-Z0-9 ]*$"); ;
        }
    }
}
