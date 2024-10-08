using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Response;

namespace RockClub.Shared.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<ResponseBase<UsuarioModel>> RegistrarUsuario(UsuarioModel usuarioRegistro);
        Task<bool> VerificacaoEmail(string usuario);
        Task<bool> VerificacaoUser(string usuario);
    }
}
