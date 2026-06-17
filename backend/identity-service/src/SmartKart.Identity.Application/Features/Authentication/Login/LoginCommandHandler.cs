using SmartKart.Identity.Application.Abstractions.Messaging;

namespace SmartKart.Identity.Application.Features.Authentication.Login;

public sealed class LoginCommandHandler
: ICommandHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        return new LoginResponse
        {
            AccessToken = "token"
        };
    }
}