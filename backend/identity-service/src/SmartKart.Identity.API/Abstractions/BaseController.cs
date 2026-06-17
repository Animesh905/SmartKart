using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace SmartKart.Identity.API.Abstractions;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly ISender _sender;
    protected BaseController(
        ISender sender
        )
    {
       _sender = sender;
    }
}
