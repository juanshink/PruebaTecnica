import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GenericService } from './genericservice.service';
import { IMateria } from '../interfaces/IMateria';

@Injectable({
  providedIn: 'root',
})
export class MateriaService extends GenericService<IMateria> {
  constructor(http: HttpClient) {
    super(http, 'Materia');
  }
}