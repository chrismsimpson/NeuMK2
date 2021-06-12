//
//
//

using System;

using static System.Console;

namespace Neu
{
    public static partial class ConsoleHelpers
    {
        public static void WriteLine(
            int indent, 
            String message)
        {
            if (indent < 10 && indent % 2 == 0)
            {
                var str = new String(' ', indent);

                Console.WriteLine($"{str}{message}");

                return;
            }

            throw new Exception();
        }

        ///

        public static void WriteColoredLine(
            String message, 
            ConsoleColor color)
        {
            WriteColoredLine(0, message, color);   
        }

        public static void WriteColoredLine(
            int indent,
            String message, 
            ConsoleColor color)
        {
            var og = ForegroundColor;

            ForegroundColor = color;

            WriteLine(indent, message);

            ForegroundColor = og;
        }

        ///

        public static void WriteBlueLine(
            String message)
        {
            WriteColoredLine(0, message, ConsoleColor.Blue);
        }

        public static void WriteBlueLine(
            int indent,
            String message)
        {
            WriteColoredLine(indent, message, ConsoleColor.Blue);
        }

        ///

        public static void WriteYellowLine(
            String message)
        {
            WriteColoredLine(0, message, ConsoleColor.Yellow);
        }

        public static void WriteYellowLine(
            int indent,
            String message)
        {
            WriteColoredLine(indent, message, ConsoleColor.Yellow);
        }

        ///

        public static void WriteRedLine(
            String message)
        {
            WriteColoredLine(0, message, ConsoleColor.Red);
        }

        public static void WriteRedLine(
            int indent,
            String message)
        {
            WriteColoredLine(indent, message, ConsoleColor.Red);
        }

        ///

        public static void WriteGreenLine(
            String message)
        {
            WriteColoredLine(0, message, ConsoleColor.Green);
        }

        public static void WriteGreenLine(
            int indent,
            String message)
        {
            WriteColoredLine(indent, message, ConsoleColor.Green);
        }
    }
}