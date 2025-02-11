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
        }
    }
}
