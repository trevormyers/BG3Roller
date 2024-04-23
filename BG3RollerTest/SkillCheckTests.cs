using BG3Roller;

namespace BG3RollerTest
{
    [TestClass]
    public class SkillCheckTests
    {
        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 15,
                Advantage = AdvantageType.Advantage,
                HasGuidance = true,
                IsProficient = true,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult2()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 10,
                Advantage = AdvantageType.Advantage,
                HasGuidance = true,
                IsProficient = true,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult3()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 19,
                Advantage = AdvantageType.Advantage,
                HasGuidance = true,
                IsProficient = true,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult4()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 12,
                Advantage = AdvantageType.Disadvantage,
                HasGuidance = false,
                IsProficient = true,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult5()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 11,
                Advantage = AdvantageType.Disadvantage,
                HasGuidance = true,
                IsProficient = false,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult6()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 16,
                Advantage = AdvantageType.Disadvantage,
                HasGuidance = true,
                IsProficient = true,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult7()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 8,
                Advantage = AdvantageType.Disadvantage,
                HasGuidance = false,
                IsProficient = false,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillCheck_ShouldReturnValidResult8()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 5,
                Advantage = AdvantageType.None,
                HasGuidance = true,
                IsProficient = true,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            // Act
            int result = SkillCheckCalculator.SimulateSkillCheck(skillCheck);

            // Assert
            Assert.IsTrue(result >= 0, "Result should be greater than or equal to 0");
        }

        [TestMethod]
        public void SimulateSkillChecks_ShouldReturnValidPercentage()
        {
            // Arrange
            SkillCheck skillCheck = new SkillCheck
            {
                DC = 15,
                Advantage = AdvantageType.Advantage,
                HasGuidance = true,
                IsProficient = true,
                ProficiencyBonus = 2,
                AbilityModifier = 3
            };

            int numberOfSimulations = 10000;

            // Act
            double successPercentage = SkillCheckCalculator.SimulateSkillChecks(skillCheck, numberOfSimulations);

            // Assert
            Assert.IsTrue(successPercentage >= 0 && successPercentage <= 100, "Success percentage should be between 0 and 100");
        }

        [TestMethod]
        public void GetAdvantageType_ShouldReturnCorrectEnumValue()
        {
            // Arrange & Act
            AdvantageType advantageType = SkillCheckUI.GetAdvantageType('a');

            // Assert
            Assert.AreEqual(AdvantageType.Advantage, advantageType, "AdvantageType should be Advantage");
        }

        [TestMethod]
        public void GetAdvantageType_ShouldReturnCorrectEnumValue2()
        {
            // Arrange & Act
            AdvantageType advantageType = SkillCheckUI.GetAdvantageType('d');

            // Assert
            Assert.AreEqual(AdvantageType.Disadvantage, advantageType, "AdvantageType should be Disadvantage");
        }

        [TestMethod]
        public void GetAdvantageType_ShouldReturnCorrectEnumValue3()
        {
            // Arrange & Act
            AdvantageType advantageType = SkillCheckUI.GetAdvantageType('n');

            // Assert
            Assert.AreEqual(AdvantageType.None, advantageType, "AdvantageType should be None");
        }
    }
}