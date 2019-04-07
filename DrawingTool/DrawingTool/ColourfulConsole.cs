using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingTool
{
    public enum ColorCodes
    {
        B = 0,
        R,
        G,
        C
    }
    public class ColourfulConsole
    {
        public static ColorCodes CurrentColorCode { get; set; }
        public static Dictionary<ColorCodes, ConsoleColor> colorCodeDictionary = new Dictionary<ColorCodes, ConsoleColor>()
            {
                {ColorCodes.B, ConsoleColor.Blue },
                {ColorCodes.R, ConsoleColor.Red },
                {ColorCodes.G, ConsoleColor.Green },
                {ColorCodes.C, ConsoleColor.Cyan },
            };
        public static void Write(string str, char colouredChar)
        {
            char[] strArray = str.ToArray();
            foreach (var item in strArray)
            {
                if (item == colouredChar)
                {
                    ColorCodes code = CurrentColorCode;
                    Console.BackgroundColor = colorCodeDictionary[code];
                    Console.Write(item);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write(item);
                }
            }
        }
    }
}
