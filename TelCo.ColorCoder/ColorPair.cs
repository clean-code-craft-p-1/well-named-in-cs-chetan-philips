using System.Drawing;

namespace TelCo.ColorCoder {
    /// <summary>
    /// Data type defined to hold the two colors of color pair
    /// </summary>
    public class ColorPair {
        /// <summary>
        /// Major color of the pair
        /// </summary>
        public Color MajorColor { get; set; }

        /// <summary>
        /// Minor color of the pair
        /// </summary>
        public Color MinorColor { get; set; }

        /// <summary>
        /// String representation of the color pair
        /// </summary>
        /// <returns>String in the format "MajorColor:X, MinorColor:Y"</returns>
        public override string ToString() {
            return string.Format("MajorColor:{0}, MinorColor:{1}",
                MajorColor.Name, MinorColor.Name);
        }
    }
}
