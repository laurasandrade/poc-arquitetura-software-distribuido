import { TestBed } from '@angular/core/testing';

import { PainelAdminService } from './painel-admin.service';

describe('PainelAdminService', () => {
  let service: PainelAdminService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PainelAdminService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
