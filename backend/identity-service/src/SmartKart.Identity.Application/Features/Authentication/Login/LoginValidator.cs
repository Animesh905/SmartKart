using FluentValidation;

namespace SmartKart.Identity.Application.Features.Authentication.Login;

public sealed class LoginValidator
: AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}
