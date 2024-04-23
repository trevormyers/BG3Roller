using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG3Roller
{
    // Class responsible for calculations
    public class SkillCheckCalculator
    {
        public static int SimulateSkillCheck(SkillCheck skillCheck)
        {
            Random random = new Random();

            // Roll a 20-sided die
            int initialRoll = random.Next(1, 21);

            // Roll a 4-sided die for guidance bonus if applicable
            int guidanceRoll = skillCheck.HasGuidance ? random.Next(1, 5) : 0;

            // Calculate the overall result of the skill check
            int overallResult;

            if (skillCheck.Advantage == AdvantageType.Disadvantage)
            {
                int secondRoll = random.Next(1, 21);
                overallResult = Math.Min(initialRoll, secondRoll);
            }
            else if (skillCheck.Advantage == AdvantageType.Advantage)
            {
                int secondRoll = random.Next(1, 21);
                overallResult = Math.Max(initialRoll, secondRoll);
            }
            else
            {
                overallResult = initialRoll;
            }

            overallResult += (skillCheck.IsProficient ? skillCheck.ProficiencyBonus : 0) + guidanceRoll + skillCheck.AbilityModifier;

            return overallResult;
        }

        public static double SimulateSkillChecks(SkillCheck skillCheck, int numberOfSimulations)
        {
            int successfulAttempts = 0;

            for (int i = 0; i < numberOfSimulations; i++)
            {
                if (SimulateSkillCheck(skillCheck) >= skillCheck.DC)
                {
                    successfulAttempts++;
                }
            }

            return (double)successfulAttempts / numberOfSimulations * 100;
        }
    }
}
