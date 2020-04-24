using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Resume : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Person Person { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<ResumeSkill> ResumeSkills { get; set; }
    }
}
