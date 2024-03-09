import { createAction, props } from '@ngrx/store';

export const cargarEntidades = createAction(
  '[Entidades Pages] Cargar Entidades',
  props<{ entidad: any[], entityName: string }>()
);

export const agregarEntidad = createAction(
  '[Entidades Pages] Agregar Entidad',
  props<{ entidad: any, entityName: string }>()
);

export const editarEntidad = createAction(
  '[Entidades Pages] Editar Entidad',
  props<{ entidad: any, entityName: string }>()
);

export const eliminarEntidad = createAction(
  '[Entidades Pages] Eliminar Entidad',
  props<{ entidad: any, entityName: string }>()
);