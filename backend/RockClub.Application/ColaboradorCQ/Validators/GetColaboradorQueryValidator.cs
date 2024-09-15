using FluentValidation;
using RockClub.Application.ColaboradorCQ.Queries;

namespace RockClub.Application.ColaboradorCQ.Validators
{
    public class GetColaboradorQueryValidator : AbstractValidator<GetColaboradorQuery>
    {
        public GetColaboradorQueryValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O campo id não pode ser vazio");
        }
        
    }
}
