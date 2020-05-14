import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap, map} from 'rxjs/operators';
import { Country } from './country';
import { ServiceBase } from '../shared/services-generic/ServiceBase';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CountryService extends ServiceBase<Country>{
 ;
  constructor(http: HttpClient,router: Router) {
    super(http,router);

    this.serviceUrl = 'api/countries';
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


}
