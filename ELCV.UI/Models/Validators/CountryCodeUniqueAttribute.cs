using ELCV.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ELCV.UI.Models.Validators
{
    public class CountryCodeUniqueAttribute : ValidationAttribute
    {
       
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value !=null)
            {
                var currentEntity = (CountryDTO)validationContext.ObjectInstance;
                var _context = (ELCVContext)validationContext.GetService(typeof(ELCVContext));
                var countryEntity = _context.Countries.SingleOrDefault(c => c.CountryCode == value.ToString() && c.Id != currentEntity.Id);
                if (countryEntity != null) return new ValidationResult(GetErrorMessage(value.ToString()));
            }
           
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string countryCode)
        {
            return $"Country Code {countryCode} is already in use";
        }
    }
}
