import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, take, throwError } from 'rxjs';

export class GenericService<T> {
  private apiUrl: string;

  constructor(private http: HttpClient, endpoint: string) {
    this.apiUrl = `https://localhost:44378/api/${endpoint}`;
  }

  getAll(): Promise<T[]> {
    return this.http.get<T[]>(`${this.apiUrl}/getAll`)
      .pipe(
        take(1),
        catchError((error: HttpErrorResponse) => {
          let errorMessage = 'Error fetching data';
          
          if (error.error instanceof ErrorEvent) {
            // Error del lado del cliente
            errorMessage = `Client-side error: ${error.error.message}`;
          } else {
            // Error del lado del servidor
            errorMessage = `Server-side error: ${error.status} - ${error.message}`;
          }

          console.error(errorMessage);
          return throwError(errorMessage);
        })
      )
      .toPromise()
      .then(data => data || []); // Asegurar que siempre devuelva un array
  }

  add(entity: T): Promise<boolean> {
    return new Promise((resolve, reject) => {
      this.http.post<boolean>(this.apiUrl, entity)
        .pipe(take(1))
        .subscribe(
          (res: any) => resolve(res),
          (err: any) => reject(err)
        );
    });
  }

  update(updatedEntity: T): Promise<boolean> {
    const url = `${this.apiUrl}`;
  
    return new Promise((resolve, reject) => {
      this.http.put<boolean>(url, updatedEntity)
        .pipe(take(1))
        .subscribe(
          (res: any) => resolve(res),
          (err: any) => reject(err)
        );
    });
  }

  delete(id: number): Promise<boolean> {
    const url = `${this.apiUrl}/${id}`;
  
    return new Promise((resolve, reject) => {
      this.http.delete<boolean>(url)
        .pipe(take(1))
        .subscribe(
          (res: any) => resolve(res),
          (err: any) => {
            console.error('Error al eliminar:', err);
            reject(err);
          }
        );
    });
  }

  
}