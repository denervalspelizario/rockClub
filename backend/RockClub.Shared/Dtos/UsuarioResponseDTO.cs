

using RockClub.Shared.Enum;

namespace RockClub.Shared.Dtos
{
    public class UsuarioResponseDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Cargo { get; set; }

        public UsuarioResponseDTO(Guid id, string email, string usuario, string cargo)
        {
            Id = id;
            Email = email;
            Usuario = usuario;
            Cargo = cargo;
        }
    }
}
