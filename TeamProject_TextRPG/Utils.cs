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
                System.Console.ResetColor();

                if (isReset)
                {
                    System.Console.ResetColor();
                }
            }
        }
    }
}
