using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Address:Entity
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int ZipCode { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }
}
