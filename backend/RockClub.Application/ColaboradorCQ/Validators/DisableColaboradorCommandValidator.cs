

using FluentValidation;
using RockClub.Application.ColaboradorCQ.Commands;

namespace RockClub.Application.ColaboradorCQ.Validators
{
    public class DisableColaboradorCommandValidator : AbstractValidator<DisableColaboradorCommand>
    {
        public DisableColaboradorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O campo id não pode ser vazio")
                .Must(id => Guid.TryParse(id.ToString(), out _))
                  .WithMessage("O campo id deve ser um GUID válido"); ;
        }
    }
}
