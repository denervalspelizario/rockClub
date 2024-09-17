import { CargoEnum } from "./CargoEnum";
import { DepartamentoEnum } from "./DepartamentoEnum";
import { SexoEnum } from "./SexoEnum";


export interface ColaboradorResponseDTO {
  Id?: string,
  Nome: string,
  Data_nascimento: string,
  Cpf: string,
  Endereco: string,
  Sexo: SexoEnum,
  Telefone: string,
  Email: string,
  Data_admissao: string,
  Cargo: CargoEnum,
  Salario: number,
  Departamento: DepartamentoEnum
}




