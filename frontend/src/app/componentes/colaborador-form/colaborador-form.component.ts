import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {  FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CargoEnum } from '../../models/CargoEnum';
import { SexoEnum } from '../../models/SexoEnum';
import { DepartamentoEnum } from '../../models/DepartamentoEnum';
import { FormsModule } from '@angular/forms';
import { ColaboradorCreateDTO } from '../../models/ColaboradorCreateDTO';
import { RouterLink } from '@angular/router';
import { ColaboradorResponseDTO } from '../../models/ColaboradorResponseDTO';
import { CommonModule } from '@angular/common';

// angular material
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';






@Component({
  selector: 'app-colaborador-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, RouterLink, CommonModule, MatButtonModule, MatCardModule, MatInputModule, MatSelectModule],
  templateUrl: './colaborador-form.component.html',
  styleUrl: './colaborador-form.component.css'
})
export class ColaboradorFormComponent implements OnInit{


  // variavel que joga os dados do formulario para fora do component
  // no caso para app-cadastro
  @Output() onSubmit = new EventEmitter<ColaboradorCreateDTO>();



  // o valor dessa variavel que será recebida no html do pages cadastro(props)
  @Input() btnAcao!: string

  // o valor dessa variavel que será recebida no html do pages cadastro(props)
  @Input() btnTitulo!: string

  // o valor dessa variavel que será recebida no html do pages cadastro(props)
  @Input()
  dadosColaborador!: ColaboradorResponseDTO | null;

  // linkando formulario do html com aqui
  colaboradorForm!: FormGroup;
  cargo = CargoEnum;
  departamento = DepartamentoEnum;
  sexo = SexoEnum;

  constructor() {

  }




  // sera inicializado assim que usuario ir neste pagina
  ngOnInit(): void {

      this.colaboradorForm = new FormGroup({
        Nome: new FormControl('', [Validators.required]),
        Data_nascimento: new FormControl('', [Validators.required]),
        Cpf: new FormControl('', [Validators.required]),
        Endereco: new FormControl('', [Validators.required]),
        Sexo: new FormControl('', [Validators.required]),
        Telefone: new FormControl('', [Validators.required]),
        Email: new FormControl('', [Validators.required]),
        Cargo: new FormControl('', [Validators.required]),
        Salario: new FormControl('', [Validators.required]),
        Departamento: new FormControl('', [Validators.required])
      });

  }


  // Função para enviar o formulário
  submit() {

    // chamando o metodo que joga os dados do form
    // fora fora do compomente(no caso o cadastro que vai pegar)
    this.onSubmit.emit(this.colaboradorForm.value);
  }

}
