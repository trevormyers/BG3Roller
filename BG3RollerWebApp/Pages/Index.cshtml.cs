using BG3Roller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BG3RollerWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            // Collect form data
            int dc = int.Parse(Request.Form["dc"]);
            AdvantageType advantage = Enum.Parse<AdvantageType>(Request.Form["advantage"]);
            bool hasGuidance = Request.Form["guidance"] == "on";
            bool isProficient = Request.Form["proficient"] == "on";
            int proficiencyBonus = isProficient ? int.Parse(Request.Form["proficiencyBonus"]) : 0;
            int abilityModifier = int.Parse(Request.Form["abilityModifier"]);

            // Create SkillCheck object
            SkillCheck skillCheck = new SkillCheck
            {
                DC = dc,
                Advantage = advantage,
                HasGuidance = hasGuidance,
                IsProficient = isProficient,
                ProficiencyBonus = proficiencyBonus,
                AbilityModifier = abilityModifier
            };

            // Run simulation
            double successPercentage = SkillCheckCalculator.SimulateSkillChecks(skillCheck, 10000);

            // Display result in the textarea
            ViewData["SuccessPercentage"] = successPercentage;

            return Page();
        }
    }
}
