import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorAlertComponent } from './error-alert/error-alert.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [ErrorAlertComponent],
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    ErrorAlertComponent 
  ]

})
export class SharedModule { }
