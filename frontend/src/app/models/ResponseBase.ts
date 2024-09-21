
/*  no banco a resposta vem com as propriedades minusculas então aqui no angular coloque todas as response minusculo para evitar dor de cabeça */


export interface ResponseBase<T> {
  dados: T;
  mensagem?: string;
  status?: boolean;
}

