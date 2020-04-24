using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Skill : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public SkillType SkillType { get; set; }

        public List<ResumeSkill> ResumeSkills { get; set; }
    }
}
