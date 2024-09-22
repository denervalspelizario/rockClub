import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseBase } from '../models/ResponseBase';
import { ColaboradorResponseDTO } from '../models/ColaboradorResponseDTO';
import { ColaboradorResponseListDTO } from '../models/ColaboradorResponseListDTO';
import { ColaboradorCreateDTO } from '../models/ColaboradorCreateDTO';

import { Observable } from 'rxjs';
import { ColaboradorUpdateDTO } from '../models/ColaboradorUpdateDTO';
import { ResponseMessage } from '../models/ResponseMessage';

@Injectable({
  providedIn: 'root'
})
export class ColaboradorService {

  // pegando a variavel da url de listagem de colaborador
  private apiUrl = `${environment.ApiUrl}/Colaborador/listagemColaboradores`

  // pegando a variavel da url de buscar de colaborador por id
  private apiUrlBuscarColaboradorPorId = `${environment.ApiUrl}/Colaborador/buscaColaborador`

  // pegando a variavel da url de adicao de colaborador
  private apiUrlAddColaborador = `${environment.ApiUrl}/Colaborador/adicionarColaborador`

  // pegando a variavel da url de adicao de colaborador
  private apiUrlUpdateColaborador = `${environment.ApiUrl}/Colaborador/atualizarColaborador`

  // pegando a variavel da url de adicao de colaborador
  private apiUrlDesabilitarColaborador = `${environment.ApiUrl}/Colaborador/desabilitarColaborador`

  // pegando a variavel da url de adicao de colaborador
  private apiUrlHabilitarColaborador = `${environment.ApiUrl}/Colaborador/habilitarColaborador`

  // pegando a variavel da url de adicao de colaborador
  private apiUrlDeletarColaborador = `${environment.ApiUrl}/Colaborador/deletarColaborador`

  // importanto o httpclint via injeção de dependencia
  constructor(private http: HttpClient) { }

  // metodo de listagem de colaboradores
  GetColaborador() : Observable<ResponseBase<ColaboradorResponseListDTO[]>> {
    return this.http.get<ResponseBase<ColaboradorResponseListDTO[]>>(this.apiUrl);
  }

  // método de busca de colaborador por id
  GetColaboradorId(id: string | null): Observable<ResponseBase<ColaboradorResponseDTO>> {
    return this.http.get<ResponseBase<ColaboradorResponseDTO>>(`${this.apiUrlBuscarColaboradorPorId}/${id}`);
  }


  // metodo de cadastro de colaborador
  AdicionarColaborador(colaborador: ColaboradorCreateDTO) :  Observable<ResponseBase<ColaboradorResponseDTO[]>>{
    return this.http.post<ResponseBase<ColaboradorResponseDTO[]>>(`${this.apiUrlAddColaborador}`, colaborador);
  }

  // metodo de cadastro de colaborador
  EditarColaborador(colaborador: ColaboradorUpdateDTO) :  Observable<ResponseBase<ColaboradorResponseDTO>>{
    return this.http.put<ResponseBase<ColaboradorResponseDTO>>(`${this.apiUrlUpdateColaborador}`, colaborador);
  }

  // método de habilitar colaborador
  HabilitarColaborador(id: string | null): Observable<ResponseMessage> {
    return this.http.patch<ResponseMessage>(`${this.apiUrlHabilitarColaborador}/${id}`, {});
  }


  // método de desabilitar colaborador
  DesabilitarColaborador(id: string | null): Observable<ResponseMessage> {
    return this.http.patch<ResponseMessage>(`${this.apiUrlDesabilitarColaborador}/${id}`, {});
  }


  // método de deletar colaborador
  DeletarColaborador(id: string | null): Observable<ResponseMessage> {
    return this.http.delete<ResponseMessage>(`${this.apiUrlDeletarColaborador}/${id}`, {});
  }


}
