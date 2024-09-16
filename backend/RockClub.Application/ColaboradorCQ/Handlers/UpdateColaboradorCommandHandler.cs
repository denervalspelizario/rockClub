

using MediatR;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Handlers
{
    public class UpdateColaboradorCommandHandler : IRequestHandler<UpdateColaboradorCommand, ResponseBase<ColaboradorResponseDTO>>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public UpdateColaboradorCommandHandler(IColaboradorRepository colaborador) 
        {
            _colaboradorRepository = colaborador;
        }

        public async Task<ResponseBase<ColaboradorResponseDTO>> Handle(UpdateColaboradorCommand request, CancellationToken cancellationToken)
        {
            // formatação de resposta
            var resposta = new ResponseBase<ColaboradorResponseDTO>();

            // status dos colaboradores se iniciam como ativo
            var status = true;

            // data de cadastro do usuario
            DateTime dataAdmissao = DateTime.Parse(request.Data_admissao!);

            // data de nascimento para formato aceito no banco
            DateTime dataNascimento = DateTime.Parse(request.Data_nascimento!);


            // validações
            var usuarioValido = await _colaboradorRepository.BuscarUserPorId(request.Id);

            if (usuarioValido is false)
            {
                resposta.Mensagem = "Colaborador não encontrado";
                return resposta;
            }


            var validacaoDadosUnicos = await _colaboradorRepository.VerificacaoDadosUnicos(
                request.Id,request.Email,request.Cpf, request.Telefone);
            
            if(validacaoDadosUnicos != "Dados não usados por outro usuario")
            {
                resposta.Mensagem = validacaoDadosUnicos;
                return resposta;
            }


            var colaboradorEntity = new ColaboradorModel
            (
                request.Id,
                request.Nome,
                dataNascimento,
                request.Cpf,
                request.Endereco,
                request.Sexo,
                request.Telefone,
                request.Email,
                dataAdmissao,
                request.Cargo,
                request.Salario,
                request.Departamento,
                status
            );

            Console.WriteLine($"\n dado colaboradorEntity {colaboradorEntity.Email} \n");

            // Adicionar o produto no repositório
            var respostaColaborador = await _colaboradorRepository.UpdateColaborador(colaboradorEntity);


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
