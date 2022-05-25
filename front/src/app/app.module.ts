import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { PainelAdminComponent } from './painel-admin/painel-admin.component';
import { NovoClienteComponent } from './novo-cliente/novo-cliente.component';
import { EditarClienteComponent } from './editar-cliente/editar-cliente.component';
import { EspecialidadeComponent } from './especialidade/especialidade.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { AuthInterceptorService } from './shared/components/http-interceptors/auth-interceptor.service';
import { LoaderComponent } from './shared/components/loader/loader.component';
import { AdicionarEspecialidadeComponent } from './adicionar-especialidade/adicionar-especialidade.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CadastroComponent,
    PainelAdminComponent,
    NovoClienteComponent,
    EditarClienteComponent,
    EspecialidadeComponent,
    NavbarComponent,
    LoaderComponent,
    AdicionarEspecialidadeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
