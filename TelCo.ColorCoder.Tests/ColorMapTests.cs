using System.Drawing;

namespace TelCo.ColorCoder.Tests {
    /// <summary>
    /// Tests for the ColorMap class
    /// </summary>
    public class ColorMapTests {
        [Fact]
        public void MajorColors_ShouldContainFiveColors() {
            // Act
            int colorCount = ColorMap.MajorColors.Length;

            // Assert
            Assert.Equal(5, colorCount);
        }

        [Fact]
        public void MinorColors_ShouldContainFiveColors() {
            // Act
            int colorCount = ColorMap.MinorColors.Length;

            // Assert
            Assert.Equal(5, colorCount);
        }

        [Theory]
        [InlineData(0, "White")]
        [InlineData(1, "Red")]
        [InlineData(2, "Black")]
        [InlineData(3, "Yellow")]
        [InlineData(4, "Violet")]
        public void MajorColors_ShouldContainCorrectColorsInOrder(int index, string expectedColorName) {
            // Act
            Color color = ColorMap.MajorColors[index];

            // Assert
            Assert.Equal(Color.FromName(expectedColorName), color);
        }

        [Theory]
        [InlineData(0, "Blue")]
        [InlineData(1, "Orange")]
        [InlineData(2, "Green")]
        [InlineData(3, "Brown")]
        [InlineData(4, "SlateGray")]
        public void MinorColors_ShouldContainCorrectColorsInOrder(int index, string expectedColorName) {
            // Act
            Color color = ColorMap.MinorColors[index];

            // Assert
            Assert.Equal(Color.FromName(expectedColorName), color);
        }
    }
}
