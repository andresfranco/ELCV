using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ELCV.Core.Entities;
using ELCV.UI.Common;

namespace ELCV.UI.Models
{
    public class CountryDTO:ModelBase
    {
       
        [Required]
        public string CountryCode { get; set; }
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
