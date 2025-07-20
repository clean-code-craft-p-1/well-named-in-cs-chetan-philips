using System.Drawing;

namespace TelCo.ColorCoder.Tests {
    /// <summary>
    /// Integration tests that verify the overall system behavior
    /// </summary>
    public class ColorCoderIntegrationTests {
        [Fact]
        public void RoundTripConversion_PairToColorToNumber_ShouldReturnOriginalNumber() {
            // Test round-trip conversion for all valid pair numbers
            for (int originalPairNumber = 1; originalPairNumber <= 25; originalPairNumber++) {
                // Act - Convert pair number to color, then back to pair number
                ColorPair colorPair = PairToColor.GetColorFromPairNumber(originalPairNumber);
                int resultPairNumber = ColorToPair.GetPairNumberFromColor(colorPair);

                // Assert
                Assert.Equal(originalPairNumber, resultPairNumber);
            }
        }

        [Fact]
        public void RoundTripConversion_ColorToPairToColor_ShouldReturnOriginalColors() {
            // Test with a few representative color combinations
            var testCases = new[]
            {
                new { Major = Color.White, Minor = Color.Blue },
                new { Major = Color.Red, Minor = Color.Orange },
                new { Major = Color.Black, Minor = Color.Green },
                new { Major = Color.Yellow, Minor = Color.Brown },
                new { Major = Color.Violet, Minor = Color.SlateGray }
            };

            foreach (var testCase in testCases) {
                // Arrange
                ColorPair originalPair = new ColorPair() {
                    MajorColor = testCase.Major,
                    MinorColor = testCase.Minor
                };

                // Act - Convert color to pair number, then back to color
                int pairNumber = ColorToPair.GetPairNumberFromColor(originalPair);
                ColorPair resultPair = PairToColor.GetColorFromPairNumber(pairNumber);

                // Assert
                Assert.Equal(originalPair.MajorColor, resultPair.MajorColor);
                Assert.Equal(originalPair.MinorColor, resultPair.MinorColor);
            }
        }

        [Fact]
        public void SystemConstants_ShouldSupportExactly25Pairs() {
            // Act
            int totalPairs = ColorMap.MajorColors.Length * ColorMap.MinorColors.Length;

            // Assert
            Assert.Equal(25, totalPairs);
        }
    }
}