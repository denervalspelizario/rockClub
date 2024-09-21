import { CargoEnum } from "./CargoEnum";
import { DepartamentoEnum } from "./DepartamentoEnum";
import { SexoEnum } from "./SexoEnum";


/*  no banco a resposta vem com as propriedades minusculas então aqui no angular coloque todas as response minusculo para evitar dor de cabeça */

export interface ColaboradorResponseDTO {
  id: string,
  nome: string,
  data_nascimento: string,
  cpf: string,
  endereco: string,
  sexo: SexoEnum,
  telefone: string,
  email: string,
  data_admissao: string,
  cargo: CargoEnum,
  salario: number,
  departamento: DepartamentoEnum
}




