import { createReducer, on } from '@ngrx/store';
import { cargarEntidades, agregarEntidad, editarEntidad, eliminarEntidad } from './generic.actions';

export interface EntityState<T> {
  entidades: T[];
}

export const initialState: EntityState<any> = {
  entidades: []
};

export function createEntityReducer<T>(entityName: string) {
  return createReducer(
    initialState,
    on(cargarEntidades, (state, action) => {
      if (action.entityName === entityName) {
        return { ...state, entidades: action.entidad };
      }
      return state;
    }),
    on(agregarEntidad, (state, action) => {
      if (action.entityName === entityName) {
        return { ...state, entidades: [...state.entidades, action.entidad] };
      }
      return state;
    }),
    on(editarEntidad, (state, action) => {
      if (action.entityName === entityName) {
        const index = state.entidades.findIndex(entidad => entidad.id === action.entidad.id);
        if (index !== -1) {
          const entidades = [...state.entidades];
          entidades[index] = action.entidad;
          return { ...state, entidades };
        }
      }
      return state;
    }),
    on(eliminarEntidad, (state, action) => {
      if (action.entityName === entityName) {
        return { ...state, entidades: state.entidades.filter(entidad => entidad.id !== action.entidad.id) };
      }
      return state;
    })
  );
}