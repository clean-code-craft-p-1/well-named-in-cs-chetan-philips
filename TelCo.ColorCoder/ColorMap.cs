using System.Drawing;

namespace TelCo.ColorCoder {
    /// <summary>
    /// Static class containing the color maps for the 25-pair color code
    /// </summary>
    public static class ColorMap {
        /// <summary>
        /// Array of Major colors
        /// </summary>
        public static Color[] MajorColors { get; } = new Color[]
        {
            Color.White,
            Color.Red,
            Color.Black,
            Color.Yellow,
            Color.Violet
        };

        /// <summary>
        /// Array of Minor colors
        /// </summary>
        public static Color[] MinorColors { get; } = new Color[]
        {
            Color.Blue,
            Color.Orange,
            Color.Green,
            Color.Brown,
            Color.SlateGray
        };
    }
}
