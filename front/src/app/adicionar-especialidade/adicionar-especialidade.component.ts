import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NovoClienteService } from '../novo-cliente/service/novo-cliente.service';
import { PainelAdminService } from '../painel-admin/serveice/painel-admin.service';
import { NovoCliente } from '../novo-cliente/service/novo-cliente.service.iterface';
import { ListaEspecialidade } from '../painel-admin/serveice/painel-admin.interface';
import { AdicionarEspecialidadeService } from './service/adicionar-especialidade.service';

@Component({
  selector: 'app-adicionar-especialidade',
  templateUrl: './adicionar-especialidade.component.html',
  styleUrls: ['./adicionar-especialidade.component.scss']
})
export class AdicionarEspecialidadeComponent implements OnInit {

  public isError = false;

  listaEspec: Array<any>;

  public mostrarLoader = false;

  adicionarEspecialidadeForm = this.fb.group({
    idEspecialidade: [1, Validators.required],
    nome: ['', Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private novoClienteService: NovoClienteService,
    private adicionarEspecialidade: AdicionarEspecialidadeService,
    private painelAdminService: PainelAdminService
  ) {
    this.listaEspec = [
      {
        idEspecialidade: 0,
        nome: ''
      }
    ];
  }

  ngOnInit(): void {
  }

  novo() {
    this.isError = false;
    this.mostrarLoader = true;

    this.adicionarEspecialidade.adicionarEspecialidade(this.adicionarEspecialidadeForm.value)
      .subscribe((data: ListaEspecialidade) => {
        this.mostrarLoader = false;
      },
        error => { console.log(error); this.isError = true; this.mostrarLoader = false; }
      );
  }

}
