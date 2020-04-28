using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELCV.Core.Entities
{
    public class State : Entity
    {
        public string StateCode { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
