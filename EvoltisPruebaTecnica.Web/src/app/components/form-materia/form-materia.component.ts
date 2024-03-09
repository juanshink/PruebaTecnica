import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IMateria } from 'src/app/interfaces/IMateria';
import { NotificationService } from 'src/app/services/notification.services';
import { MateriaService } from 'src/app/services/materia.service';
import { Store, select } from '@ngrx/store';
import { from } from 'rxjs/internal/observable/from';
import { agregarEntidad, cargarEntidades } from 'src/app/states/generic.actions';

@Component({
  selector: 'app-form-materia',
  templateUrl: './form-materia.component.html',
  styleUrls: ['./form-materia.component.scss']
})
export class FormMateriaComponent implements OnInit{


  
  periodos: string[] = ["Bimestral","Cuatrimestral","Anual"]

  formSubject!: FormGroup;
  materia!:IMateria;
  materias!:IMateria[];

  constructor(private formBuilder: FormBuilder,
              private NotiService: NotificationService,
              private store: Store,
              private materiaSrv: MateriaService){

      this.formSubject = this.formBuilder.group({
        nombre: ['', Validators.required],
        periodo: ['',Validators.required]
      })
  }
  async ngOnInit(){
    this.materias = await this.materiaSrv.getAll();
    
  }

  async submitForm(){

    if (this.formSubject.invalid){
        this.NotiService.showError('Formulario invalido');
    }
    else {if (this.formSubject.valid){

        this.materia = {
          id: 0,
          nombre: this.formSubject.get('nombre')?.value,
          duracion: this.formSubject.get('periodo')?.value,
          createdDate: new Date(),
          lastModifiedDate: new Date(),
          deleted: false
        }

        from(this.materiaSrv.add(this.materia)).subscribe(() => {
          // llamo a la accion
          this.store.dispatch(agregarEntidad({ entidad: this.materia, entityName: 'materias' }));
        });

          await this.materiaSrv.getAll();

          this.NotiService.showSuccess('Formulario cargado correctamente');
          this.formSubject.reset();
    }}
    }
}
