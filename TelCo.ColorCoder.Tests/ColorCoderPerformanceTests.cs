using System.Diagnostics;

namespace TelCo.ColorCoder.Tests {
    /// <summary>
    /// Performance tests to ensure operations complete within reasonable time
    /// </summary>
    public class ColorCoderPerformanceTests {
        [Fact]
        public void GetColorFromPairNumber_AllPairs_CompletesWithinReasonableTime() {
            // Arrange
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            for (int i = 1; i <= 25; i++) {
                PairToColor.GetColorFromPairNumber(i);
            }
            stopwatch.Stop();

            // Assert - Should complete in under 10ms
            Assert.True(stopwatch.ElapsedMilliseconds < 10,
                $"Operation took {stopwatch.ElapsedMilliseconds}ms, expected < 10ms");
        }

        [Fact]
        public void GetPairNumberFromColor_AllPairs_CompletesWithinReasonableTime() {
            // Arrange
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            for (int majorIndex = 0; majorIndex < ColorMap.MajorColors.Length; majorIndex++) {
                for (int minorIndex = 0; minorIndex < ColorMap.MinorColors.Length; minorIndex++) {
                    ColorPair pair = new ColorPair() {
                        MajorColor = ColorMap.MajorColors[majorIndex],
                        MinorColor = ColorMap.MinorColors[minorIndex]
                    };
                    ColorToPair.GetPairNumberFromColor(pair);
                }
            }
            stopwatch.Stop();

            // Assert - Should complete in under 10ms
            Assert.True(stopwatch.ElapsedMilliseconds < 10,
                $"Operation took {stopwatch.ElapsedMilliseconds}ms, expected < 10ms");
        }

        [Fact]
        public void GetColorCodeManual_Generation_CompletesWithinReasonableTime() {
            // Arrange
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            string manual = ReferenceManual.GetColorCodeManual();
            stopwatch.Stop();

            // Assert - Should complete in under 50ms
            Assert.True(stopwatch.ElapsedMilliseconds < 50,
                $"Manual generation took {stopwatch.ElapsedMilliseconds}ms, expected < 50ms");
            Assert.NotNull(manual);
        }
    }
}
