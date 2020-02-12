using System;

namespace Škatulata
{

	struct Bod
	{

		public int X { get; set; }
		public int Y { get; set; }

		public override string ToString()
		{
			return X + " " + Y;
		}
	}



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
