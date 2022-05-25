import { TestBed } from '@angular/core/testing';
import { AdicionarEspecialidadeService } from './adicionar-especialidade.service';


describe('CadastroService', () => {
  let service: AdicionarEspecialidadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdicionarEspecialidadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
