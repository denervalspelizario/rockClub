using MediatR;
using Microsoft.AspNetCore.Mvc;
using RockClub.API.Filters;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Application.ColaboradorCQ.Queries;
using Swashbuckle.AspNetCore.Filters;

namespace RockClub.API.Controllers
{
    [Route("rockclub/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public ColaboradorController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("adicionarColaborador/")]
        [SwaggerRequestExample(typeof(CreateColaboradorCommand), typeof(ColaboradorCreateSchema))]
        public async Task<IActionResult> AdicaoColaborador(CreateColaboradorCommand colaborador)
        {
            var request = await _mediator.Send(colaborador);

            if (request.Mensagem == "Dados Adicionandos com Sucesso")
            {
                return Ok(request.Dados);
            }
            return BadRequest(request.Mensagem);
        }

        [HttpGet]
        [Route("listagemColaboradores/")]
        public async Task<IActionResult> ListagemColaboradores()
        {
            var request = await _mediator.Send(new GetAllColaboradoresQuery());

            if (request.Mensagem == "Requisição efetuado com sucesso")
            {
                return Ok(request.Dados);
            }
            return BadRequest(request.Mensagem);
        }

        
        [HttpGet]
        [Route("buscaColaborador/{id:guid}")]
        public async Task<IActionResult> buscaColaborador(Guid id)
        {
            
            var request = await _mediator.Send(new GetColaboradorQuery{ Id = id });

            if (request.Mensagem == "Dados de coloborador buscado com sucesso")
            {
                return Ok(request.Dados);
            }
            return BadRequest(request.Mensagem);
        }
    }
}

