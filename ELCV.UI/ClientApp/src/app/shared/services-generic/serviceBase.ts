import { throwError, Observable, of } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { catchError, map } from "rxjs/operators";

export  class ServiceBase<T> {
  public serviceUrl: string;
  public jsonHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(public http: HttpClient) {

  }
  public deleteObjectDateProperties(object:any) {
    delete object.createdDate;
    delete object.modifiedDate;
  }

  public handleError(err) {
    const errorMessage = { statusCode: "", Message: "" };
    errorMessage.statusCode = err.status.toString();
    (err.error instanceof ErrorEvent) ? errorMessage.Message = `An error occurred: ${err.error.message}`
      : errorMessage.Message = `Backend returned code ${err.error.StatusCode}: ${err.error.Message}`;
    return throwError(errorMessage);
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.serviceUrl).pipe(catchError(this.handleError));
  }

  getById(id): Observable<T>{
    const url = `${this.serviceUrl}/${id}`;
    return this.http.get<T>(url).pipe(catchError(this.handleError));
  }
  create(entity:any): Observable<T> {
    const headers = this.jsonHeaders;
    entity.id = 0;
    this.deleteObjectDateProperties(entity);
    return this.http.post<T>(this.serviceUrl, entity, { headers }).pipe(catchError(this.handleError));
  }

  update(entity:any): Observable<T> {
    const headers = this.jsonHeaders;
    return this.http.put<T>(this.serviceUrl, entity, { headers }).pipe(map(() => entity), catchError(this.handleError));                       
  }

  delete(id: number): Observable<{}> {
    const headers = this.jsonHeaders;
    const url = `${this.serviceUrl}/${id}`;
    return this.http.delete<T>(url, { headers }).pipe(catchError(this.handleError)); 
  }

 
}
