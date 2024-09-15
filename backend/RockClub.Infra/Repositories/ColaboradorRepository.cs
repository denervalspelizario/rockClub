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

       
    }
}
