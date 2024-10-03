

using RockClub.Shared.Enum;

namespace RockClub.Shared.Dtos
{
    public class UsuarioResponseDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public CargoEnum Cargo { get; set; }
        public DateTime TokenDataCriacao { get; set; }
    }
}
