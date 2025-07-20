using System;
using System.Drawing;

namespace TelCo.ColorCoder.Tests {
    /// <summary>
    /// Tests for the PairToColor class
    /// </summary>
    public class PairToColorTests {
        [Theory]
        [InlineData(1, "White", "Blue")]
        [InlineData(4, "White", "Brown")]
        [InlineData(5, "White", "SlateGray")]
        [InlineData(6, "Red", "Blue")]
        [InlineData(18, "Yellow", "Green")]
        [InlineData(23, "Violet", "Green")]
        [InlineData(25, "Violet", "SlateGray")]
        public void GetColorFromPairNumber_WithValidPairNumber_ReturnsCorrectColorPair(
            int pairNumber, string expectedMajorColorName, string expectedMinorColorName) {
            // Act
            ColorPair colorPair = PairToColor.GetColorFromPairNumber(pairNumber);

            // Assert
            Assert.Equal(Color.FromName(expectedMajorColorName), colorPair.MajorColor);
            Assert.Equal(Color.FromName(expectedMinorColorName), colorPair.MinorColor);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void GetColorFromPairNumber_WithPairNumberBelowRange_ThrowsArgumentOutOfRangeException(int pairNumber) {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                PairToColor.GetColorFromPairNumber(pairNumber));
        }

        [Theory]
        [InlineData(26)]
        [InlineData(100)]
        public void GetColorFromPairNumber_WithPairNumberAboveRange_ThrowsArgumentOutOfRangeException(int pairNumber) {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                PairToColor.GetColorFromPairNumber(pairNumber));
        }

        [Fact]
        public void GetColorFromPairNumber_WithBoundaryValues_ReturnsCorrectColorPairs() {
            // Arrange - Boundary values
            int minPairNumber = 1;
            int maxPairNumber = 25;

            // Act & Assert - Min boundary
            ColorPair minPair = PairToColor.GetColorFromPairNumber(minPairNumber);
            Assert.Equal(Color.White, minPair.MajorColor);
            Assert.Equal(Color.Blue, minPair.MinorColor);

            // Act & Assert - Max boundary
            ColorPair maxPair = PairToColor.GetColorFromPairNumber(maxPairNumber);
            Assert.Equal(Color.Violet, maxPair.MajorColor);
            Assert.Equal(Color.SlateGray, maxPair.MinorColor);
        }

        [Fact]
        public void GetColorFromPairNumber_WithAllValidPairNumbers_DoesNotThrow() {
            // Act & Assert - Verify all 25 pairs are valid
            for (int pairNumber = 1; pairNumber <= 25; pairNumber++) {
                var exception = Record.Exception(() => PairToColor.GetColorFromPairNumber(pairNumber));
                Assert.Null(exception);
            }
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void GetColorFromPairNumber_WithExtremeValues_ThrowsArgumentOutOfRangeException(int pairNumber) {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                PairToColor.GetColorFromPairNumber(pairNumber));
        }
    }
}
