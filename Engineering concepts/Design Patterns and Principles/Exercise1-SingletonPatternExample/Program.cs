using System;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();

            logger1.Log("First log message");
            logger2.Log("Second log message");

            if (logger1 == logger2)
                Console.WriteLine("Both logger instances are the same.");
            else
                Console.WriteLine("Different logger instances exist.");
        }
    }
}