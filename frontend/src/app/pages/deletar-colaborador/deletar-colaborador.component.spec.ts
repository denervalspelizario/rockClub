import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarColaboradorComponent } from './deletar-colaborador.component';

describe('DeletarColaboradorComponent', () => {
  let component: DeletarColaboradorComponent;
  let fixture: ComponentFixture<DeletarColaboradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeletarColaboradorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeletarColaboradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
