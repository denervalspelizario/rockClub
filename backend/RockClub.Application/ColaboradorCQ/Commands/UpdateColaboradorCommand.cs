using MediatR;
using RockClub.Shared.Dtos;
using RockClub.Shared.Enum;
using RockClub.Shared.Response;
using System.ComponentModel.DataAnnotations;

namespace RockClub.Application.ColaboradorCQ.Commands
{
    public class UpdateColaboradorCommand : IRequest<ResponseBase<ColaboradorResponseDTO>>
    {
        
        public Guid Id { get; set; }
        [Display(Name = "Nome Completo")]
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Data de nascimento")]
        public string Data_nascimento { get; set; }
        [Required]
        [Display(Name = "Cpf")]
        public string Cpf { get; set; }
        [Required]
        [Display(Name = "Endereço completo")]
        public string Endereco { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public SexoEnum Sexo { get; set; }
        [Required]
        [Display(Name = "Celular")]
        public string Telefone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Data de nascimento")]
        public string Data_admissao { get; set; }
        [Required]
        [Display(Name = "Salário")]
        public decimal Salario { get; set; }
        [Required]
        [Display(Name = "Cargo")]
        public CargoEnum Cargo { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public DepartamentoEnum Departamento { get; set; }
    }
}
