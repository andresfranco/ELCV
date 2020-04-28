using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELCV.UI.Models.Validators
{
    public class ValidateCityForeignKeys:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentEntity =(CityDTO) validationContext.ObjectInstance;
            if (currentEntity.CountryId == 0 && currentEntity.StateId != 0) return new ValidationResult(GetErrorMessage("CountryId"));
            if (currentEntity.StateId == 0 && currentEntity.CountryId != 0 ) return new ValidationResult(GetErrorMessage("StateId"));
            if (currentEntity.StateId == 0 && currentEntity.CountryId == 0) return new ValidationResult(GetErrorMessage("CountryId-StateId"));
            return ValidationResult.Success;

        }

        private string GetErrorMessage(string attributeName)
        {
            string ErrorMessage = "";
            if (attributeName == "CountryId") ErrorMessage= "CountryId is required";
            if (attributeName == "StateId") ErrorMessage = "StateId is required";
            if (attributeName == "CountryId-StateId") ErrorMessage = "The following fields are required:CountryId,StateId";
            return ErrorMessage;
        }

        

    }
}
