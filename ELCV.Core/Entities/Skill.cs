using System;
using System.Collections.Generic;
using System.Text;

namespace ELCV.Core.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SkillTypeId { get; set; }
        public SkillType SkillType { get; set; }
    }
}
