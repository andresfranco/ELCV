import { Routes } from "@angular/router";
import { CountryListComponent } from "../country-list/country-list.component";
import { CountryDetailComponent } from "../country-detail/country-detail.component";
import { CountryEditComponent } from "../country-edit/country-edit.component";


export const routes: Routes = [
  { path: 'countries', component: CountryListComponent, data: { routeName: "countryList" } },
  { path: 'countries/:id', component: CountryDetailComponent, data: { routeName: "countryDetail" } },
  { path: 'countries/:id/edit', component: CountryEditComponent, data: { routeName: "countryEdit" } }
];
