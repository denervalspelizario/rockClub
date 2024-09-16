using RockClub.Shared.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockClub.Shared.Entity
{
    public class ColaboradorModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_nascimento { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public SexoEnum Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data_admissao { get; set; } = DateTime.Now.Date;
        public CargoEnum Cargo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Status { get; set; } = true;

        public ColaboradorModel() { }


        public ColaboradorModel( string nome, DateTime data_nascimento, string cpf, string endereco
          , SexoEnum sexo, string telefone, string email, DateTime data_admissao, CargoEnum cargo,
          decimal salario, DepartamentoEnum departamento, bool status)
        {
            Nome = nome;
            Data_nascimento = data_nascimento;
            Cpf = cpf;
            Endereco = endereco;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            Data_admissao = data_admissao;
            Cargo = cargo;
            Salario = salario;
            Departamento = departamento;
            Status = status;
        }

        public ColaboradorModel(Guid id,string nome, DateTime data_nascimento, string cpf, string endereco
          , SexoEnum sexo, string telefone, string email, DateTime data_admissao, CargoEnum cargo,
          decimal salario, DepartamentoEnum departamento, bool status)
        {
            Id = id;
            Nome = nome;
            Data_nascimento = data_nascimento;
            Cpf = cpf;
            Endereco = endereco;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            Data_admissao = data_admissao;
            Cargo = cargo;
            Salario = salario;
            Departamento = departamento;
            Status = status;
        }
    }
}
