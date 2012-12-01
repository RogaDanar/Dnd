//namespace Dnd.Tests.Core
//{
//    using Dnd.Core;
//    using Xunit;

//    public class AttributeTests
//    {
//        [Fact]
//        public void AssignInt_SetsBaseScore() {
//            Attribute attr = 10;

//            Assert.Equal(attr.BaseScore, 10);
//        }

//        [Fact]
//        public void AssignToInt_ReturnsScore() {
//            int i = new Attribute(10);

//            Assert.Equal(i, 10);
//        }

//        [Fact]
//        public void Modifier_WithScore10_Returns0() {
//            Attribute attr = 10;

//            Assert.Equal(attr.Modifier, 0);
//        }

//        [Fact]
//        public void Modifier_WithScore11_Returns0() {
//            Attribute attr = 11;

//            Assert.Equal(attr.Modifier, 0);
//        }

//        [Fact]
//        public void Modifier_WithScore18_Returns4() {
//            Attribute attr = 18;

//            Assert.Equal(attr.Modifier, 4);
//        }

//        [Fact]
//        public void Modifier_WithScore4_ReturnsMinus3() {
//            Attribute attr = 4;

//            Assert.Equal(attr.Modifier, -3);
//        }

//        [Fact]
//        public void Modifier_WithScore0_ThrowsException() {
//            Attribute attr = 0;

//            Assert.Throws<System.ArgumentException>(() => attr.Modifier);
//        }

//        [Fact]
//        public void Modifier_WithScore99_Returns44() {
//            Attribute attr = 99;

//            Assert.Equal(attr.Modifier, 44);
//        }

//        [Fact]
//        public void Increase_With2_IncreasesScoreWith2() {
//            Attribute attr = 10;
//            attr.Increase(2);

//            Assert.Equal(attr.Score, 12);
//        }

//        [Fact]
//        public void Increase_With2_IncreasesBaseScoreWith2() {
//            Attribute attr = 10;
//            attr.Increase(2);

//            Assert.Equal(attr.BaseScore, 12);
//        }

//        [Fact]
//        public void Increase_With2_IncreasesModifierWith1() {
//            Attribute attr = 10;
//            var before = attr.Modifier;
//            attr.Increase(2);

//            Assert.Equal(attr.Modifier, before + 1);
//        }

//        [Fact]
//        public void Decrease_With2_DecreasesScoreWith2() {
//            Attribute attr = 10;
//            attr.Decrease(2);

//            Assert.Equal(attr.Score, 8);
//        }

//        [Fact]
//        public void Decrease_With2_DecreasesBaseScoreWith2() {
//            Attribute attr = 10;
//            attr.Decrease(2);

//            Assert.Equal(attr.BaseScore, 8);
//        }

//        [Fact]
//        public void Decrease_Above0_ReturnsTrue() {
//            Attribute attr = 10;

//            Assert.True(attr.Decrease(2));
//        }

//        [Fact]
//        public void Decrease_Below0_ReturnsFalse() {
//            Attribute attr = 10;

//            Assert.False(attr.Decrease(12));
//        }
//    }
//}
