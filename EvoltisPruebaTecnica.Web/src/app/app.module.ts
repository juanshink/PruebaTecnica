import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { CardModule } from 'primeng/card';
import { TabViewModule } from 'primeng/tabview';
import { DataTableComponent } from './components/data-table/data-table.component';
import { FormPersonComponent } from './components/form-person/form-person.component';
import { InputTextModule } from 'primeng/inputtext';
import { FormMateriaComponent } from './components/form-materia/form-materia.component';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { MessagesModule } from 'primeng/messages';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ReactiveFormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { HttpClientModule } from '@angular/common/http';
import { MateriaService } from './services/materia.service';
import { FormsModule } from '@angular/forms';

import { createEntityReducer } from './states/generic.reducer';
import { IMateria } from './interfaces/IMateria';
import { IAlumno } from './interfaces/IAlumno';
import { IProfesor } from './interfaces/IProfesor';

@NgModule({
  declarations: [
    AppComponent,
    DataTableComponent,
    FormPersonComponent,
    FormMateriaComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CardModule,
    TabViewModule,
    InputTextModule,
    DropdownModule,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    MessagesModule,
    DialogModule,
    CalendarModule,
    StoreModule.forRoot({
      materias: createEntityReducer<IMateria>('materias'),
      alumnos: createEntityReducer<IAlumno>('alumnos'),
      profesores: createEntityReducer<IProfesor>('profesores')
    }),
    EffectsModule.forRoot([])
  ],
  providers: [MessageService,
              MateriaService,
              ConfirmationService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
