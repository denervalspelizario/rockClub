
namespace RockClub.Shared.Dtos
{
    public class ColaboradorResponseListDTO
    {
        public Guid Colaborador_id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }

        public ColaboradorResponseListDTO(Guid colaborador_id, string nome, string email, string cargo, string departamento)
        {
            Colaborador_id = colaborador_id;
            Nome = nome;
            Email = email;
            Cargo = cargo;
            Departamento = departamento;
        }
    }
}
