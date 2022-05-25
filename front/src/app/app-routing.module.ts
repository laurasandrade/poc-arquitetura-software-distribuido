import { AdicionarEspecialidadeComponent } from './adicionar-especialidade/adicionar-especialidade.component';
import { PainelAdminComponent } from './painel-admin/painel-admin.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { EditarClienteComponent } from './editar-cliente/editar-cliente.component';
import { NovoClienteComponent } from './novo-cliente/novo-cliente.component';
import { EspecialidadeComponent } from './especialidade/especialidade.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'painel-admin', component: PainelAdminComponent },
  { path: 'novo-cliente', component: NovoClienteComponent },
  { path: 'editar-cliente', component: EditarClienteComponent },
  { path: 'adicionar-especialidade', component: AdicionarEspecialidadeComponent },
  { path: 'especialidade', component: EspecialidadeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
