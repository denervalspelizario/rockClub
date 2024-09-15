using Azure;
using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Response;

namespace RockClub.Shared.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<ResponseBase<ColaboradorModel>> AdicaoColaborador(ColaboradorModel colaborador);
        Task<bool> VerificacaoEmail(string email);
        Task<bool> VerificacaoCpf(string email);
        Task<bool> VerificacaoTelefone(string email);
        Task<ResponseBase<ColaboradorModel>> BuscarColaborador(Guid id);
        Task<ResponseBase<List<ColaboradorModel>>> ListarColaboradores();


    }
}
