using MediatR;
using RockClub.Shared.Dtos;
using RockClub.Shared.Response;
using System.ComponentModel.DataAnnotations;

namespace RockClub.Application.ColaboradorCQ.Queries
{
    public class GetColaboradorQuery : IRequest<ResponseBase<ColaboradorResponseDTO>>
    {
        public Guid Id { get; set; }

    }
}
