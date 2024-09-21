import { Component, OnInit } from '@angular/core';
import { ColaboradorFormComponent } from "../../componentes/colaborador-form/colaborador-form.component";
import { ColaboradorResponseDTO } from '../../models/ColaboradorResponseDTO';
import { ColaboradorService } from '../../service/colaborador.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SexoEnum } from '../../models/SexoEnum';
import { CargoEnum } from '../../models/CargoEnum';
import { DepartamentoEnum } from '../../models/DepartamentoEnum';
import { ColaboradorUpdateDTO } from '../../models/ColaboradorUpdateDTO';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-editar-colaborador',
  standalone: true,
  imports: [ColaboradorFormComponent, CommonModule, FormsModule, ReactiveFormsModule, RouterLink],
  templateUrl: './editar-colaborador.component.html',
  styleUrl: './editar-colaborador.component.css'
})
export class EditarColaboradorComponent {

  // criando btnAcao , btnTitulo , dadosColaborador
  btnAcao:string = "Editar"
  btnTitulo:string = "Editar Colaborador"

  // linkando formulario do html com aqui
  colaboradorForm!: FormGroup; // criando um formulário
  cargo = CargoEnum;
  departamento = DepartamentoEnum;
  sexo = SexoEnum;
  //colaboradorRecebeDados?: ColaboradorResponseDTO ; // variavel tipo ColaboradorResponseDTO
  dadosColaborador: ColaboradorResponseDTO | null = null;
  dadosColaboradorUpdate!: ColaboradorUpdateDTO
  colaboradorNome:string = "";


  // Injeções de dependência
  constructor(
    private colaboradorService: ColaboradorService,
    private route: ActivatedRoute,
    private router: Router
  ) {

  }




  // sera inicializado assim que usuario ir neste pagina
  ngOnInit(): void {


    // pegando o id do colaborador pela url(no caso id do usar para editar)
    const id = this.route.snapshot.paramMap.get('id')


    // agora que temos o id pegado da url
    //chamamos o metodo que pega os dados o colaborador via id
    this.colaboradorService.GetColaboradorId(id).subscribe((data) => {

    // variavel recebe o nome para mostrar no html
    this.colaboradorNome = data.dados.nome

    // adicionando os dados buscado do metodo getColaboradorId
    // na variavel dadosColaborador
    this.dadosColaborador = data.dados;


    // dados recebidos pelo formulário
    this.colaboradorForm = new FormGroup({

      Id: new FormControl(this.dadosColaborador ? this.dadosColaborador.id : '', [Validators.required]),

      Nome: new FormControl(this.dadosColaborador ? this.dadosColaborador.nome : '', [Validators.required]),

      Data_nascimento: new FormControl(this.dadosColaborador ? this.dadosColaborador.data_nascimento : '', [Validators.required]),

      Data_Admissao: new FormControl(this.dadosColaborador ? this.dadosColaborador.data_admissao : '', [Validators.required]),

      Cpf: new FormControl(this.dadosColaborador ? this.dadosColaborador.cpf : '', [Validators.required]),

      Endereco: new FormControl(this.dadosColaborador ? this.dadosColaborador.endereco : '', [Validators.required]),

      Sexo: new FormControl(this.dadosColaborador ? this.dadosColaborador.sexo : null, [Validators.required]),

      Telefone: new FormControl(this.dadosColaborador ? this.dadosColaborador.telefone : '', [Validators.required]),

      Email: new FormControl(this.dadosColaborador ? this.dadosColaborador.email : '', [Validators.required]),

      Cargo: new FormControl(this.dadosColaborador ? this.dadosColaborador.cargo : null, [Validators.required]),

      Salario: new FormControl(this.dadosColaborador ? this.dadosColaborador.salario : null, [Validators.required]),

      Departamento: new FormControl(this.dadosColaborador ? this.dadosColaborador.departamento : null, [Validators.required])

    });


  })



}

  //função de editar colaborador
  editarColaborador(colaborador: ColaboradorUpdateDTO)
  {
    // chamando o metodo post que edita colaborador
    this.colaboradorService.EditarColaborador(colaborador).subscribe((data) =>{

    })
  }


  // botão que ao clicar...
  submit() {

    // adicionao os dados do formulario na variavel dadosColaboradorUpdate
    this.dadosColaboradorUpdate = this.colaboradorForm.value

    // chama a função que edita coloborador que recebe os dados do formulario
    this.editarColaborador(this.dadosColaboradorUpdate)

    // depois de fazer o alteração volta para pagina inicial
    this.router.navigate(['/'])
  }

}
