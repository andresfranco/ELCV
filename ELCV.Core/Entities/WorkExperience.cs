using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class WorkExperience : Entity
    {        
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public long ResumeForeignKey { get; set; }
        public Resume Resume { get; set; }
    }
}
