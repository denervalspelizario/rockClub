import { Routes } from '@angular/router';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { HomeComponent } from './pages/home/home.component';
import { EditarColaboradorComponent } from './pages/editar-colaborador/editar-colaborador.component';
import { DetalhesColaboradorComponent } from './pages/detalhes-colaborador/detalhes-colaborador.component';

export const routes: Routes = [
  {
    path:'',
    component: HomeComponent
  },
  {
    path: 'cadastro',
    component: CadastroComponent
  },
  {
    path: 'editarColaborador/:id', // a rota precisa colocar o id do colaborador
    component: EditarColaboradorComponent
  },
  {
    path: 'detalhesColaborador/:id', // a rota que ira exibir detalhes do colaborador
    component: DetalhesColaboradorComponent
  }
];
