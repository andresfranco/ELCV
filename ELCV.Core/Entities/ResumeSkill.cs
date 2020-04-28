using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class ResumeSkill:Entity
    {
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
