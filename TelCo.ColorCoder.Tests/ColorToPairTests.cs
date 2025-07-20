using System;
using System.Drawing;

namespace TelCo.ColorCoder.Tests {
    /// <summary>
    /// Tests for the ColorToPair class
    /// </summary>
    public class ColorToPairTests {
        [Theory]
        [InlineData("White", "Blue", 1)]
        [InlineData("White", "Brown", 4)]
        [InlineData("White", "SlateGray", 5)]
        [InlineData("Red", "Blue", 6)]
        [InlineData("Yellow", "Green", 18)]
        [InlineData("Violet", "Green", 23)]
        [InlineData("Violet", "SlateGray", 25)]
        public void GetPairNumberFromColor_WithValidColors_ReturnsCorrectPairNumber(
            string majorColorName, string minorColorName, int expectedPairNumber) {
            // Arrange
            ColorPair colorPair = new ColorPair() {
                MajorColor = Color.FromName(majorColorName),
                MinorColor = Color.FromName(minorColorName)
            };

            // Act
            int pairNumber = ColorToPair.GetPairNumberFromColor(colorPair);

            // Assert
            Assert.Equal(expectedPairNumber, pairNumber);
        }

        [Theory]
        [InlineData("Aqua", "Blue")]
        [InlineData("White", "Purple")]
        [InlineData("Pink", "Green")]
        public void GetPairNumberFromColor_WithInvalidColors_ThrowsArgumentException(
            string majorColorName, string minorColorName) {
            // Arrange
            ColorPair colorPair = new ColorPair() {
                MajorColor = Color.FromName(majorColorName),
                MinorColor = Color.FromName(minorColorName)
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                ColorToPair.GetPairNumberFromColor(colorPair));
        }

        [Fact]
        public void GetPairNumberFromColor_WithBoundaryValues_ReturnsCorrectPairNumbers() {
            // Arrange - Boundary values
            ColorPair minPair = new ColorPair() {
                MajorColor = Color.White,
                MinorColor = Color.Blue
            };

            ColorPair maxPair = new ColorPair() {
                MajorColor = Color.Violet,
                MinorColor = Color.SlateGray
            };

            // Act & Assert - Min boundary
            int minPairNumber = ColorToPair.GetPairNumberFromColor(minPair);
            Assert.Equal(1, minPairNumber);

            // Act & Assert - Max boundary
            int maxPairNumber = ColorToPair.GetPairNumberFromColor(maxPair);
            Assert.Equal(25, maxPairNumber);
        }

        [Fact]
        public void GetPairNumberFromColor_WithNullColorPair_ThrowsNullReferenceException() {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() =>
                ColorToPair.GetPairNumberFromColor(null));
        }

        [Fact]
        public void GetPairNumberFromColor_WithAllValidColorCombinations_ReturnsValidPairNumbers() {
            // Act & Assert - Test all valid combinations
            int expectedPairNumber = 1;

            for (int majorIndex = 0; majorIndex < ColorMap.MajorColors.Length; majorIndex++) {
                for (int minorIndex = 0; minorIndex < ColorMap.MinorColors.Length; minorIndex++) {
                    ColorPair colorPair = new ColorPair() {
                        MajorColor = ColorMap.MajorColors[majorIndex],
                        MinorColor = ColorMap.MinorColors[minorIndex]
                    };

                    int actualPairNumber = ColorToPair.GetPairNumberFromColor(colorPair);
                    Assert.Equal(expectedPairNumber, actualPairNumber);
                    expectedPairNumber++;
                }
            }
        }

        [Theory]
        [InlineData("Magenta", "Blue")]
        [InlineData("White", "Silver")]
        [InlineData("Cyan", "Maroon")]
        public void GetPairNumberFromColor_WithUnknownMajorOrMinorColors_ThrowsArgumentException(
            string majorColorName, string minorColorName) {
            // Arrange
            ColorPair colorPair = new ColorPair() {
                MajorColor = Color.FromName(majorColorName),
                MinorColor = Color.FromName(minorColorName)
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                ColorToPair.GetPairNumberFromColor(colorPair));
        }
    }
}
