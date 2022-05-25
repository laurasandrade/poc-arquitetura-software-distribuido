import { TestBed } from '@angular/core/testing';

import { EditarClienteService } from './editar-cliente.service';

describe('EditarClienteService', () => {
  let service: EditarClienteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditarClienteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
