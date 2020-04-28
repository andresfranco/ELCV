using ELCV.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class PersonSkill:Entity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
