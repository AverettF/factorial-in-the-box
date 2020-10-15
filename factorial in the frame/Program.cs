using System;
using System.Threading;

namespace factorial_in_the_frame
{
    class Program
    {
        public const int time = 300;

        static void Main(string[] args)
        {
                Console.Write("Введите какой нужно расчитать фактариал:\n!");
                uint fact = ReadFact();

                PrintColorBox(fact);
        }

        static uint ReadFact()
        {
            bool isSuccess;
            uint fact;

            do
            {
                isSuccess = uint.TryParse(Console.ReadLine(), out fact);

                if (isSuccess == false ) 
                    Console.WriteLine("Неверный ввод");

            } while (!isSuccess);

            return FindFact(fact);
        }

        static uint FindFact(uint endFact)
        {
            if (endFact == 0)
                return 1;
            return endFact * FindFact(endFact - 1);
        }

        static void PrintColorBox(uint fact)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                PrintBox(fact);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                PrintBox(fact);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                PrintBox(fact);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                PrintBox(fact);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                PrintBox(fact);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                PrintBox(fact);
                Thread.Sleep(time);
            }
        }
        static void PrintBox(uint fact)
        {
            string strFact = Convert.ToString(fact);

            MiddleHeight();
            Middle(strFact);
            PrintLine("╔", "═", "╗", strFact);//╔═══════╗
            Middle(strFact);
            PrintNumberLine("║",strFact, "║");//║ Fact  ║
            Middle(strFact);
            PrintLine("╚", "═", "╝", strFact);//╚═══════╝
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

        static void MiddleHeight()
        {
            for (int i = 0; i < Console.WindowHeight / 2 - 2; i++) 
            {
                Console.WriteLine();
            }
        }

        static void Middle(string strFact)
        {
            for (int i = 0; i < (Console.WindowWidth - strFact.Length + 2) / 2; i++) 
            {
                Console.Write(" ");
            }
        }

    }
}
