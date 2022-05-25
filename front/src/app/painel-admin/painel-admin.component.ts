import { Component, OnInit } from '@angular/core';
import { ListaMedico, ListaEspecialidade, ListaMedicoDelete }
  from './serveice/painel-admin.interface';
import { PainelAdminService } from './serveice/painel-admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-painel-admin',
  templateUrl: './painel-admin.component.html',
  styleUrls: ['./painel-admin.component.scss']
})
export class PainelAdminComponent implements OnInit {
  public listaClientes: any;
  public listaEspec: ListaEspecialidade;
  public isError = false;
  public especSelect = 0;
  public mostrarLoader = false;

  selectedData: any;

  constructor(
    private painelAdminService: PainelAdminService,
    private router: Router
  ) {
    this.listaEspec = {
      data: [
        {
          idEspecialidade: 0,
          nome: ''
        }
      ],
      message: 'Operação realizada com sucesso.',
      success: true,
      total: 4
    };
  }

  ngOnInit(): void {
    this.listaCompletaEspecialidade();
  }

  onSelect(val: number, teste: any) {
    this.selectedData = teste.filter((x: any) => {
      return x.idEspecialidade === +val;
    });
  }

  listaCompletaClientes(): void {
    this.isError = false;

    this.painelAdminService.listarMedicos()
      .subscribe((data: ListaMedico) => {
        this.listaClientes = data.data;
        this.selectedData = data.data;
      },
        error => { console.log(error); this.isError = true; }
      );
  }

  listaCompletaEspecialidade(): void {
    this.isError = false;
    this.mostrarLoader = true;

    this.painelAdminService.listarEspecialidade()
      .subscribe((data: ListaEspecialidade) => {
        this.listaCompletaClientes();
        this.listaEspec = data;
        this.mostrarLoader = false;
      },
        error => { console.log(error); this.isError = true; this.mostrarLoader = false; }
      );
  }

  retornarEspec(val: number): string {
    const espec = this.listaEspec.data.filter(data => {
      return data.idEspecialidade === val;
    });

    return espec[0].nome;
  }

  deletar(idMedico: string): void {
    this.isError = false;
    this.mostrarLoader = true;

    this.painelAdminService.deletarMedico(idMedico)
      .subscribe((data: ListaMedicoDelete) => {
        this.listaCompletaEspecialidade();
        this.mostrarLoader = false;
      },
        error => { console.log(error); this.isError = true; this.mostrarLoader = false;}
      );
  }

  irEditar(medico: any): void {
    localStorage.setItem('medico', JSON.stringify(medico));
    this.router.navigate(['editar-cliente']);
  }

}
