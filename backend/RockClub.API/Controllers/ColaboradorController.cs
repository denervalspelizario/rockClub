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
                return Ok(request);
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
                return Ok(request);
            }
            return BadRequest(request.Mensagem);
        }

        
        [HttpGet]
        [Route("buscaColaborador/{id:guid}")]
        public async Task<IActionResult> BuscaColaborador(Guid id)
        {
            var request = await _mediator.Send(new GetColaboradorQuery{ Id = id });

            if (request.Mensagem == "Dados de coloborador buscado com sucesso")
            {
                return Ok(request);
            }
            return BadRequest(request.Mensagem);
        }

        [HttpPut]
        [Route("atualizarColaborador/")]
        [SwaggerRequestExample(typeof(UpdateColaboradorCommand), typeof(ColaboradorUpdateSchema))]
        public async Task<IActionResult> AtualizarColaborador(UpdateColaboradorCommand colaborador)
        {
            var request = await _mediator.Send(colaborador);

            if (request.Mensagem == "Dados Alterados com Sucesso")
            {
                return Ok(request);
            }
            return BadRequest(request.Mensagem);
        }

        [HttpPatch]
        [Route("desabilitarColaborador/{id:guid}")]
        public async Task<IActionResult> DesabilitarColaborador(Guid id)
        {
            var request = await _mediator.Send(new DisableColaboradorCommand { Id = id});

            if(request.Message == "Cadastro do colaborador desativado com sucesso")
            {
                return Ok(request);
            }
            return BadRequest(request.Message);
        }

        [HttpPatch]
        [Route("habilitarColaborador/{id:guid}")]
        public async Task<IActionResult> HabilitarColaborador(Guid id)
        {
            var request = await _mediator.Send(new EnableColaboradorCommand { Id = id });

            if (request.Message == "Cadastro do colaborador habilitado com sucesso")
            {
                return Ok(request);
            }
            return BadRequest(request.Message);
        }

    }
}

