import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NovoCliente } from '../../novo-cliente/service/novo-cliente.service.iterface';

@Injectable({
  providedIn: 'root'
})
export class EditarClienteService {

  constructor(private http: HttpClient) { }

  editarCliente(objt: {email: string,
    idEspecialidade: number, nome: string,
    telefone: string, idMedico: number}): Observable<NovoCliente> {

    const url = 'https://poc-projeto-integrado.herokuapp.com/api/v1/Medico';
    return this.http.put<NovoCliente>(url, objt);
    // .pipe(
    //   catchError(this.handleError)
    // );
  }
}
