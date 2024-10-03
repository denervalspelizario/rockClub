using MediatR;
using RockClub.Shared.Dtos;
using RockClub.Shared.Enum;
using RockClub.Shared.Response;

namespace RockClub.Application.UsuarioCQ.Commands
{
    public class CreateUsuarioCommand : IRequest<ResponseBase<UsuarioResponseDTO>>
    {
        public string Email { get; set; }
        public string Usuario { get; set; }
        public CargoEnum Cargo { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public DateTime TokenDataCriacao { get; set; } = DateTime.Now;
    }
}
