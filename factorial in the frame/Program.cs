using System;
using System.Threading;

namespace factorial_in_the_frame
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Введите какой нужно расчитать фактариал:");
                int fact = ReadFact();

                ColorChange(fact);
        }

        static int ReadFact()
        {
            bool isSuccess;
            int fact;

            do
            {
                isSuccess = int.TryParse(Console.ReadLine(), out fact);

                if (isSuccess == false)
                    Console.WriteLine("Неверный ввод");

            } while (!isSuccess);

            return FindFact(fact);
        }

        static int FindFact(int endFact)
        {
            int fact = 1;
            for (int i = 1; i <= endFact; i++)
            {
                fact *= i;
            }
            return fact;
        }

        static void ColorChange(int fact)
        {
            while (true)
            {
                int time = 1000;

                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                PrintBox(fact);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                PrintBox(fact);
                Thread.Sleep(time);

            }

            static void PrintBox(int fact)
        {
            string strFact = Convert.ToString(fact);

            PrintLine("╔", "═", "╗",strFact);
            PrintNumberLine("║",strFact, "║");
            PrintLine("╚", "═", "╝", strFact);
        }

        static void PrintLine(string leftLine,string middleLine,string rightLine,string strFact)
        {

            Console.Write(leftLine);
            for (int i = 0; i < strFact.Length; i++)
            {
                Console.Write(middleLine);
            }
            Console.WriteLine(rightLine);
        }

        static void PrintNumberLine(string leftLine, string middleLine, string rightLine)
        {
            Console.WriteLine($"║{middleLine}║");;
        }
        }
    }
}
