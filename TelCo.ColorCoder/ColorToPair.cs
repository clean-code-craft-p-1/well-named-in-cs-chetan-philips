using System;

namespace TelCo.ColorCoder {
    /// <summary>
    /// Class to handle conversion from color pair to pair number
    /// </summary>
    public static class ColorToPair {
        /// <summary>
        /// Given the two colors the function returns the pair number corresponding to them
        /// </summary>
        /// <param name="pair">Color pair with major and minor color</param>
        /// <returns>The pair number corresponding to the color pair</returns>
        public static int GetPairNumberFromColor(ColorPair pair) {
            // Find the major color in the array and get the index
            int majorIndex = -1;
            for (int i = 0; i < ColorMap.MajorColors.Length; i++) {
                if (ColorMap.MajorColors[i] == pair.MajorColor) {
                    majorIndex = i;
                    break;
                }
            }

            // Find the minor color in the array and get the index
            int minorIndex = -1;
            for (int i = 0; i < ColorMap.MinorColors.Length; i++) {
                if (ColorMap.MinorColors[i] == pair.MinorColor) {
                    minorIndex = i;
                    break;
                }
            }

            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1) {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            // Compute pair number and Return  
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * ColorMap.MinorColors.Length) + (minorIndex + 1);
        }
    }
}
