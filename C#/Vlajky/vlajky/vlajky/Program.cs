using System;

namespace vlajky
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Ahoj. Vyber si vlajku");
            while (true)
            {
                Console.WriteLine("1 - americká");
                Console.WriteLine("2 - česká");
                Console.WriteLine("3 - německá");

                string choose = Console.ReadLine();
                Console.WriteLine("Vybral jsi si: " + choose);

                switch (choose) // swich používám takhle zbytečně proto, že ostatní nejspíš použili IFy, tak abych byl originální
                {
                    case "1":
                        printFlag("en");
                        break;
                    case "2":
                        printFlag("cz");
                        break;
                    case "3":
                        printFlag("de");
                        break;
                    default:
                        printFlag("Nope");
                        break;
                }
            }
        }

        private static void printFlag(string type)
        {
            if (type == "")
            { // jen tak, protože proč ne, alespoň je vidět nějaká snaha o ošetření vstupu
                Console.WriteLine("Error: Není vybrána vlajka!");
            }
            else if (type == "en")
            {
                Console.WriteLine(" __");
                Console.WriteLine("<__>");
                Console.WriteLine(" ||________________________________");
                Console.WriteLine(" || * * * * * * * |                |");
                Console.WriteLine(" ||  * * * * * *  |################|");
                Console.WriteLine(" || * * * * * * * |                |");
                Console.WriteLine(" ||  * * * * * *  |################|");
                Console.WriteLine(" || * * * * * * * |                |");
                Console.WriteLine(" ||---------------|################|");
                Console.WriteLine(" ||                                |");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||                                |");
                Console.WriteLine(" ||~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
            }
            else if (type == "cz")
            {
                Console.WriteLine(" __");
                Console.WriteLine("<__>");
                Console.WriteLine(" ||________________________________");
                Console.WriteLine(" ||#                               |");
                Console.WriteLine(" ||###                             |");
                Console.WriteLine(" ||######                          |");
                Console.WriteLine(" ||#########                       |");
                Console.WriteLine(" ||###########---------------------|");
                Console.WriteLine(" ||#########-----------------------|");
                Console.WriteLine(" ||######--------------------------|");
                Console.WriteLine(" ||###-----------------------------|");
                Console.WriteLine(" ||#-------------------------------|");
                Console.WriteLine(" ||~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
            }
            else if (type == "de")
            {
                Console.WriteLine(" __");
                Console.WriteLine("<__>");
                Console.WriteLine(" ||________________________________");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||////////////////////////////////|");
                Console.WriteLine(" ||////////////////////////////////|");
                Console.WriteLine(" ||////////////////////////////////|");
                Console.WriteLine(" ||--------------------------------|");
                Console.WriteLine(" ||--------------------------------|");
                Console.WriteLine(" ||--------------------------------|");
                Console.WriteLine(" ||~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
                Console.WriteLine(" ||");
            }
            else
            { // jen tak, protože proč ne, alespoň je vidět nějaká snaha o ošetření vstupu
                Console.WriteLine(" __");
                Console.WriteLine("<__>");
                Console.WriteLine(" ||________________________________");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################| ");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||################################|");
                Console.WriteLine(" ||~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine(" ||");
                Console.WriteLine("Vzdávám to, vlajku jsem nenašel :( ");
                Console.WriteLine("Špatnej výběr, zkus to znova!");
            }
        }
    }
}
