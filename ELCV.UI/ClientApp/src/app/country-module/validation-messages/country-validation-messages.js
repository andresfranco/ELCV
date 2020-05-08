"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var CountryValidationMessages = /** @class */ (function () {
    function CountryValidationMessages() {
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
    }
    return CountryValidationMessages;
}());
exports.CountryValidationMessages = CountryValidationMessages;
//# sourceMappingURL=country-validation-messages.js.map