import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { Country } from './country';
import { ServiceBase } from '../shared/services-generic/ServiceBase';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends ServiceBase<Country>{
 ;
  constructor(http: HttpClient) {
    super(http);
    this.serviceUrl = 'api/countries';
  }

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.serviceUrl).pipe(catchError(this.handleError));
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
   return  this.getById(id, this.initializeCountry);
  }

  createCountry(country: Country): Observable<Country>
  {
    const headers = this.jsonHeaders;
    country.id = 0;
    this.deleteObjectDateProperties(country);
    return this.http.post<Country>(this.serviceUrl, country, { headers})
           .pipe(catchError(this.handleError) );
  }

  deleteCountry(id: number): Observable<{}> {
    const headers = super.jsonHeaders;
    const url = `${this.serviceUrl}/${id}`;
    return this.http.delete<Country>(url, { headers })
      .pipe(
        tap(data => console.log('deleteCountry: ' + id)),
        catchError(this.handleError)
      );
  }

  updateCountry(country: Country): Observable<Country> {
    const headers = super.jsonHeaders;
    return this.http.put<Country>(this.serviceUrl, country, { headers })
      .pipe(
        tap(() => console.log('updateCountry: ' + country.id)),
        // Return the Country on an update
        map(() => country),
        catchError(this.handleError)
      );
  }

  

}
