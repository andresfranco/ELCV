using System;
using System.Collections.Generic;
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
        public Country Country { get; set; }
        public string StateCode { get; set; }
        public State State { get; set; }
        public string CityCode { get; set; }
        public City City { get; set; }
    }
}
