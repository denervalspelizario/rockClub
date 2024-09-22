import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CargoEnum } from '../../models/CargoEnum';
import { DepartamentoEnum } from '../../models/DepartamentoEnum';
import { SexoEnum } from '../../models/SexoEnum';
import { ColaboradorService } from '../../service/colaborador.service';
import { ColaboradorResponseDTO } from '../../models/ColaboradorResponseDTO';

@Component({
  selector: 'app-detalhes-colaborador',
  standalone: true,
  imports: [ CommonModule, FormsModule, ReactiveFormsModule, RouterLink],
  templateUrl: './detalhes-colaborador.component.html',
  styleUrl: './detalhes-colaborador.component.css'
})

export class DetalhesColaboradorComponent {

  // linkando formulario do html com aqui
  colaboradorForm!: FormGroup; // criando um formulário
  cargo = CargoEnum;
  departamento = DepartamentoEnum;
  sexo = SexoEnum;
  dadosColaborador!: ColaboradorResponseDTO
  nomeColaborador!: string
  statusColaborador!: string

  // Injeções de dependência
  constructor(
    private colaboradorService: ColaboradorService,
    private route: ActivatedRoute,
    private router: Router) {}


  // sera inicializado assim que usuario ir neste pagina
  ngOnInit(): void {

    // pegando o id do colaborador pela url(no caso id do usar para editar)
    const id = this.route.snapshot.paramMap.get('id')


    // agora que temos o id pegado da url
    //chamamos o metodo que pega os dados o colaborador via id
    this.colaboradorService.GetColaboradorId(id).subscribe((data) => {

      // variavel recebe o nome para mostrar no html
      this.nomeColaborador = data.dados.nome

      if(data.status === true)
      {
        this.statusColaborador = "Ativo"
      } else {
        this.statusColaborador = "Desabilitado"
      }

      // pegando status do colaborador


      // adicionando os dados buscado do metodo getColaboradorId
      // na variavel dadosColaborador
      this.dadosColaborador = data.dados;


      // os campos do html do formulário será preenchido com dados do colaborador
      this.colaboradorForm = new FormGroup({

        Id: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.id : '', disabled: true }),


        Nome: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.nome : '', disabled: true }),

        Data_nascimento: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.data_nascimento : '', disabled: true }),

        Data_Admissao: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.data_admissao : '', disabled: true }),

        Cpf: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.cpf : '', disabled: true }),

        Endereco: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.endereco : '', disabled: true }),

        Sexo: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.sexo : '', disabled: true }),

        Telefone: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.telefone : '', disabled: true }),

        Email: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.email : '', disabled: true }),

        Cargo: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.cargo : '', disabled: true }),

        Salario: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.salario : '', disabled: true }),

        Departamento: new FormControl({ value: this.dadosColaborador ? this.dadosColaborador.departamento : '', disabled: true }),

        Status: new FormControl({ value: this.statusColaborador ? this.statusColaborador : '', disabled: true })
      });

    })

  }
}
