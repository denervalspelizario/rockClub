import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { ResponseBase } from '../models/ResponseBase';
import { ColaboradorResponseDTO } from '../models/ColaboradorResponseDTO';
import { ColaboradorResponseListDTO } from '../models/ColaboradorResponseListDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ColaboradorService {

  // pegando a variavel da url
  private apiUrl = `${environment.ApiUrl}/Colaborador/listagemColaboradores`

  // importanto o httpclint via injeção de dependencia
  constructor(private http: HttpClient) { }

  // metodo de listagem de colaboradores
  GetColaborador() : Observable<ResponseBase<ColaboradorResponseListDTO[]>> {
    return this.http.get<ResponseBase<ColaboradorResponseListDTO[]>>(this.apiUrl);
  }

}
