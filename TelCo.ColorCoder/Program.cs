using System;
using System.Drawing;

namespace TelCo.ColorCoder {
    /// <summary>
    /// Main program class that demonstrates the color coding functionality
    /// </summary>
    internal static class Program {
        /// <summary>
        /// Main entry point for the application
        /// </summary>
        /// <param name="args">Command line arguments</param>
        private static void Main(string[] args) {
            Console.WriteLine("25-Pair Color Code Reference Application");
            Console.WriteLine("=======================================");
            Console.WriteLine();

            // Define sample pair numbers
            const int PairWhiteBrown = 4;
            const int PairBlackOrange = 10;
            const int PairVioletSlateGray = 25; // Maximum pair number (5 major × 5 minor colors)

            // Demonstrate pair number to color mapping
            Console.WriteLine("Pair Number to Color Mapping Examples:");
            DemonstratePairToColor(PairWhiteBrown);       // White/Brown
            DemonstratePairToColor(PairBlackOrange);      // Black/Orange
            DemonstratePairToColor(PairVioletSlateGray);  // Violet/SlateGray
            Console.WriteLine();

            // Demonstrate color to pair number mapping
            Console.WriteLine("Color to Pair Number Mapping Examples:");
            DemonstrateColorToPair(Color.Yellow, Color.Green); // Expected: 18
            DemonstrateColorToPair(Color.Red, Color.Blue);     // Expected: 6
            Console.WriteLine();

            // Display the reference manual
            Console.WriteLine("Reference Manual:");
            Console.WriteLine(ReferenceManual.GetColorCodeManual());

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstrates the pair number to color mapping
        /// </summary>
        /// <param name="pairNumber">The pair number to convert</param>
        private static void DemonstratePairToColor(int pairNumber) {
            try {
                ColorPair colorPair = PairToColor.GetColorFromPairNumber(pairNumber);
                Console.WriteLine($"Pair Number: {pairNumber} => Major Color: {colorPair.MajorColor.Name}, Minor Color: {colorPair.MinorColor.Name}");
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Demonstrates the color to pair number mapping
        /// </summary>
        /// <param name="majorColor">The major color</param>
        /// <param name="minorColor">The minor color</param>
        private static void DemonstrateColorToPair(System.Drawing.Color majorColor, System.Drawing.Color minorColor) {
            try {
                ColorPair colorPair = new ColorPair() { MajorColor = majorColor, MinorColor = minorColor };
                int pairNumber = ColorToPair.GetPairNumberFromColor(colorPair);
                Console.WriteLine($"Major Color: {majorColor.Name}, Minor Color: {minorColor.Name} => Pair Number: {pairNumber}");
            } catch (ArgumentException ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
