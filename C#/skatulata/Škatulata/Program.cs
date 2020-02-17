using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Škatulata
{

    struct Bod
    {

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("Pozice: [{0}, {1}]", X, Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start:");
            Bod pozice = new Bod();

            pozice.X = Console.WindowWidth/2;
            pozice.Y = Console.WindowHeight/2;

            Stack<Bod> postup = new Stack<Bod>(); // vytvoří zásobník
            postup.Push(pozice); // přidání prvku do zásobníku

            // Bod prvek_chci = postup.Pop();

            while (true) {
                // reakce na klávesy
                ConsoleKeyInfo key_info = Console.ReadKey();

                if (key_info.Key == ConsoleKey.UpArrow)
                    pozice.Y--;
                else if (key_info.Key == ConsoleKey.RightArrow)
                    pozice.X++;
                else if (key_info.Key == ConsoleKey.DownArrow)
                    pozice.Y++;
                else if (key_info.Key == ConsoleKey.LeftArrow)
                    pozice.X--;

                Console.SetCursorPosition(pozice.X, pozice.Y);
                Console.Write("X");
                Console.CursorLeft--;
            }

            Console.ReadKey(true);
        }
    }
}
