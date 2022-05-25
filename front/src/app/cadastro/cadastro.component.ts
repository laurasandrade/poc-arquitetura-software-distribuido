import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginInterface } from '../login/services/login.service.interface';
import { CadastroService } from './service/cadastro.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {

  cadastroForm = this.fb.group({
    nome: ['', Validators.required],
    email: ['', Validators.required],
    senha: ['', Validators.required],
  });

  public mostrarLoader = false;

  public isErrorLogin = false;

  constructor(private fb: FormBuilder,
      private cadastroService: CadastroService,
      private router: Router
    ) { }

  ngOnInit(): void {
  }

  cadastrar() {
    this.isErrorLogin = false;
    this.mostrarLoader = true;

    this.cadastroService.fazerCadastro(this.cadastroForm.value)
      .subscribe((data: LoginInterface) => {
        if(data.authenticated) {
          localStorage.setItem('accessToken', data.accessToken);
          localStorage.setItem('expirationToken', data.expiration);
          this.mostrarLoader = false;
          this.router.navigate(['painel-admin']);
        }
      },
      error => { console.log(error); this.isErrorLogin = true; this.mostrarLoader = false; }
    );
  }

}
