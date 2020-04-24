using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
    }
}
