namespace Dnd.Core.Tests.Model.Character.Abilities
{
    using Dnd.Core.Model.Character.Abilities;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class AbilityScoresTests
    {
        [Fact]
        public void Constructor_NoScores_UnusedPointsZero() {
            // Assign
            // Act
            var abilityScores = new CharacterAbilities();

            // Assert
            Assert.Equal(0, abilityScores.UnusedPoints);
        }

        [Fact]
        public void Constructor_WithScores_UnusedPointsZero() {
            // Assign
            var abilities = new Dictionary<AbilityType, int> { { AbilityType.Strength, 18 } };

            // Act
            var abilityScores = new CharacterAbilities(abilities);

            // Assert
            Assert.Equal(0, abilityScores.UnusedPoints);
        }

        [Fact]
        public void Constructor_AbilityScoreGiven_SetsAbility() {
            // Assign
            var abilities = new Dictionary<AbilityType, int> { { AbilityType.Strength, 18 } };

            // Act
            var abilityScores = new CharacterAbilities(abilities);

            // Assert
            Assert.Equal(18, abilityScores.Strength);
        }

        [Fact]
        public void Constructor_AbilityScoreNotGiven_SetsAbilityToDefault() {
            // Assign
            var abilities = new Dictionary<AbilityType, int> { { AbilityType.Strength, 18 } };

            // Act
            var abilityScores = new CharacterAbilities(abilities);

            // Assert
            Assert.Equal(10, abilityScores.Wisdom);
        }

        [Fact]
        public void AddPoints_PositiveAmount_IncreasesUnusedPoints() {
            // Assign
            var abilityScores = new CharacterAbilities();

            // Act
            abilityScores.AddPoints(10);

            // Assert
            Assert.Equal(10, abilityScores.UnusedPoints);
        }

        [Fact]
        public void AddPoints_Zero_DoesNotChangeUnusedPoints() {
            // Assign
            var abilityScores = new CharacterAbilities();

            // Act
            abilityScores.AddPoints(0);

            // Assert
            Assert.Equal(0, abilityScores.UnusedPoints);
        }

        [Fact]
        public void AddPoints_NegativeAmount_ThrowsException() {
            // Assign
            var abilityScores = new CharacterAbilities();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => abilityScores.AddPoints(-10));
        }
    }
}
