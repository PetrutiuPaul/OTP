using FluentValidation;
using OTP.Contracts.Requests;

namespace OTP.Validators
{
    public class GetUserOTPValidator : AbstractValidator<GetUserOTPRequest>
    {
        public GetUserOTPValidator()
        {
            RuleFor(x => x.Username)
                   .NotEmpty();

            RuleFor(x => x.UserTime)
                .NotEmpty();
        }
    }
}
