using SmartKart.Identity.Application.Abstractions.Messaging;

namespace SmartKart.Identity.Application.Features.Authentication.Login;

public sealed record LoginCommand(
string Email,
string Password)
: ICommand<LoginResponse>;
