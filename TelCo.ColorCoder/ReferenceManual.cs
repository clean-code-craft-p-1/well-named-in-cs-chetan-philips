using System.Text;

namespace TelCo.ColorCoder {
    /// <summary>
    /// Class to generate a reference manual for the color coding
    /// </summary>
    public static class ReferenceManual {
        /// <summary>
        /// Formats the color coding as a reference manual for wiring personnel
        /// </summary>
        /// <returns>A formatted string containing the color coding reference manual</returns>
        public static string GetColorCodeManual() {
            StringBuilder manual = new StringBuilder();
            manual.AppendLine("Color Coding Reference Manual");
            manual.AppendLine("===========================");
            manual.AppendLine();
            manual.AppendLine("Pair Number | Major Color | Minor Color");
            manual.AppendLine("------------|------------|------------");

            int totalPairs = ColorMap.MajorColors.Length * ColorMap.MinorColors.Length;

            for (int pairNumber = 1; pairNumber <= totalPairs; pairNumber++) {
                ColorPair colorPair = PairToColor.GetColorFromPairNumber(pairNumber);
                manual.AppendFormat("{0,-11} | {1,-11} | {2}\n",
                    pairNumber,
                    colorPair.MajorColor.Name,
                    colorPair.MinorColor.Name);
            }

            return manual.ToString();
        }
    }
}
