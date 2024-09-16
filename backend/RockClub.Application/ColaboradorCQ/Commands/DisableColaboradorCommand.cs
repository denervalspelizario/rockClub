using MediatR;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Commands
{
    public class DisableColaboradorCommand : IRequest<ResponseMessage>
    {
        public Guid Id { get; set; }
    }
}
