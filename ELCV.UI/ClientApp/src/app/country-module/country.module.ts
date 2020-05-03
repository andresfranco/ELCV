import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CountryListComponent } from './country-list/country-list.component';
import { CountryDetailComponent } from './country-detail/country-detail.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [CountryListComponent, CountryDetailComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'countries', component: CountryListComponent},
      { path: 'countries/:id', component: CountryDetailComponent }
      
    ]),
    SharedModule
  ]
})
export class CountryModule { }
