using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockClub.API.Filters;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Application.UsuarioCQ.Commands;
using Swashbuckle.AspNetCore.Filters;

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
        [SwaggerRequestExample(typeof(CreateUsuarioCommand), typeof(UsuarioCreateSchema))]
        public async Task<ActionResult> Register(CreateUsuarioCommand usuario)
        {
            var request = await _mediator.Send(usuario);

            if (request.Mensagem == "Dados Adicionandos com Sucesso")
            {
                return Ok(request);
            }
            return BadRequest(request.Mensagem);
        }
    }
}
