using System;

namespace Craft.Net.Server
{
    public class ConsoleLogWriter : ILogProvider
    {
        public LogImportance MinimumImportance;

        public ConsoleLogWriter(LogImportance MinimumImportance)
        {
            this.MinimumImportance = MinimumImportance;
        }

        public void Log(string text, LogImportance Level)
        {
            if (Level >= MinimumImportance)
                Console.WriteLine(text);
        }
    }
}

