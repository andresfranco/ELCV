using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELCV.Core.Entities
{
    public class State
    {
        [Key]
        public string StateCode { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

    }
}
