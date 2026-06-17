using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartKart.Identity.API.Abstractions;
using SmartKart.Identity.Application.Features.Authentication.Login;
using System.Reflection;

namespace SmartKart.Identity.API.Controllers
{
    public sealed class AuthenticationController : BaseController
    {
        public AuthenticationController(
            ISender sender
            ) 
            : base(sender)
        {

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(
        [FromBody] LoginCommand command,
        CancellationToken cancellationToken)
        {
            var response = await _sender.Send(
                command,
                cancellationToken);

            return Ok(response);
        }
    }
}
