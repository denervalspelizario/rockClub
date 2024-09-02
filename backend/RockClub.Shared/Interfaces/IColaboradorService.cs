using RockClub.Shared.Dtos;
using RockClub.Shared.Response;

namespace RockClub.Shared.Interfaces
{
    public interface IColaboradorService
    {
        Task<ResponseBase<ColaboradorResponseDTO>> AdicaoColaborador(ColaboradorCreateDTO colaborador);

    }
}
