using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Response;

namespace RockClub.Shared.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<ResponseBase<ColaboradorModel>> AdicaoColaborador(ColaboradorModel colaborador);
        public bool VerificacaoEmail(string email);
        public bool VerificacaoCpf(string email);
        public bool VerificacaoTelefone(string email);


    }
}
