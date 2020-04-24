using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Country : Entity
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
