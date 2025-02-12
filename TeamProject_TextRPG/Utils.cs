namespace TeamProject_TextRPG
{
    public static class Utils
    {
        public static class Console
        {
            public static void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray, bool isReset = true, params object[] args)
            {
                System.Console.ForegroundColor = color;
                System.Console.WriteLine(text, args);

                if (isReset)
                {
                    System.Console.ResetColor();
                }
            }

            public static void Write(string text, ConsoleColor color = ConsoleColor.Gray, bool isReset = true, params object[] args)
            {
                System.Console.ForegroundColor = color;
                System.Console.Write(text, args);

                if (isReset)
                {
                    System.Console.ResetColor();
                }
            }

            public static void TypingWriteLine(string text, ConsoleColor color = ConsoleColor.Gray, int milliSecondTimeOut = 0, bool isReset = true)
            {
                TypingWrite(text, color, milliSecondTimeOut, isReset);
                System.Console.WriteLine();
            }

            public static void TypingWrite(string text, ConsoleColor color = ConsoleColor.Gray, int milliSecondTimeOut = 0, bool isReset = true)
            {
                System.Console.ForegroundColor = color;

                foreach (var iter in text)
                {
                    System.Console.Write(iter.ToString());
                    Thread.Sleep(milliSecondTimeOut);
                }

                if (isReset)
                {
                    System.Console.ResetColor();
                }
            }

            public static void ConsoleGauge(float current, float max, int duration, char fillSymbol, ConsoleColor frontColor, ConsoleColor color1 = ConsoleColor.Gray, ConsoleColor color2 = ConsoleColor.Gray, ConsoleColor color3 = ConsoleColor.Gray)
            {
                float fillAmount = current / max;

                int fillDur = (int)MathF.Round(duration * fillAmount);
                int emptyDur = duration - fillDur;
                int multiply = char.GetUnicodeCategory(fillSymbol) == System.Globalization.UnicodeCategory.OtherSymbol ? 2 : 1;

                string filledPart = fillDur > 0 ? new string(fillSymbol, fillDur) : string.Empty;
                string emptyPart = new string(' ', emptyDur * multiply);

                ConsoleColor gaugeColor;

                if (fillAmount < 0.3f)
                {
                    gaugeColor = color1;
                }
                else if (fillAmount < 0.6f)
                {
                    gaugeColor = color2;
                }
                else
                {
                    gaugeColor = color3;
                }

                Console.Write("[", frontColor);
                Console.Write("{0}{1}", gaugeColor, true, filledPart, emptyPart);
                Console.Write("]", frontColor);
            }
        }

        public static class String
        {
            public static string PadLeft(int len, string str)
            {
                foreach (char c in str)
                {
                    len -= char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter ? 2 : 1;
                }

                return len >= 0 ? str + new string(' ', len) : str;
            }

            public static string PadRight(int len, string str)
            {
                foreach (char c in str)
                {
                    len -= char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter ? 2 : 1;
                }

                return len >= 0 ? new string(' ', len) + str : str;
            }
        }
    }
}
