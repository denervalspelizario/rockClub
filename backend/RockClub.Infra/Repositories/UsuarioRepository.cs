

using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RockClub.Infra.Persistence;
using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Infra.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly RockClubDbContext _context;
        private readonly ILogger _logger;

        public UsuarioRepository(RockClubDbContext context, ILogger<UsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<ResponseBase<UsuarioModel>> RegistrarUsuario(UsuarioModel usuarioRegistro)
        {
			var respostaFormatada = new ResponseBase<UsuarioModel>();
			try
			{
                // adicionando os dados do usuario no banco
                _context.Add(usuarioRegistro);

                // salvando no banco
                await _context.SaveChangesAsync();

                // buscando novo usuario no db
                var usuarioEncontrado = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == usuarioRegistro.Email);

                // adicionando respostas de sucesso 
                respostaFormatada.Dados = usuarioEncontrado;
                respostaFormatada.Status = usuarioEncontrado.Status;
                respostaFormatada.Mensagem = "Dados Adicionandos com Sucesso";

               
                return respostaFormatada;
			}
			catch (Exception erro)
			{
                respostaFormatada.Mensagem = "Erro interno na solicitação de cadastro de usuário";
                _logger.LogError(erro.Message, "Ocorreu um erro ao cadastrar o colaborador {Nome}", usuarioRegistro.Usuario);
                return respostaFormatada;
            }
        }

        public async Task<bool> VerificacaoEmail(string email)
        {
            return await _context.Usuario.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> VerificacaoUser(string usuario)
        {
            return await _context.Usuario.AnyAsync(x => x.Usuario == usuario);
        }
    }
}
