using RockClub.Domain.Enum;
using System.ComponentModel.DataAnnotations;


namespace RockClub.Application.ColaboradorCQ.Dtos
{
    public class ColaboradorCreateDTO
    {
        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        public string? Data_nascimento { get; set; }

        [Display(Name = "Cpf")]
        public string? Cpf { get; set; }

        [Display(Name = "Endereço completo")]
        public string? Endereco { get; set; }

        [Display(Name = "Sexo")]
        public SexoEnum Sexo { get; set; }

        [Display(Name = "Celular")]
        public string? Telefone { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Salário")]
        public decimal Salario { get; set; }

        [Display(Name = "Cargo")]
        public string? Cargo { get; set; }

        [Display(Name = "Departamento")]
        public DepartamentoEnum Departamento { get; set; }
    }
}
