import { Component, OnInit } from '@angular/core';
import { ColaboradorService } from '../../service/colaborador.service';
import { ColaboradorResponseListDTO } from './../../models/ColaboradorResponseListDTO';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterLink } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ CommonModule, HttpClientModule, RouterLink, MatButtonModule, MatInputModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  // variavel vazia que vai receber os colaboradoresList
  colaboradoresList?: ColaboradorResponseListDTO[] = [];

  // variavel vazia que vai receber os colaboradoresList
  colaboradoresListGeral?: ColaboradorResponseListDTO[] = [];


  // criando construtor para gerar  a Injeção de dependencia
  constructor( private colaboradorService: ColaboradorService){}

  // Vai executar assim que a api começar a funcionar
  ngOnInit(): void {

    this.colaboradorService.GetColaborador().subscribe(data => {

      // se caso eu fosse tratar algum dado vindo do back eu faria dentro desse map
      const dados = data.dados; // pegando objeto dados da requisição



      dados?.map((item) => {

      })



      // como não vou tratar nenhum dado adiciono direto
      this.colaboradoresList = data.dados
      this.colaboradoresListGeral = data.dados

    })
  }

  // função search que recebe um evento que o os dados digitados no input
  search(event: Event){

    // pegando os dados de input
    const target = event.target as HTMLInputElement;

    // pegando o valor de target(dados digitado no input)
    const value = target.value.toLowerCase()

    // fazendo o filtro baseado no que esta digitado no input
    this.colaboradoresList = this.colaboradoresListGeral?.filter(colaborador => {

      return colaborador.nome.toLowerCase().includes(value)
    })

  }

}
