

using MediatR;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Application.ColaboradorCQ.Queries;
using RockClub.Shared.Dtos;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Handlers
{
    public class DisableColaboradorCommandHandler : IRequestHandler<DisableColaboradorCommand, ResponseMessage>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public DisableColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<ResponseMessage> Handle(DisableColaboradorCommand request, CancellationToken cancellationToken)
        {

            // formatação de resposta
            var resposta = new ResponseMessage();

            // validações
            var usuarioValido = await _colaboradorRepository.BuscarUserPorId(request.Id);

            if (usuarioValido is false)
            {
                resposta.Message = "Colaborador não encontrado";
                return resposta;
            }


            var statusValido = await _colaboradorRepository.StatusColaborador(request.Id);
            
            if (statusValido is false)
            {
                resposta.Message = "cadastro do colaborador já está inabilitado";
                return resposta;
            }

            // chamado metodo que desabilita cadastro
            var respostaColaborador = await _colaboradorRepository.DesabilitarColaborador(request.Id);

           
            resposta.Message = respostaColaborador.Message;

            return resposta;
        }
    }
}
