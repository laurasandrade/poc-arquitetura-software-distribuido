import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ListaEspecialidade } from '../painel-admin/serveice/painel-admin.interface';
import { PainelAdminService } from '../painel-admin/serveice/painel-admin.service';
import { NovoCliente } from '../novo-cliente/service/novo-cliente.service.iterface';
import { EditarClienteService } from './service/editar-cliente.service';

@Component({
  selector: 'app-editar-cliente',
  templateUrl: './editar-cliente.component.html',
  styleUrls: ['./editar-cliente.component.scss']
})
export class EditarClienteComponent implements OnInit {
  public isError = false;

  public mostrarLoader = false;

  listaEspec: Array<any>;

  medico = JSON.parse(localStorage.getItem('medico') as string);

  editarClienteForm = this.fb.group({
    idEspecialidade: [this.medico.idEspecialidade, Validators.required],
    nome: [this.medico.nome, Validators.required],
    email: [this.medico.email, Validators.required],
    telefone: [this.medico.telefone, Validators.required]
  });

  constructor(
    private fb: FormBuilder,
    private painelAdminService: PainelAdminService,
    private editarClienteService: EditarClienteService
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

  editar(){
    this.isError = false;
    this.mostrarLoader = true;

    this.editarClienteService.editarCliente(
      {...this.editarClienteForm.value, idMedico: this.medico.idEspecialidade}
      ).subscribe((data: NovoCliente) => {
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
        this.listaEspec = data.data;
        this.mostrarLoader = false;
      },
      error => { console.log(error); this.isError = true; this.mostrarLoader = false; }
    );  
  }

}
