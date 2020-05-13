import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpErrorResponse,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';

import { Observable, EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from "@angular/router";

@Injectable()
export class NotFoundInterceptor implements HttpInterceptor {
  constructor(private router: Router) {
  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request).pipe(
      catchError(error => {
        if (error instanceof HttpErrorResponse && error.status === 400) {
          this.router.navigate(['/not-found']);
          return EMPTY;
        }

        if (error instanceof HttpErrorResponse && error.status === 404) {
          this.router.navigate(['/not-found']);
          return EMPTY;
        }
        if (error instanceof HttpErrorResponse && error.status === 500) {
          this.router.navigate(['/server-error']);
          return EMPTY;
        }

        if (error instanceof HttpErrorResponse && error.status !== 200) {
          this.router.navigate(['/server-error']);
          return EMPTY;
        }

        return EMPTY;
      })
    );
  }
}
