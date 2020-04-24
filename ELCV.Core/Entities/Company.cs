using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
