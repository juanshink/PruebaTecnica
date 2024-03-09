import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GenericService } from './genericservice.service';
import { IProfesor } from '../interfaces/IProfesor';

@Injectable({
  providedIn: 'root',
})
export class ProfesorService extends GenericService<IProfesor> {
  constructor(http: HttpClient) {
    super(http, 'Profesor');
  }
}