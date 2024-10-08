using Swashbuckle.AspNetCore.Filters;
using RockClub.Application.UsuarioCQ.Commands;


namespace RockClub.API.Filters
{
    public class UsuarioCreateSchema : IExamplesProvider<CreateUsuarioCommand>
    {
        public CreateUsuarioCommand GetExamples()
        {
            return new CreateUsuarioCommand
            {
                Email = "usuario@email.com",
                Usuario = "usuario123",
                Cargo = Shared.Enum.CargoEnum.Gerente,
                Senha = "Senha123",
                ConfirmeSenha = "Senha123"  
            };
        }
    }
}
