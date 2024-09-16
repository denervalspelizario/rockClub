using RockClub.Application.ColaboradorCQ.Commands;
using Swashbuckle.AspNetCore.Filters;

namespace RockClub.API.Filters
{
    public class ColaboradorUpdateSchema : IExamplesProvider<UpdateColaboradorCommand>
    {
        public UpdateColaboradorCommand GetExamples()
        {
            return new UpdateColaboradorCommand
            {
                Id = Guid.Parse("d94a5fe2-7a1d-4c87-bb37-1e2c9e8c2e30"),
                Nome = "João Silva",
                Data_nascimento = "DD/MM/YYYY",
                Cpf = "12345678901",
                Endereco = "Rua Exemplo, 123, Centro, São Paulo",
                Sexo = Shared.Enum.SexoEnum.Masculino,
                Telefone = "(11)98765-4321",
                Email = "exemplo@dominio.com",
                Data_admissao = "DD/MM/YYYY",
                Cargo = Shared.Enum.CargoEnum.Gerente,
                Salario = 3000.50M,
                Departamento = Shared.Enum.DepartamentoEnum.Gerencia,
            };
        }
    }
}
