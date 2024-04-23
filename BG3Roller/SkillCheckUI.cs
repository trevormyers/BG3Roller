using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG3Roller
{
    // Class responsible for console user interface
    public class SkillCheckUI
    {
        public static SkillCheck GetSkillCheckInput()
        {
            Console.Write("Enter DC value: ");
            int dc = int.Parse(Console.ReadLine());

            Console.Write("Do you have Advantage (a), Disadvantage (d), or None (n)? ");
            char advantageInput = char.Parse(Console.ReadLine().ToLower());
            AdvantageType advantage = GetAdvantageType(advantageInput);

            Console.Write("Do you have Guidance (y/n)? ");
            bool hasGuidance = Console.ReadLine().ToLower() == "y";

            Console.Write("Are you proficient (y/n)? ");
            bool isProficient = Console.ReadLine().ToLower() == "y";

            int proficiencyBonus = 0;
            if (isProficient)
            {
                Console.Write("Enter your proficiency bonus: ");
                proficiencyBonus = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter your ability modifier: ");
            int abilityModifier = int.Parse(Console.ReadLine());

            return new SkillCheck
            {
                DC = dc,
                Advantage = advantage,
                HasGuidance = hasGuidance,
                IsProficient = isProficient,
                ProficiencyBonus = proficiencyBonus,
                AbilityModifier = abilityModifier
            };
        }

        public static void DisplaySuccessPercentage(double successPercentage)
        {
            Console.WriteLine($"Success Percentage: {successPercentage:F2}%");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Helper method to convert user input to AdvantageType
        public static AdvantageType GetAdvantageType(char input)
        {
            switch (input)
            {
                case 'a':
                    return AdvantageType.Advantage;
                case 'd':
                    return AdvantageType.Disadvantage;
                default:
                    return AdvantageType.None;
            }
        }
    }
}
