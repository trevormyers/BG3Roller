using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG3Roller
{
    // Class to represent a skill check
    public class SkillCheck
    {
        public int DC { get; set; }
        public AdvantageType Advantage { get; set; }
        public bool HasGuidance { get; set; }
        public bool IsProficient { get; set; }
        public int ProficiencyBonus { get; set; }
        public int AbilityModifier { get; set; }
    }
}
