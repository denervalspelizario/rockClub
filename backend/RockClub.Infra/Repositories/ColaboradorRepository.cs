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

        public bool VerificacaoCpf(string cpf)
        {
            return _context.Colaborador.Any(x => x.Cpf == cpf);
            
        }

        public bool VerificacaoEmail(string email)
        {
            return _context.Colaborador.Any(x => x.Email == email);

        }

        public bool VerificacaoTelefone(string telefone)
        {
            return _context.Colaborador.Any(x => x.Telefone == telefone);

        }
    }
}
