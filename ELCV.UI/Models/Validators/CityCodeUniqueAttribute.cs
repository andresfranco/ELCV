using ELCV.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELCV.UI.Models.Validators
{
    public class CityCodeUniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var currentEntity = (CityDTO)validationContext.ObjectInstance;
                if (currentEntity.Id == 0) return ValidationResult.Success;
                var _context = (ELCVContext)validationContext.GetService(typeof(ELCVContext));
                var cityEntity = _context.Cities.SingleOrDefault(c => c.CityCode == value.ToString() && c.Id != currentEntity.Id);
                if (cityEntity != null) return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage(string cityCode)
        {
            return $"City Code {cityCode} is already in use";
        }
        
    }
}
