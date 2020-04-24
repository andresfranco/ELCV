using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class PersonSkill:Entity
    {
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public long SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
