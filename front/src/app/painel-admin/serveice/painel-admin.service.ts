import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListaMedico, ListaEspecialidade, ListaMedicoDelete } from './painel-admin.interface';

@Injectable({
  providedIn: 'root'
})
export class PainelAdminService {

  constructor(private http: HttpClient) { }

  listarMedicos(): Observable<ListaMedico> {
    const url = 'https://poc-projeto-integrado.herokuapp.com/api/v1/Medico/lista';
    return this.http.get<ListaMedico>(url);
  }

  listarEspecialidade(): Observable<ListaEspecialidade> {
    const url = 'https://poc-projeto-integrado.herokuapp.com/api/v1/Especialidade/lista';
    return this.http.get<ListaEspecialidade>(url);
  }

  deletarMedico(idMedico: string): Observable<ListaMedicoDelete> {
    const url = `https://poc-projeto-integrado.herokuapp.com/api/v1/Medico?idMedico=${idMedico}`;
    return this.http.delete<ListaMedicoDelete>(url);
  }
}
