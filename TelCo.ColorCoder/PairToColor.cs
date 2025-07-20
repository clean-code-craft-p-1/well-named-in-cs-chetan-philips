using System;

namespace TelCo.ColorCoder {
    /// <summary>
    /// Class to handle conversion from pair number to color pair
    /// </summary>
    public static class PairToColor {
        /// <summary>
        /// Given a pair number function returns the major and minor colors in that order
        /// </summary>
        /// <param name="pairNumber">Pair number of the color to be fetched</param>
        /// <returns>ColorPair object containing the major and minor colors</returns>
        public static ColorPair GetColorFromPairNumber(int pairNumber) {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            int minorSize = ColorMap.MinorColors.Length;
            int majorSize = ColorMap.MajorColors.Length;

            if (pairNumber < 1 || pairNumber > minorSize * majorSize) {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range",
                    pairNumber));
            }

            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            // Construct the return val from the arrays
            ColorPair pair = new ColorPair() {
                MajorColor = ColorMap.MajorColors[majorIndex],
                MinorColor = ColorMap.MinorColors[minorIndex]
            };

            return pair;
        }
    }
}
