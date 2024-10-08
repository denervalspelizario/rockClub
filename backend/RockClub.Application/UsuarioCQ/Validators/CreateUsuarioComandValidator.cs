

using FluentValidation;
using RockClub.Application.UsuarioCQ.Commands;

namespace RockClub.Application.UsuarioCQ.Validators
{
    public class CreateUsuarioComandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioComandValidator()
        {
            RuleFor(x => x.Usuario).NotEmpty().WithMessage("O campo nome não pode ser vazio")
                .Length(1, 50).WithMessage("Tamanho do nome de usuário invalido")
                .Matches(@"^[A-Z][a-z]+$")
                .WithMessage("O campo deve conter apenas o primeiro nome, começando com letra maiúscula e contendo apenas letras.");
            
            RuleFor(x => x.Email).NotEmpty().WithMessage("O campo email não pode ser vazio")
                .EmailAddress().WithMessage("O campo de email não é valido");

            RuleFor(x => x.Cargo).NotEmpty().WithMessage("O campo cargo não pode ser vazio");

            RuleFor(x => x.Senha).NotEmpty().WithMessage("O campo senha é obrigatório.")
                .Length(6, 12).WithMessage("A senha deve ter entre 6 e 12 caracteres.")
                .Matches(@"^[A-Z][a-zA-Z0-9]{5,}$")
                .WithMessage("A senha deve começar com letra maiúscula e conter apenas letras e números.");

            RuleFor(x => x.ConfirmeSenha).NotEmpty().WithMessage("O campo confirme senha não pode ser vazio");

        }
    }
}
