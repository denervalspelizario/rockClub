using MediatR;
using Microsoft.AspNetCore.Mvc;
using RockClub.Shared.Dtos;

namespace RockClub.API.Controllers
{
    [Route("rockclub/[controller]")]
    [ApiController]
    public class ColaboradorController(
        IMediator mediator,
        IConfiguration configuration) : ControllerBase
    {
        // injeções de dependencia
        private readonly IMediator _mediator = mediator;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost]
        [Route("adicionarColaborador/")]
        public async Task<IActionResult> AdicaoColaborador(ColaboradorCreateDTO colaborador )
        {
            var request = await _mediator.Send(colaborador);
            return Ok();
        }
    }
}
