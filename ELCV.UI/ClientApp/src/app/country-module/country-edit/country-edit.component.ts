import { Component, OnInit, AfterViewInit, OnDestroy, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, FormArray, Validators, FormControlName } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription, fromEvent, merge } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { CountryService } from '../country.service';
import { Country } from '../country';
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

  // Use with the generic validation message class
  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;


  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private countryService: CountryService) {

    // Defines all of the validation messages for the form.
    // These could instead be retrieved from a file or database.
    this.validationMessages = {
      countryCode: {
        required: 'Country Code is required ',
        minlength: 'Country Code must be 3 characters',
        maxlength: 'Country Code must be 3 characters'
      },
      countryName: {
        required: 'Country Name is required.'
      }
    };

    // Define an instance of the validator for use with this form,
    // passing in this form's set of validation messages.
    this.genericValidator = new GenericValidator(this.validationMessages);
  }
  ngOnInit(): void {
    this.countryForm = this.fb.group({
      countryCode: ['', [Validators.required,
      Validators.minLength(3),
      Validators.maxLength(3)]],
      countryName: ['', [Validators.required]]
    });

    // Read the product Id from the route parameter
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

    // Merge the blur event observable with the valueChanges observable
    // so we only need to subscribe once.
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

    // Update the data on the form
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
    this.countryService.createCountry(p)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });
  }

  updateCountry(p): void {
    p.id = +this.route.snapshot.params.id;
    this.countryService.updateCountry(p)
      .subscribe({
        next: () => this.onSaveComplete(),
        error: err => this.errorMessage = err
      });

  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.countryForm.reset();
    this.router.navigate(['/countries']);
  }

}
