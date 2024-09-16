using Azure;
using RockClub.Infra.Persistence;
using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RockClub.Infra.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly RockClubDbContext _context;
        private readonly ILogger _logger;

        public ColaboradorRepository(RockClubDbContext context, ILogger<ColaboradorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<ResponseBase<ColaboradorModel>> AdicaoColaborador(ColaboradorModel colaborador)
        {
            // formatação de resposta
            var resposta = new ResponseBase<ColaboradorModel>();

            try
            {
                
                // adicionando colaborador ao db
                _context.Add(colaborador);

                // salvando no db
                await _context.SaveChangesAsync();

                // buscando novo colaborador no db
                var colaboradorEncontrado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Email == colaborador.Email);

                // adicionando respostas de sucesso 
                resposta.Dados = colaboradorEncontrado;
                resposta.Status = colaboradorEncontrado.Status;
                resposta.Mensagem = "Dados Adicionandos com Sucesso";

                // retornando o objeto de resposta
                return resposta;
            }
            catch (Exception erro)
            {
                resposta.Mensagem = "Erro interno na solicitação de cadastro de colaborador";
                _logger.LogError(erro.Message, "Ocorreu um erro ao cadastrar o colaborador {Nome}", colaborador.Nome);
                return resposta;
            }
        }

        public async Task<ResponseBase<ColaboradorModel>> BuscarColaborador(Guid id)
        {
            var resposta = new ResponseBase<ColaboradorModel>();

            try
            {
                var colaboradorEncontrado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == id);

                resposta.Dados = colaboradorEncontrado;
                resposta.Mensagem = "Dados de coloborador buscado com sucesso";
                return resposta;

            }
            catch (Exception erro)
            {
                resposta.Mensagem = "Erro interno na solicitação de cadastro de colaborador";
                _logger.LogError(erro.Message, "Ocorreu um erro ao buscar o colaborador de {id}", id);
                return resposta;
            }
        }

        public async Task<ResponseBase<List<ColaboradorModel>>> ListarColaboradores()
        {
            var resposta = new ResponseBase<List<ColaboradorModel>>();

            try
            {
                var listarColaboradores = await _context.Colaborador.ToListAsync();

                resposta.Dados = listarColaboradores;
                return resposta;

            }
            catch (Exception erro)
            {
                resposta.Mensagem = "Erro interno na solicitação de listagem de colaboradores";
                _logger.LogError(erro.Message, "Ocorreu um erro ao listar os colaboradores");
                return resposta;
            }
        }

        public async Task<ResponseBase<ColaboradorModel>> UpdateColaborador(ColaboradorModel colaborador)
        {
            // formatação de resposta
            var resposta = new ResponseBase<ColaboradorModel>();

            try
            {
                
                var colaboradorEncontrado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == colaborador.Id);

                // alterando tabela com dados adm por dados admAtualizado
                _context.Colaborador.Entry(colaboradorEncontrado).CurrentValues.SetValues(colaborador);

                // salvando no db
                await _context.SaveChangesAsync();

                // buscando novo colaborador no db
                var colaboradorAlterado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == colaborador.Id);

                // adicionando respostas de sucesso 
                resposta.Dados = colaboradorAlterado;
                resposta.Status = colaboradorAlterado.Status;
                resposta.Mensagem = "Dados Alterados com Sucesso";

                // retornando o objeto de resposta
                return resposta;
            }
            catch (Exception erro)
            {
                resposta.Mensagem = "Erro interno na solicitação de alteracao de dados do colaborador";
                _logger.LogError(erro.Message, "Ocorreu um erro ao alterar cadados o colaborador {Nome}", colaborador.Nome);
                return resposta;
            }
        }

        public async Task<ResponseMessage> DesabilitarColaborador(Guid id)
        {
            var resposta = new ResponseMessage();
            try
            {
                var colaboradorEncontrado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == id);

                
                // alteração do status da entidade                   
                colaboradorEncontrado.Status = false;

                // salvando os dados
                _context.SaveChanges();

                resposta.Message = "Cadastro do colaborador desativado com sucesso";
                return resposta;

            }
            catch (Exception erro)
            {
                resposta.Message = "Erro interno na solicitação de desabilitar cadastro do colaborador";
                _logger.LogError(erro.Message, "Ocorreu um erro ao desabilitar colaborador de {id}", id);
                return resposta;
            }
        }
        public async Task<bool> BuscarUserPorId(Guid id)
        {
            return await _context.Colaborador.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> VerificacaoCpf(string cpf)
        {
            return await _context.Colaborador.AnyAsync(x => x.Cpf == cpf);
        }

        public async Task<bool> VerificacaoEmail(string email)
        {
            return await _context.Colaborador.AnyAsync(x => x.Email == email);

        }

        public async Task<bool> VerificacaoTelefone(string telefone)
        {
            return await _context.Colaborador.AnyAsync(x => x.Telefone == telefone);

        }

        public async Task<string> VerificacaoDadosUnicos(Guid id, string email, string cpf, string telefone)
        {

            var resposta = "";


            var emailDuplicado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Email == email);

            if (emailDuplicado != null && emailDuplicado.Id != id)
            {
                resposta = "Email já cadastrado por outro colaborador";
                return resposta;
            }

            // cpf ja existe?
            var cpfDuplicado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Cpf == cpf);

            // o cpf existe e ele esta em um cadastro diferente
            if (cpfDuplicado != null && cpfDuplicado.Id != id)
            {
                resposta = "Cpf já cadastrado por outro colaborador";
                return resposta;
            }

            // telefone ja existe?
            var telefoneDuplicado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Telefone == telefone);

            // o cpf existe e ele esta em um cadastro diferente
            if (telefoneDuplicado != null && telefoneDuplicado.Id != id)
            {
                resposta = "Telefone já cadastrado por outro colaborador";
                return resposta;
            }

            resposta = "Dados não usados por outro usuario";
            return resposta;
        }

        public async Task<bool> StatusColaborador(Guid id)
        {
            var colaboradorEncontrado = await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == id);

            bool status = true;

            // validando se colaborador já esta ativado
            if (colaboradorEncontrado.Status == false)
            {
                status = false;
                return status;
            }

            return status;
        }
    }
}
