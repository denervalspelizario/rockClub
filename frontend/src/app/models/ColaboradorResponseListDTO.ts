
/*  no banco a resposta vem com as propriedades minusculas então aqui no angular coloque todas as response minusculo para evitar dor de cabeça */

export interface ColaboradorResponseListDTO {
  id?: string,
  nome: string,
  cargo: string,
  departamento: string,
  status: boolean
}
