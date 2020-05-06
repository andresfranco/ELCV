import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { Country } from './country';

@Injectable({
  providedIn: 'root'
})
export class CountryService{

  private countriesUrl ='api/countries'
  constructor(private http: HttpClient) { }

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.countriesUrl)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      )

  }
  private initializeCountry(): Country {
    // Return an initialized object
    return {
      id: 0,
      createdByUser: null,
      createdDate: null,
      modifiedByUser: null,
      modifiedDate: null,
      countryCode: null,
      countryName: null
    };
  }
  getCountry(id: number): Observable<Country> {
    if (id === 0) {
      return of(this.initializeCountry());
    }
    const url = `${this.countriesUrl}/${id}`;
    return this.http.get<Country>(url)
      .pipe(
        tap(data => console.log('getCountry: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  createCountry(country: Country): Observable<Country> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    country.id = 0;
    this.deleteObjectDateProperties(country);
    return this.http.post<Country>(this.countriesUrl, country, { headers })
      .pipe(
        tap(data => console.log('createCountry: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  deleteCountry(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.countriesUrl}/${id}`;
    return this.http.delete<Country>(url, { headers })
      .pipe(
        tap(data => console.log('deleteCountry: ' + id)),
        catchError(this.handleError)
      );
  }

  updateCountry(country: Country): Observable<Country> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Country>(this.countriesUrl, country, { headers })
      .pipe(
        tap(() => console.log('updateCountry: ' + country.id)),
        // Return the Country on an update
        map(() => country),
        catchError(this.handleError)
      );
  }

  private deleteObjectDateProperties(object:any) {
    delete object.createdDate; 
    delete object.modifiedDate;
  }

  private handleError(err) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

}
