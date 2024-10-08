using MediatR;
using RockClub.Shared.Dtos;
using RockClub.Shared.Enum;
using RockClub.Shared.Response;
using System.ComponentModel.DataAnnotations;

namespace RockClub.Application.UsuarioCQ.Commands
{
    public class CreateUsuarioCommand : IRequest<ResponseBase<UsuarioResponseDTO>>
    {
        public string Email { get; set; }
        public string Usuario { get; set; }
        public CargoEnum Cargo { get; set; }
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmeSenha { get; set; }
    }
}
