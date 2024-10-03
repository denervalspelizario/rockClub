using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockClub.API.Controllers
{
    [Route("rockclub/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public LoginController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register()
        {
            //var resposta = await _authInterface.Registrar(usuarioCriacao);

            return Ok();
        }
    }
}
