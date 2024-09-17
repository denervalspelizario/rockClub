

using MediatR;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Shared.Dtos;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Handlers
{
    public class DeleteColaboradorCommandHandler : IRequestHandler<DeleteColaboradorCommand, ResponseMessage>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public DeleteColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<ResponseMessage> Handle(DeleteColaboradorCommand request, CancellationToken cancellationToken)
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


            // excluindo cadastro
            var respostaColaborador = await _colaboradorRepository.DeletarColaborador(request.Id);

            resposta.Message = respostaColaborador.Message;

            return resposta;
        }
    }
}
