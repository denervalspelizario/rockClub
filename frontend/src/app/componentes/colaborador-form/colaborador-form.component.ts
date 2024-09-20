import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {  FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CargoEnum } from '../../models/CargoEnum';
import { SexoEnum } from '../../models/SexoEnum';
import { DepartamentoEnum } from '../../models/DepartamentoEnum';
import { FormsModule } from '@angular/forms';
import { ColaboradorCreateDTO } from '../../models/ColaboradorCreateDTO';
import { RouterLink } from '@angular/router';


@Component({
  selector: 'app-colaborador-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, RouterLink],
  templateUrl: './colaborador-form.component.html',
  styleUrl: './colaborador-form.component.css'
})
export class ColaboradorFormComponent implements OnInit{


  // variavel que joga os dados do formulario para fora do component
  // no caso para app-cadastro
  @Output() onSubmit = new EventEmitter<ColaboradorCreateDTO>();

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
    console.log(this.colaboradorForm.value);


    // chamando o metodo que joga os dados do form
    // fora fora do compomente(no caso o cadastro que vai pegar)
    this.onSubmit.emit(this.colaboradorForm.value);

  }

}
