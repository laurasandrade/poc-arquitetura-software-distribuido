import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListaEspecialidade } from 'src/app/painel-admin/serveice/painel-admin.interface';

@Injectable({
  providedIn: 'root'
})
export class AdicionarEspecialidadeService {

  constructor(private http: HttpClient) { }

  adicionarEspecialidade(objt: { email: string, senha: string, nome: string }): Observable<ListaEspecialidade> {
    const url = 'https://poc-projeto-integrado.herokuapp.com/api/v1/Especialidade';
    return this.http.post<ListaEspecialidade>(url, objt);
  }
}
