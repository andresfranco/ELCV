using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int ZipCode { get; set; }
        public string Countrycode { get; set; }
        public string StateCode { get; set; }
        public string CityCode { get; set; }
    }
}
