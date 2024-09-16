
using MediatR;
using RockClub.Shared.Response;

namespace RockClub.Application.ColaboradorCQ.Commands
{
    public class EnableColaboradorCommand : IRequest<ResponseMessage>
    {
        public Guid Id { get; set; }
    }
}
