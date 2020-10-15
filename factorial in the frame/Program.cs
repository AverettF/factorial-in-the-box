using System;
using System.Threading;

namespace factorial_in_the_frame
{
    class Program
    {           
        
        
        //ВАЖНО:Данное решение "оптимизированно",но не является лучшим вариантом для проверки,т.к. довольно запутанно.
        //Поэтому было бы лучше выбрать прошлую версию

        public const int time = 10;

        static void Main(string[] args)
        {
                Console.Write("Введите какой нужно расчитать фактариал:\n!");
                uint fact = ReadFact();

                string line1, line2, line3;
                FindLineBox(fact,out line1, out line2, out line3);
                PrintColorBox(line1, line2, line3);
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

        static void FindLineBox(uint fact,out string line1, out string line2, out string line3)
        {
            string strFact = Convert.ToString(fact);

            line1 = SaveLine("╔", "═", "╗", strFact);
            line2 = SaveNumberLine("║", strFact, "║", strFact);
            line3 = SaveLine("╚", "═", "╝", strFact);
        }

        static string SaveLine(string leftLine, string middleLine, string rightLine, string strFact)
        {
            string line;

            line = GetMiddleWidth(strFact);
            line += leftLine;
            for (int i = 0; i < strFact.Length; i++)
            {
                line += middleLine;
            }
            line += rightLine;

            return line;
        }

        static string SaveNumberLine(string leftLine, string middleLine, string rightLine, string strFact)
        {
            string line;
            line = GetMiddleWidth(strFact);
            line += $"║{middleLine}║";
            return line;

        }

        static string GetMiddleWidth(string strFact)
        {
            string line = "";
            for (int i = 0; i < (Console.WindowWidth - strFact.Length + 2) / 2; i++)
            {
                line += " ";
            }
            return line;
        }

        static void PrintColorBox(string line1,string line2,string line3)
        {
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                PrintBox(line1, line2, line3);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                PrintBox(line1, line2, line3);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                PrintBox(line1, line2, line3);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                PrintBox(line1, line2, line3);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                PrintBox(line1, line2, line3);
                Thread.Sleep(time);

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                PrintBox(line1, line2, line3);
                Thread.Sleep(time);
            }
        }

        static void PrintBox(string line1, string line2, string line3)
        {
            MiddleHeight();
            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
        }

        static void MiddleHeight()
        {
            for (int i = 0; i < Console.WindowHeight / 2 - 2; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
