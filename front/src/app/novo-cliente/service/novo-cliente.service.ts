import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NovoCliente } from './novo-cliente.service.iterface';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NovoClienteService {

  constructor(private http: HttpClient) { }

  novoCliente(objt: {email: string,
    idEspecialidade: number, nome: string,
    telefone: string}): Observable<NovoCliente> {

    const url = 'https://poc-projeto-integrado.herokuapp.com/api/v1/Medico';
    return this.http.post<NovoCliente>(url, objt);
    // .pipe(
    //   catchError(this.handleError)
    // );
  }
}
