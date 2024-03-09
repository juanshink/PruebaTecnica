import { createFeatureSelector, createSelector } from '@ngrx/store';
import { EntityState } from './generic.reducer';

export function getEntityFeatureState<T>(entityName: string) {
  return createFeatureSelector<EntityState<T>>(`${entityName}`);
}

export function createEntitySelectors<T>(entityName: string) {
  const selectEntityState = getEntityFeatureState<T>(entityName);

  const selectEntidades = createSelector(
    selectEntityState,
    (state: EntityState<T>) => state.entidades
  );

  return {
    selectEntityState,
    selectEntidades
  };
}
