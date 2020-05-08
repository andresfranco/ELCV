import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap} from 'rxjs/operators';
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
  private initializeCountry(): Country
  {
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
    if (id === 0)  return of(this.initializeCountry());
    return  this.getById(id);
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

 

}
