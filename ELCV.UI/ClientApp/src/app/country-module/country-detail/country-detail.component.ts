import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Country} from '../country';
import { CountryService } from '../country.service';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.css']
})
export class CountryDetailComponent implements OnInit
{
  pageTitle = 'Country Detail';
  errorMessage = '';
  country: Country | undefined;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private countryService: CountryService) {
  }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get('id');
    if (param) {
      const id = +param;
      this.getCountry(id);
    }
  }

  getCountry(id: number) {
    this.countryService.getCountry(id).subscribe({
      next: country => this.country = country,
      error: err => this.errorMessage = err
    });
  }

  onBack(): void {
    this.router.navigate(['/countries']);
  }

}

 
  




  
