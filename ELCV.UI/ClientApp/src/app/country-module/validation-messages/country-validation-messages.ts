export class CountryValidationMessages
{
  public validationMessages = {
    countryCode:
    {
      required: 'Country Code is required ',
      minlength: 'Country Code must be 3 characters',
      maxlength: 'Country Code must be 3 characters'
    },
    countryName:
    {
      required: 'Country Name is required.'
    }
  };

}
