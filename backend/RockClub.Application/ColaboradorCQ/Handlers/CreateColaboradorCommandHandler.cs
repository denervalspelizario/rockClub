using MediatR;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Handlers
{
    public class CreateColaboradorCommandHandler : IRequestHandler<CreateColaboradorCommand, ResponseBase<ColaboradorResponseDTO>>
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public CreateColaboradorCommandHandler(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<ResponseBase<ColaboradorResponseDTO>> Handle(CreateColaboradorCommand request, CancellationToken cancellationToken)
        {
            
            // formatação de resposta
            var resposta = new ResponseBase<ColaboradorResponseDTO>();

            // status dos colaboradores se iniciam como ativo
            var status = true;

            // data de cadastro do usuario
            DateTime dataAdmissao = DateTime.Today.Date;

            // data de nascimento para formato aceito no banco
            DateTime dataNascimento = DateTime.Parse(request.Data_nascimento!);


            // validações
            var emailExiste = await _colaboradorRepository.VerificacaoEmail(request.Email);
            var cpfExiste = await _colaboradorRepository.VerificacaoCpf(request.Cpf);
            var telefonelExiste = await _colaboradorRepository.VerificacaoTelefone(request.Telefone);

            if(emailExiste)
            {
                resposta.Mensagem = "Email já cadastrado";
                return resposta;
            }

            if(cpfExiste)
            {
                resposta.Mensagem = "Cpf já cadastrado";
                return resposta;
            }

            if(telefonelExiste)
            {
                resposta.Mensagem = "Telefone já cadastrado";
                return resposta;
            }



            var colaboradorEntity = new ColaboradorModel
            (
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

       
            // Adicionar o produto no repositório
            var respostaColaborador = await _colaboradorRepository.AdicaoColaborador(colaboradorEntity);


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
