import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginInterface } from '../../login/services/login.service.interface';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  constructor(private http: HttpClient) { }

  fazerCadastro(objt: {email: string, senha: string, nome: string }): Observable<LoginInterface> {
    const url = 'https://poc-projeto-integrado.herokuapp.com/api/v1/Login/cadastro';
    return this.http.post<LoginInterface>(url, objt);
    // .pipe(
    //   catchError(this.handleError)
    // );
  }
}
