using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG3Roller
{
    class Program
    {
        static void Main()
        {
            // Get user input
            SkillCheck skillCheck = SkillCheckUI.GetSkillCheckInput();

            // Calculate skill checks
            double successPercentage = SkillCheckCalculator.SimulateSkillChecks(skillCheck, 10000);

            // Display result
            SkillCheckUI.DisplaySuccessPercentage(successPercentage);
        }
    }
}
