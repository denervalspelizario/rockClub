

using RockClub.Shared.Entity;

namespace RockClub.Shared.Interfaces
{
    public interface ISenhaRepository
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);

        bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt);

        string CriarToken(UsuarioModel usuario);
    }
}
