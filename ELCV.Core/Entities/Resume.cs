using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
