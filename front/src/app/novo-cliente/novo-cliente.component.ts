import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NovoClienteService } from './service/novo-cliente.service';
import { NovoCliente } from './service/novo-cliente.service.iterface';
import { PainelAdminService } from '../painel-admin/serveice/painel-admin.service';
import { ListaEspecialidade } from '../painel-admin/serveice/painel-admin.interface';

@Component({
  selector: 'app-novo-cliente',
  templateUrl: './novo-cliente.component.html',
  styleUrls: ['./novo-cliente.component.scss']
})
export class NovoClienteComponent implements OnInit {
  public isError = false;

  listaEspec: Array<any>;

  public mostrarLoader = false;

  novoClienteForm = this.fb.group({
    idEspecialidade: [1, Validators.required],
    nome: ['', Validators.required],
    email: ['', Validators.required],
    telefone: ['', Validators.required]
  });

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private novoClienteService: NovoClienteService,
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
    this.listaCompletaEspecialidade();
  }

  novo(){
    this.isError = false;
    this.mostrarLoader = true;

    this.novoClienteService.novoCliente(this.novoClienteForm.value)
      .subscribe((data: NovoCliente) => {
        this.mostrarLoader = false;
      },
      error => { console.log(error); this.isError = true; this.mostrarLoader = false; }
    );  
  }

  listaCompletaEspecialidade(): void {
    this.isError = false;
    this.mostrarLoader = true;

    this.painelAdminService.listarEspecialidade()
      .subscribe((data: ListaEspecialidade) => {
        console.log(data);
        this.listaEspec = data.data;
        this.mostrarLoader = false;
      },
      error => { console.log(error); this.isError = true; this.mostrarLoader = false; }
    );  
  }
}
