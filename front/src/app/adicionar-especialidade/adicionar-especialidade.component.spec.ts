import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarEspecialidadeComponent } from './adicionar-especialidade.component';

describe('AdicionarEspecialidadeComponent', () => {
  let component: AdicionarEspecialidadeComponent;
  let fixture: ComponentFixture<AdicionarEspecialidadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdicionarEspecialidadeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarEspecialidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
