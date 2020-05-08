import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorAlertComponent } from './error-alert/error-alert.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDeleteModalComponent } from './confirm-delete-modal/confirm-delete-modal.component';


@NgModule({
  declarations: [ErrorAlertComponent, ConfirmDeleteModalComponent],
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    ErrorAlertComponent,
    ConfirmDeleteModalComponent
  ]

})
export class SharedModule { }
