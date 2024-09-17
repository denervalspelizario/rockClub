export interface ResponseBase<T> {
  dados?: T;
  mensagem?: string;
  status?: boolean;
}

