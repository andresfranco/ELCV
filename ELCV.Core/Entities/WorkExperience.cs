using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
