import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { AlumnoService } from 'src/app/services/alumno.service';
import { MateriaService } from 'src/app/services/materia.service';
import { ProfesorService } from 'src/app/services/profesor.service';

import { cargarEntidades, editarEntidad, eliminarEntidad } from 'src/app/states/generic.actions';
import { createEntitySelectors } from '../../states/generic.selectors'
import { IMateria } from 'src/app/interfaces/IMateria';
import { IAlumno } from 'src/app/interfaces/IAlumno';
import { IProfesor } from 'src/app/interfaces/IProfesor';
import { NotificationService } from 'src/app/services/notification.services';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent implements OnInit {
  @Input() tipoDato!: string;

  data$: Observable<any[]> = of([]);
  
  columns: string[] = [];
  renderizar: boolean = false;

  entidad:any;

  filaEditada: any; // Ajusta el tipo según la estructura de tus datos
  edicion: boolean = false;

  constructor(
    private alumnoSrv: AlumnoService,
    private profesorSrv: ProfesorService,
    private materiaSrv: MateriaService,
    private store: Store,
    private notiSrv: NotificationService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadData();
  }

  async loadData(){

    let selectEntidades: any;

    switch (this.tipoDato) {
      case 'Alumno':
        ({ selectEntidades } = createEntitySelectors<IAlumno>('alumnos'));
        await this.alumnoSrv.getAll().then(data => {


          this.store.dispatch(cargarEntidades({ entidad: data, entityName: 'alumnos' }));
             // Actualizar state
                this.data$ = this.store.select(selectEntidades);
                this.renderizar = true;
                
                this.data$.subscribe(data => {
                  if (data && data.length > 0) {
                    this.columns = this.getKeys(data[0]);
                  }
                });
        });
        break;
      case 'Profesor':
        ({selectEntidades } = createEntitySelectors<IProfesor>('profesores'));
        await this.profesorSrv.getAll().then(data => {
          this.store.dispatch(cargarEntidades({ entidad: data, entityName: 'profesores' }));

            this.data$ = this.store.select(selectEntidades);
            this.renderizar = true;
            
            this.data$.subscribe(data => {
              if (data && data.length > 0) {
                this.columns = this.getKeys(data[0]);
              }
            });
        });
        break;
      case 'Materia':
        ({ selectEntidades } = createEntitySelectors<IMateria>('materias'));
        await this.materiaSrv.getAll().then(data => {
          this.store.dispatch(cargarEntidades({ entidad: data, entityName: 'materias' }));

            this.data$ = this.store.select(selectEntidades);
            this.renderizar = true;
            
            this.data$.subscribe(data => {
              if (data && data.length > 0) {
                this.columns = this.getKeys(data[0]);
              }
            });
        });
        break;
      default:
        console.error('Tipo de dato no válido:', this.tipoDato);
        break;
    }
      
    }
  
    getKeys(obj: any): string[] {
      return Object.keys(obj);
    }  

    editRow(rowData:any){

      this.filaEditada = { ...rowData };
      this.edicion = true;
      
    }

    async guardarEdicion() {

      switch (this.tipoDato) {
        case 'Alumno':

          await this.alumnoSrv.update(this.filaEditada).then( data => {
            console.log("que es data?:    ", data);
            this.notiSrv.showSuccess("Se edito el alumno con exito")
            this.store.dispatch(editarEntidad({ entidad: this.filaEditada, entityName: 'alumnos' }));
          })

          break;

        case 'Profesor':

          await this.profesorSrv.update(this.filaEditada).then( data => {
            console.log("que es data?:    ", data);
            this.notiSrv.showSuccess("Se edito el profesor con exito")
            this.store.dispatch(editarEntidad({ entidad: this.filaEditada, entityName: 'profesores' }));
          })
          
          break;

        case 'Materia':

          await this.materiaSrv.update(this.filaEditada).then( data => {
            console.log("que es data?:    ", data);
            this.notiSrv.showSuccess("Se borro la materia con exito")
            this.store.dispatch(editarEntidad({ entidad: this.filaEditada, entityName: 'materias' }));
          })

          break;
      }

      this.edicion = false;
    }
  
    getKeysEdit(obj: any): string[] {
      // Verifica si obj no es null ni undefined antes de intentar acceder a sus propiedades
      if (obj && typeof obj === 'object') {
        return Object.keys(obj);
      } else {
        return [];
      }
    }

    deleteConfirmationDialog(rowData: any){
      this.confirmationService.confirm({
        message: '¿Estás seguro de eliminar este elemento?',
        acceptLabel: 'Sí',
        rejectLabel: 'No',
        accept: () => {
          this.deleteRow(rowData);
        },
        reject: () => {
          // Lógica a ejecutar cuando el usuario hace clic en "No" o cierra el diálogo
        },
      });
    }

    async deleteRow(rowData:any){
      switch (this.tipoDato) {
        case 'Alumno':

           console.log("este es el id", rowData.id)
          await this.alumnoSrv.delete(rowData.id).then( data => {
            console.log("que es data?:    ", data);
            this.notiSrv.showSuccess("Se borro el alumno con exito")
            this.store.dispatch(eliminarEntidad({ entidad: rowData, entityName: 'alumnos' }));
          })

          break;

        case 'Profesor':

          await this.profesorSrv.delete(rowData.id).then( data => {
            console.log("que es data?:    ", data);
            this.notiSrv.showSuccess("Se borro el profesor con exito")
            this.store.dispatch(eliminarEntidad({ entidad: rowData, entityName: 'profesores' }));
          })
          
          break;

        case 'Materia':

          await this.materiaSrv.delete(rowData.id).then( data => {
            console.log("que es data?:    ", data);
            this.notiSrv.showSuccess("Se borro la materia con exito")
            this.store.dispatch(eliminarEntidad({ entidad: rowData, entityName: 'materias' }));
          })

          break;
      }
    }
}


