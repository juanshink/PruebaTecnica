import { Component, ViewChild } from '@angular/core';
import { FormPersonComponent } from './components/form-person/form-person.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'EvoltisPruebaTecnica';
  @ViewChild('alumnoForm') alumnoForm!: FormPersonComponent;
  @ViewChild('profesorForm') profesorForm!: FormPersonComponent;

  onTabChange(event: any) {
    // Lógica para manejar el cambio de pestaña si es necesario
    // Ejemplo: restablecer el formulario del componente hijo correspondiente
    if (event.index === 0) {
      this.alumnoForm.resetForm();
    } else if (event.index === 1) {
      this.profesorForm.resetForm();
    }
  }
}
