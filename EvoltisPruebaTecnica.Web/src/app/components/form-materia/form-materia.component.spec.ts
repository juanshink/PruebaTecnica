import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormMateriaComponent } from './form-materia.component';

describe('FormMateriaComponent', () => {
  let component: FormMateriaComponent;
  let fixture: ComponentFixture<FormMateriaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormMateriaComponent]
    });
    fixture = TestBed.createComponent(FormMateriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
