
namespace RockClub.Shared.Dtos
{
    public class ColaboradorResponseListDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public bool Status { get; set; }



        public ColaboradorResponseListDTO(Guid id, string nome, string email, string cargo, string departamento, bool status)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cargo = cargo;
            Departamento = departamento;
            Status = status;
        }
    }
}
