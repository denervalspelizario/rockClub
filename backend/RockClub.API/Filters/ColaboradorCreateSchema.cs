using RockClub.Application.ColaboradorCQ.Commands;
using Swashbuckle.AspNetCore.Filters;

namespace RockClub.API.Filters
{
    public class ColaboradorCreateSchema : IExamplesProvider<CreateColaboradorCommand>
    {
        public CreateColaboradorCommand GetExamples()
        {
            return new CreateColaboradorCommand
            {
                Nome = "João Silva",
                Data_nascimento = "DD/MM/YYYY",
                Cpf = "12345678901",
                Endereco = "Rua Exemplo, 123, Centro, São Paulo",
                Sexo = Shared.Enum.SexoEnum.Masculino,
                Telefone = "(11)98765-4321",
                Email = "exemplo@dominio.com",
                Cargo = Shared.Enum.CargoEnum.Gerente,
                Salario = 3000.50M,
                Departamento = Shared.Enum.DepartamentoEnum.Gerencia,
            };
        }
    }
}
