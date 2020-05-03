import { Component, OnInit } from '@angular/core';
import { CountryService } from '../country.service';
import { Country } from '../country'
@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css']
})
export class CountryListComponent implements OnInit {

  pageTitle = "Country List"
  countries: Country[] = [];
  errorMessage = '';

  constructor(private countryService: CountryService) { }

  ngOnInit(): void {

    this.countryService.getCountries().subscribe({

      next: countries => {
        this.countries = countries;
      },
      error: err => this.errorMessage = err
    });
  }

}
