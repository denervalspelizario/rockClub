import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { ResponseBase } from '../models/ResponseBase';
import { ColaboradorResponseDTO } from '../models/ColaboradorResponseDTO';
import { ColaboradorResponseListDTO } from '../models/ColaboradorResponseListDTO';
import { ColaboradorCreateDTO } from '../models/ColaboradorCreateDTO';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ColaboradorService {

  // pegando a variavel da url de listagem de colaborador
  private apiUrl = `${environment.ApiUrl}/Colaborador/listagemColaboradores`

  private apiUrlAddColaborador = `${environment.ApiUrl}/Colaborador/adicionarColaborador`


  // importanto o httpclint via injeção de dependencia
  constructor(private http: HttpClient) { }

  // metodo de listagem de colaboradores
  GetColaborador() : Observable<ResponseBase<ColaboradorResponseListDTO[]>> {
    return this.http.get<ResponseBase<ColaboradorResponseListDTO[]>>(this.apiUrl);
  }

  // metodo de cadastro de colaborador
  AdicionarColaborador(colaborador: ColaboradorCreateDTO) :  Observable<ResponseBase<ColaboradorResponseDTO[]>>{
    return this.http.post<ResponseBase<ColaboradorResponseDTO[]>>(`${this.apiUrlAddColaborador}`, colaborador);
  }


}
