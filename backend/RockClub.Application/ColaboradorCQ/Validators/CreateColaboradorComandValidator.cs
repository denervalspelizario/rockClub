using FluentValidation;
using RockClub.Application.ColaboradorCQ.Commands;


namespace RockClub.Application.ColaboradorCQ.Validators
{
    public class CreateColaboradorComandValidator : AbstractValidator<CreateColaboradorCommand>
    {
        public CreateColaboradorComandValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo nome não pode ser vazio")
                .Length(2, 50).WithMessage("Tamanho do nome e sobrenome inválidos.")
                .Matches(@"^[A-Z][a-z]+(\s[A-Z][a-z]+)+$").WithMessage("O campo deve conter nome e sobrenome, e cada palavra deve começar com letra maiúscula e conter apenas letras.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O campo email não pode ser vazio")
                .EmailAddress().WithMessage("O campo de email não é valido");

            RuleFor(x => x.Data_nascimento).NotEmpty().WithMessage("O campo Data Nascimento não pode ser vazio")
                .Matches(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/[0-9]{4}$").WithMessage("A data deve estar no formato dd/MM/yyyy.");

            RuleFor(x => x.Cpf).NotEmpty().WithMessage("O campo cpf não pode ser vazio")
               .Matches(@"^\d{11}$").WithMessage("O CPF deve conter exatamente 11 dígitos.");

            RuleFor(x => x.Endereco).NotEmpty().WithMessage("O campo Endereço não pode ser vazio");
               //.Length(200).WithMessage("O endereço não pode ter mais de 200 caracteres.");

            RuleFor(x => x.Telefone).NotEmpty().WithMessage("O campo telefone não pode ser vazio")
               .Matches(@"^\(\d{2}\)\d{4,5}-\d{4}$").WithMessage("O telefone deve estar no formato(XX)XXXXX - XXXX ou(XX)XXXX - XXXX.");

            RuleFor(x => x.Salario).NotEmpty().WithMessage("O campo salário não pode ser vazio");
            
            RuleFor(x => x.Cargo).NotEmpty().WithMessage("O campo cargo não pode ser vazio");
            
            RuleFor(x => x.Departamento).NotEmpty().WithMessage("O campo departamento não pode ser vazio");

            RuleFor(x => x.Sexo).NotEmpty().WithMessage("O campo sexo não pode ser vazio");

        }
    }
}
