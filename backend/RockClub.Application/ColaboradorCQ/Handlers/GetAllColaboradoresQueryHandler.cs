using MediatR;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Application.ColaboradorCQ.Queries;
using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Handlers
{
    public class GetAllColaboradoresQueryHandler : IRequestHandler<GetAllColaboradoresQuery, ResponseBase<List<ColaboradorResponseListDTO>>>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public GetAllColaboradoresQueryHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }


        public async Task<ResponseBase<List<ColaboradorResponseListDTO>>> Handle(GetAllColaboradoresQuery request, CancellationToken cancellationToken)
        {

            // formatação de resposta
            var resposta = new ResponseBase<List<ColaboradorResponseListDTO>>();


            // chamado metodo que lista do repositório
            var respostaListaColaborador = await _colaboradorRepository.ListarColaboradores();


            if (respostaListaColaborador == null || respostaListaColaborador.Dados.Count == 0)
            {
                resposta.Mensagem = "Nenhum colaborador cadastrado";
                return resposta;
            }

            // objeto com Lista de colaboradores tipo ColaboradorsResponseListDTO
            var listaColaboradoresResposta = new List<ColaboradorResponseListDTO>();



            // adicionando todos os colaboradores na lista de objetos resposta
            foreach (var colaborador in respostaListaColaborador.Dados)
            {
                
                    var colaboradorFormatado = new ColaboradorResponseListDTO
                    (
                        colaborador.Id,
                        colaborador.Nome,
                        colaborador.Email,
                        colaborador.Cargo.ToString(),
                        colaborador.Departamento.ToString(),
                        colaborador.Status
                        
                    );

                    listaColaboradoresResposta.Add(colaboradorFormatado);
                
            }

            // resposta estrutura
            resposta.Dados = listaColaboradoresResposta;
            resposta.Mensagem = "Requisição efetuado com sucesso";

            return resposta;
        }
    }
}
