using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ELCV.Core.Entities;
using ELCV.UI.Common;
using Microsoft.AspNetCore.Mvc;
using ELCV.UI.Models.Validators;

namespace ELCV.UI.Models
{

    public class CountryDTO:ModelBase
    {
       
        [Required]
        [CountryCodeUnique]
        
        public string CountryCode { get; set; }
        [Required]
        public string CountryName { get; set; }

        public static CountryDTO FromCountry(Country item)
        {
            return new CountryDTO()
            {
                Id = item.Id,
                CountryCode = item.CountryCode,
                CountryName = item.CountryName,
                CreatedByUser =item.CreatedByUser,
                CreatedDate = item.CreatedDate,
                ModifiedByUser =item.ModifiedByUser,
                ModifiedDate   =item.ModifiedDate
            };
        }

       
    }
}
