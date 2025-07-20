using System.Drawing;

namespace TelCo.ColorCoder.Tests {
    /// <summary>
    /// Tests for the ColorPair class
    /// </summary>
    public class ColorPairTests {
        [Fact]
        public void ToString_WithValidColors_ReturnsCorrectFormat() {
            // Arrange
            ColorPair colorPair = new ColorPair() {
                MajorColor = Color.White,
                MinorColor = Color.Blue
            };

            // Act
            string result = colorPair.ToString();

            // Assert
            Assert.Equal("MajorColor:White, MinorColor:Blue", result);
        }

        [Theory]
        [InlineData("Red", "Blue")]
        [InlineData("White", "Orange")]
        [InlineData("Black", "Green")]
        public void ToString_WithDifferentColors_ReturnsCorrectFormat(string majorColorName, string minorColorName) {
            // Arrange
            Color majorColor = Color.FromName(majorColorName);
            Color minorColor = Color.FromName(minorColorName);

            ColorPair colorPair = new ColorPair() {
                MajorColor = majorColor,
                MinorColor = minorColor
            };

            // Act
            string result = colorPair.ToString();

            // Assert
            Assert.Equal($"MajorColor:{majorColorName}, MinorColor:{minorColorName}", result);
        }

        [Fact]
        public void ToString_WithEmptyColors_HandlesGracefully() {
            // Arrange
            ColorPair colorPair = new ColorPair() {
                MajorColor = Color.Empty,
                MinorColor = Color.Empty
            };

            // Act
            string result = colorPair.ToString();

            // Assert
            Assert.Contains("0", result); // Color.Empty has ARGB value of 0
        }

        [Fact]
        public void ColorPair_Properties_CanBeSetAndRetrieved() {
            // Arrange
            Color expectedMajor = Color.Red;
            Color expectedMinor = Color.Blue;

            // Act
            ColorPair colorPair = new ColorPair() {
                MajorColor = expectedMajor,
                MinorColor = expectedMinor
            };

            // Assert
            Assert.Equal(expectedMajor, colorPair.MajorColor);
            Assert.Equal(expectedMinor, colorPair.MinorColor);
        }
    }
}
