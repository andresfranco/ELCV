import { Component, OnInit, AfterViewInit, OnDestroy, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription, fromEvent, merge } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { CountryService } from '../country.service';
import { Country } from '../country';
import { CountryValidationMessages } from '../validation-messages/country-validation-messages';
import { GenericValidator } from '../../shared/generic-validator/generic-validator';
import { GenericValidationMessages } from '../../shared/generic-validator/generic-validation-messages';

@Component({
  selector: 'app-country-edit',
  templateUrl: './country-edit.component.html',
  styleUrls: ['./country-edit.component.css']
})
export class CountryEditComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  pageTitle = 'Edit Country';
  errorMessage: string;
  countryForm: FormGroup;
  country: Country;
  private sub: Subscription;

  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;
  private countryValidationMessages = new CountryValidationMessages();

  constructor(private fb: FormBuilder,private route: ActivatedRoute, private router: Router, private countryService: CountryService)
  {
    this.validationMessages = this.countryValidationMessages.validationMessages;
    this.genericValidator = new GenericValidator(this.validationMessages);
  }
  ngOnInit(): void {
    this.countryForm = this.fb.group({
      countryCode: ['', [Validators.required,
      Validators.minLength(3),
      Validators.maxLength(3)]],
      countryName: ['', [Validators.required]]
    });

    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = +params.get('id');
        this.getCountry(id);
      });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));
    merge(this.countryForm.valueChanges, ...controlBlurs).pipe(
      debounceTime(800)
    ).subscribe(value => {
      this.displayMessage = this.genericValidator.processMessages(this.countryForm);
    });
  }

  getCountry(id: number): void {
    this.countryService.getCountry(id)
      .subscribe({
        next: (country: Country) => this.displayCountry(country),
        error: err => this.errorMessage = err
      });
  }

  displayCountry(country: Country): void {
    if (this.countryForm) this.countryForm.reset();
    this.country = country;
    this.country.id === 0 ? this.pageTitle = 'Add Country' : this.pageTitle = `Edit Country: ${this.country.countryName}`;
    this.countryForm.patchValue({
      countryName: this.country.countryName,
      countryCode: this.country.countryCode
    });
  }

  saveCountry(): void {
    const genericMessages = new GenericValidationMessages();
    this.errorMessage = genericMessages.generalFormValidationMessage(this.countryForm.valid);
    this.countryForm.dirty ? this.executeCountryOperations() : this.onSaveComplete();
  }

  executeCountryOperations(): void {
    const c = { ...this.country, ...this.countryForm.value };
    c.id === 0 ? this.createCountry(c) : this.updateCountry(c);
  }

  createCountry(p): void {
    this.countryService.create(p)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });
  }

  updateCountry(p): void {
    p.id = +this.route.snapshot.params.id;
    this.countryService.update(p)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });

  }

  onSaveComplete(): void {
    this.countryForm.reset();
    this.router.navigate(['/countries']);
  }

}
