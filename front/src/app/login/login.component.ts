import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { LoginService } from './services/login.service';
import { LoginInterface } from './services/login.service.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public isErrorLogin = false;
  public mostrarLoader = false;

  logingForm = this.fb.group({
    email: ['', Validators.required],
    senha: ['', Validators.required],
  });
  
  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router
    ) { }

  ngOnInit(): void { }

  login(): void {
    this.isErrorLogin = false;
    this.mostrarLoader = true;

    this.loginService.fazerLogin(this.logingForm.value)
      .subscribe((data: LoginInterface) => {
        this.mostrarLoader = false;
        if(data.authenticated) {
          localStorage.setItem('accessToken', data.accessToken);
          localStorage.setItem('expirationToken', data.expiration);
          this.router.navigate(['painel-admin']);
        }
      },
      error => { console.log(error); this.isErrorLogin = true; this.mostrarLoader = false; }
    );
  }

}
