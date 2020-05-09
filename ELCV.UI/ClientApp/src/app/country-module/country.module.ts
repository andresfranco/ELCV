import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CountryListComponent } from './country-list/country-list.component';
import { CountryDetailComponent } from './country-detail/country-detail.component';
import { SharedModule } from '../shared/shared.module';
import { CountryEditComponent } from './country-edit/country-edit.component';
import { routes } from './country-routes/country-routes';

@NgModule({
  declarations: [CountryListComponent, CountryDetailComponent, CountryEditComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    SharedModule
  
  ]
})
export class CountryModule { }
