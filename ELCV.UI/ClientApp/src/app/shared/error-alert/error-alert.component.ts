import { Component, OnInit, Input } from '@angular/core';
import { IAlertError } from './AlertError';
@Component({
  selector: 'app-error-alert',
  templateUrl: './error-alert.component.html',
  styleUrls: ['./error-alert.component.css']
})
export class ErrorAlertComponent implements OnInit {

  @Input() alertErrorMessage: IAlertError;
  constructor() { }

  ngOnInit(): void {
  }

}
