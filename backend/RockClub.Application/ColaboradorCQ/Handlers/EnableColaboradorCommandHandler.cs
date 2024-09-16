

using MediatR;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Handlers
{
    public class EnableColaboradorCommandHandler : IRequestHandler<EnableColaboradorCommand, ResponseMessage>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public EnableColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<ResponseMessage> Handle(EnableColaboradorCommand request, CancellationToken cancellationToken)
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
                // chamado metodo que desabilita cadastro
                var respostaColaborador = await _colaboradorRepository.HabilitarColaborador(request.Id);

                resposta.Message = respostaColaborador.Message;
                return resposta;
            }

            


            resposta.Message = "Cadastro Colaborador já esta habilitado";

            return resposta;
        }
    }
}
