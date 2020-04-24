using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELCV.Core.Entities
{
   public class City
    {
        [Key]
        public string CityCode { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
    }
}
