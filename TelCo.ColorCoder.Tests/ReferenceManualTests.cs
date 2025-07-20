using System;

namespace TelCo.ColorCoder.Tests {
    /// <summary>
    /// Tests for the ReferenceManual class
    /// </summary>
    public class ReferenceManualTests {
        [Fact]
        public void GetColorCodeManual_ReturnsNonEmptyString() {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();

            // Assert
            Assert.NotNull(manual);
            Assert.NotEmpty(manual);
        }

        [Fact]
        public void GetColorCodeManual_ContainsHeader() {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();

            // Assert
            Assert.Contains("Color Coding Reference Manual", manual);
            Assert.Contains("===========================", manual);
        }

        [Fact]
        public void GetColorCodeManual_ContainsTableHeaders() {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();

            // Assert
            Assert.Contains("Pair Number | Major Color | Minor Color", manual);
            Assert.Contains("------------|------------|------------", manual);
        }

        [Theory]
        [InlineData(1, "White", "Blue")]
        [InlineData(4, "White", "Brown")]
        [InlineData(6, "Red", "Blue")]
        [InlineData(18, "Yellow", "Green")]
        [InlineData(25, "Violet", "SlateGray")]
        public void GetColorCodeManual_ContainsExpectedPairEntries(
            int pairNumber, string majorColor, string minorColor) {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();

            // Assert
            Assert.Contains(pairNumber.ToString(), manual);
            Assert.Contains(majorColor, manual);
            Assert.Contains(minorColor, manual);
        }

        [Fact]
        public void GetColorCodeManual_ContainsAllPairNumbers() {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();

            // Assert - Check that all 25 pair numbers are present
            for (int i = 1; i <= 25; i++) {
                Assert.Contains(i.ToString(), manual);
            }
        }

        [Fact]
        public void GetColorCodeManual_FormattingIsConsistent() {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();
            string[] lines = manual.Split('\n');

            // Find the first data line (after headers)
            int dataLineIndex = 0;
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i].Contains("1") && lines[i].Contains("White") && lines[i].Contains("Blue")) {
                    dataLineIndex = i;
                    break;
                }
            }

            // Assert - Check that the format is consistent for all data lines
            for (int i = dataLineIndex; i < dataLineIndex + 25 && i < lines.Length; i++) {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                Assert.Matches(@"^\d+\s*\|\s*\w+\s*\|\s*\w+", line);
                Assert.Contains("|", line);
                Assert.Equal(2, line.Split('|').Length - 1); // Should have exactly 2 pipe characters
            }
        }

        [Fact]
        public void GetColorCodeManual_HasCorrectNumberOfDataLines() {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();
            string[] lines = manual.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            // Count data lines (skip header lines)
            int dataLines = 0;
            bool foundTableStart = false;

            foreach (string line in lines) {
                if (line.Contains("----------")) {
                    foundTableStart = true;
                    continue;
                }

                if (foundTableStart && line.Contains("|")) {
                    dataLines++;
                }
            }

            // Assert
            Assert.Equal(25, dataLines);
        }

        [Fact]
        public void GetColorCodeManual_ConsistentFormatting_NoTrailingWhitespace() {
            // Act
            string manual = ReferenceManual.GetColorCodeManual();
            string[] lines = manual.Split('\n');

            // Assert - Check no lines end with whitespace
            foreach (string line in lines) {
                if (!string.IsNullOrEmpty(line)) {
                    Assert.False(line.EndsWith(" "), $"Line should not end with whitespace: '{line}'");
                }
            }
        }
    }
}
