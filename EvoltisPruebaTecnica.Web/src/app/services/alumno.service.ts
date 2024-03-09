import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GenericService } from './genericservice.service';
import { IAlumno } from '../interfaces/IAlumno';

@Injectable({
  providedIn: 'root',
})
export class AlumnoService extends GenericService<IAlumno> {
  constructor(http: HttpClient) {
    super(http, 'Alumno');
  }
}