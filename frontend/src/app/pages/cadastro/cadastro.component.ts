import { Component } from '@angular/core';
import { ColaboradorFormComponent } from "../../componentes/colaborador-form/colaborador-form.component";
import { ColaboradorCreateDTO } from '../../models/ColaboradorCreateDTO';
import { ColaboradorService } from '../../service/colaborador.service';
import { Router } from '@angular/router';
import { ColaboradorResponseDTO } from '../../models/ColaboradorResponseDTO';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [ColaboradorFormComponent],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {

  btnAcao = "Cadastrar!"
  btnTitulo = "Cadastrar colaborador"

  // fazendo a injeção de dependencia do colaboradorService e router
  constructor(
    private colaboradorService: ColaboradorService,
    private router: Router
    ){

  }


  // função que recebe os dados la do formulario(colaborador-form)
  createColaborador(colaborador: ColaboradorCreateDTO){

    // recebe os dados do formulario entro do methos de post(AdicionarColaborador)
    this.colaboradorService.AdicionarColaborador(colaborador).subscribe((data) => {

      // depois de adicionar colaborador vai para pagina home
      this.router.navigate(['/'])

    });

  }
}
