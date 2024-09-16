
namespace RockClub.Shared.Dtos
{
    public class ColaboradorResponseListDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }

        public ColaboradorResponseListDTO(Guid id, string nome, string email, string cargo, string departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cargo = cargo;
            Departamento = departamento;
        }
    }
}
