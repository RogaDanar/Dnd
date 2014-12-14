namespace Dnd.Core.Tests.Model.Abilities
{
    using Dnd.Core.Model.Character.Abilities;
    using Xunit;
    using Xunit.Extensions;

    public class AbilityTests
    {
        [Fact]
        public void ImplicitOperator_AssignToInt_ReturnsScore() {
            int score = new Ability(AbilityType.Strength, 10);

            Assert.Equal(10, score);
        }

        [Theory]
        [InlineData(1, -5)]
        [InlineData(2, -4)]
        [InlineData(3, -4)]
        [InlineData(4, -3)]
        [InlineData(5, -3)]
        [InlineData(6, -2)]
        [InlineData(7, -2)]
        [InlineData(8, -1)]
        [InlineData(9, -1)]
        [InlineData(10, 0)]
        [InlineData(11, 0)]
        [InlineData(12, 1)]
        [InlineData(13, 1)]
        [InlineData(14, 2)]
        [InlineData(15, 2)]
        [InlineData(16, 3)]
        [InlineData(17, 3)]
        [InlineData(18, 4)]
        [InlineData(19, 4)]
        [InlineData(20, 5)]
        [InlineData(99, 44)]
        public void Modifier_GivenScore_ReturnsCorrectValue(int score, int expectedModifier) {
            var attr = new Ability(AbilityType.Strength, score);

            Assert.Equal(expectedModifier, attr.Modifier);
        }

        [Fact]
        public void Modifier_WithScore0_ThrowsException() {
            var attr = new Ability(AbilityType.Strength, 0);
            Assert.Throws<System.ArgumentException>(() => attr.Modifier);
        }

        [Fact]
        public void Increase_With2_IncreasesScoreWith2() {
            // Assign
            var attr = new Ability(AbilityType.Strength, 10);

            // Act
            attr.Increase(2);

            // Assert
            Assert.Equal(12, attr.Score);
        }

        [Fact]
        public void Increase_With2_IncreasesBaseScoreWith2() {
            // Assign
            var attr = new Ability(AbilityType.Strength, 10);

            // Act
            attr.Increase(2);

            // Assert
            Assert.Equal(12, attr.BaseScore);
        }

        [Fact]
        public void Increase_With2_IncreasesModifierWith1() {
            // Assign
            var attr = new Ability(AbilityType.Strength, 10);
            var before = attr.Modifier;

            // Act
            attr.Increase(2);

            // Assert
            Assert.Equal(before + 1, attr.Modifier);
        }

        [Fact]
        public void Decrease_With2_DecreasesScoreWith2() {
            // Assign
            var attr = new Ability(AbilityType.Strength, 10);

            // Act
            attr.Decrease(2);

            // Assert
            Assert.Equal(8, attr.Score);
        }

        [Fact]
        public void Decrease_With2_DecreasesBaseScoreWith2() {
            // Assign
            var attr = new Ability(AbilityType.Strength, 10);

            // Act
            attr.Decrease(2);

            // Assert
            Assert.Equal(8, attr.BaseScore);
        }

        [Fact]
        public void Decrease_Above0_ReturnsTrue() {
            var attr = new Ability(AbilityType.Strength, 10);

            Assert.True(attr.Decrease(2));
        }

        [Fact]
        public void Decrease_Below0_ReturnsFalse() {
            var attr = new Ability(AbilityType.Strength, 10);

            Assert.False(attr.Decrease(12));
        }
    }
}
