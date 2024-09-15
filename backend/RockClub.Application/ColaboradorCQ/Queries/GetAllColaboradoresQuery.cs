
using MediatR;
using RockClub.Shared.Dtos;
using RockClub.Shared.Response;


namespace RockClub.Application.ColaboradorCQ.Queries
{
    public class GetAllColaboradoresQuery : IRequest<ResponseBase<List<ColaboradorResponseListDTO>>>
    {
    }
}
