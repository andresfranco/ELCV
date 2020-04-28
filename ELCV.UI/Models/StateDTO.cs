using ELCV.Core.Entities;
using ELCV.UI.Common;
using ELCV.UI.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ELCV.UI.Models
{
    public class StateDTO: ModelBase
    {
        [Required]
        [StateCodeUnique]
        public string StateCode { get; set; }
        [Required]
        public string Name { get; set; }
        public Country Country { get; set; }

        [RequiredCountryId]
        public int CountryId { get; set; }
      
        public static StateDTO FromState(State item)
        {
            return new StateDTO()
            {
                Id = item.Id,
                StateCode =item.StateCode,
                Name = item.Name,
                CountryId = item.CountryId,
                Country = item.Country,
                CreatedByUser = item.CreatedByUser,
                CreatedDate = item.CreatedDate,
                ModifiedByUser = item.ModifiedByUser,
                ModifiedDate = item.ModifiedDate
            };
        }


    }
}
