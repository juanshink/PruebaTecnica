import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { IAlumno } from 'src/app/interfaces/IAlumno';
import { IProfesor } from 'src/app/interfaces/IProfesor';
import { AlumnoService } from 'src/app/services/alumno.service';
import { NotificationService } from 'src/app/services/notification.services';
import { ProfesorService } from 'src/app/services/profesor.service';
import { agregarEntidad } from 'src/app/states/generic.actions';

@Component({
  selector: 'app-form-person',
  templateUrl: './form-person.component.html',
  styleUrls: ['./form-person.component.scss']
})
export class FormPersonComponent implements OnInit  {

  @Input() tipoPersona?: string;
  @Output() tabChanged: EventEmitter<void> = new EventEmitter<void>();
  
  formPerson!: FormGroup;
  alumno!: IAlumno;
  profesor!: IProfesor;

  constructor(private formBuilder: FormBuilder,
              private NotiService: NotificationService,
              private ProfService: ProfesorService,
              private AlumService: AlumnoService,
              private store: Store){

                this.formPerson = this.formBuilder.group({
                  nombre: ['', Validators.required],
                  apellido: ['',Validators.required],
                  dni: ['',Validators.required],
                  fechaNacimiento: [''],
                  especialidad: ['']
                })
  }

  ngOnInit() {

    this.requiredAboutType();
    this.formPerson.updateValueAndValidity();

  }

  resetForm() {
    this.formPerson.reset();
    console.log("se reseteo el form");
  }

  requiredAboutType(){
    
    if (this.tipoPersona === 'Alumno') {
      this.formPerson.get('fechaNacimiento')?.setValidators(Validators.required);
      this.formPerson.get('especialidad')?.clearValidators(); // Limpia los validadores si no son necesarios
    } else if (this.tipoPersona === 'Profesor') {
      this.formPerson.get('especialidad')?.setValidators(Validators.required);
      this.formPerson.get('fechaNacimiento')?.clearValidators(); // Limpia los validadores si no son necesarios
    }
  
    // Actualiza el estado del formulario para aplicar los cambios en los validadores
    this.formPerson.updateValueAndValidity();
  }

 async sendPerson(tipoPersona:string){

    console.log("este es el form", this.formPerson);

    if (this.formPerson.invalid) {
      this.NotiService.showError('Formulario inválido');

    } else {

      const persona: any = {
        id: 0,
        nombre: this.formPerson.get('nombre')?.value,
        apellido: this.formPerson.get('apellido')?.value,
        dni: this.formPerson.get('dni')?.value,
        createdDate: new Date(),
        lastModifiedDate: new Date(),
        deleted: false
      };
  
      
      if (tipoPersona === 'alumno') {
        const fechaNacimiento: Date = this.formPerson.get('fechaNacimiento')?.value;
        const fechaFormateada: string = fechaNacimiento.toISOString().split('T')[0];
      
        const personaConFechaFormateada = { ...persona, fechaNac: fechaFormateada };
      
        try {
          const data = await this.AlumService.add(personaConFechaFormateada);
      
          if (data) {
            this.store.dispatch(agregarEntidad({ entidad: personaConFechaFormateada, entityName: 'alumno' }));
            this.NotiService.showSuccess('Formulario cargado correctamente');
            await this.AlumService.getAll();
          } else {
            this.NotiService.showError('Error al cargar el formulario');
          }
        } catch (error) {
          console.error('Error al agregar alumno:', error);
          this.NotiService.showError('Error al cargar el formulario');
        }
      }
      

      if (tipoPersona === 'profesor') {

        persona.especialidad = this.formPerson.get('especialidad')?.value;

        try {
          const data = await this.AlumService.add(persona);
      
          if (data) {
            this.store.dispatch(agregarEntidad({ entidad: persona, entityName: 'profesor' }));
            this.NotiService.showSuccess('Formulario cargado correctamente');
            await this.ProfService.getAll();
          } else {
            this.NotiService.showError('Error al cargar el formulario');
          }
        } catch (error) {
          console.error('Error al agregar profesor:', error);
          this.NotiService.showError('Error al cargar el formulario');
        }

        console.log("esta es el profesor: ", persona);
        this.ProfService.add(persona);
        this.store.dispatch(agregarEntidad({ entidad: persona, entityName: 'profesor' }));
      }
    }
  }
}
