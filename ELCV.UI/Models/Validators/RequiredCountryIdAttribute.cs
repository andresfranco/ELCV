using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELCV.UI.Models.Validators
{
    public class RequiredCountryIdAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentEntity = (StateDTO)validationContext.ObjectInstance;
            if (currentEntity.CountryId == 0) return new ValidationResult(GetErrorMessage("CountryId"));
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string fieldValue)
        {
            return "CountryId is required";
        }
    }
}
