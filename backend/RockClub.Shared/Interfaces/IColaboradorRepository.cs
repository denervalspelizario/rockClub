using RockClub.Shared.Entity;
using RockClub.Shared.Response;

namespace RockClub.Shared.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<ResponseBase<ColaboradorModel>> AdicaoColaborador(ColaboradorModel colaborador);
        Task<ResponseBase<ColaboradorModel>> BuscarColaborador(Guid id);
        Task<ResponseBase<List<ColaboradorModel>>> ListarColaboradores();
        Task<ResponseBase<ColaboradorModel>> UpdateColaborador(ColaboradorModel colaborador);
        Task<bool> VerificacaoEmail(string email);
        Task<bool> VerificacaoCpf(string cpf);
        Task<bool> VerificacaoTelefone(string telefone);
        Task<string> VerificacaoDadosUnicos(Guid id, string email, string cpf, string telefone);
        Task<bool> BuscarUserPorId(Guid id);

    }
}
