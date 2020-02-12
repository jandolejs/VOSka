using System;

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

            Console.WriteLine("Hello World!");

            Bod pozice_default = new Bod();

            pozice_default.X = Console.WindowWidth/2;
            pozice_default.Y = Console.WindowHeight/2;

            Console.SetCursorPosition(pozice_default.X, pozice_default.Y);
            Console.Write("X");

            Console.ReadKey();

        }
    }
}
