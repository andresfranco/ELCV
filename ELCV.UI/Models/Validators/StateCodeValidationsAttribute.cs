using ELCV.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELCV.UI.Models.Validators
{
    public class StateCodeUnique : ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var currentEntity = (StateDTO)validationContext.ObjectInstance;
                if (currentEntity.Id == 0) return ValidationResult.Success;
                var _context = (ELCVContext)validationContext.GetService(typeof(ELCVContext));
                var stateEntity = _context.States.SingleOrDefault(s => s.StateCode == value.ToString() && s.Id != currentEntity.Id);
                if (stateEntity != null) return new ValidationResult(GetErrorMessage(value.ToString()));
            }

            return ValidationResult.Success;
        }


        public string GetErrorMessage(string stateCode)
        {
            return $"State Code {stateCode} is already in use";
        }
    }
}
