using ELCV.Core.Entities;
using ELCV.UI.Common;
using ELCV.UI.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ELCV.UI.Models
{
    public class CityDTO:ModelBase
    {
        [Required]
        [CityCodeUnique]
        public string CityCode { get; set; }
        [Required]
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }
        [ValidateCityForeignKeys]
        public string ForeignKeyValidations { get; set; }
    public static CityDTO FromCity(City item)
        {
            return new CityDTO()
            {
                Id = item.Id,
                CityCode = item.CityCode,
                Name = item.Name,
                CountryId = item.CountryId,
                Country = item.Country,
                StateId =item.StateId,
                State = item.State,
                CreatedByUser = item.CreatedByUser,
                CreatedDate = item.CreatedDate,
                ModifiedByUser = item.ModifiedByUser,
                ModifiedDate = item.ModifiedDate
            };
        }
    }
}
