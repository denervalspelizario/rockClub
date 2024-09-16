
using MediatR;
using RockClub.Application.ColaboradorCQ.Queries;
using RockClub.Shared.Dtos;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Handlers
{
    
    public class GetColaboradorQueryHandler : IRequestHandler<GetColaboradorQuery, ResponseBase<ColaboradorResponseDTO>>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public GetColaboradorQueryHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<ResponseBase<ColaboradorResponseDTO>> Handle(GetColaboradorQuery request, CancellationToken cancellationToken)
        {

            // formatação de resposta
            var resposta = new ResponseBase<ColaboradorResponseDTO>();

            // validações
            var usuarioValido = await _colaboradorRepository.BuscarUserPorId(request.Id);

            if (usuarioValido is false)
            {
                resposta.Mensagem = "Colaborador não encontrado";
                return resposta;
            }

            // chamado metodo que lista do repositório
            var respostaColaborador = await _colaboradorRepository.BuscarColaborador(request.Id);

            // formatando dados do novo colaborador para resposta
            var colaboradorResposta = new ColaboradorResponseDTO(
                respostaColaborador.Dados.Id,
                respostaColaborador.Dados.Nome,
                respostaColaborador.Dados.Data_nascimento.ToString("dd-MM-yyyy"),
                respostaColaborador.Dados.Cpf,
                respostaColaborador.Dados.Endereco,
                respostaColaborador.Dados.Sexo.ToString(),
                respostaColaborador.Dados.Telefone,
                respostaColaborador.Dados.Email,
                respostaColaborador.Dados.Data_admissao.ToString("dd-MM-yyyy"),
                respostaColaborador.Dados.Cargo.ToString(),
                respostaColaborador.Dados.Salario,
                respostaColaborador.Dados.Departamento.ToString()
                );

            resposta.Dados = colaboradorResposta;
            resposta.Status = respostaColaborador.Dados.Status;
            resposta.Mensagem = respostaColaborador.Mensagem;

            return resposta;
        }
    }
    
}
