using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace hlavni_mesta
{
    class Program
    {

        private static List<string> seznam_mest = new List<string>();

        static void Main(string[] args) {
            LoadDictionary();
            
        }
        private static void LoadDictionary()

        {

            string cesta = "mesta.csv";
            Consoler("Načítám soubor: " + cesta, "Info");

            Stopwatch stops = new Stopwatch();
            stops.Start();

            if (!File.Exists(cesta))
            {
                Consoler("Soubor slovniku nebyl nalezen!", "Error");
                return;
            }

            string slovo;
            using (StreamReader sr = new StreamReader(cesta))
            {
                while ((slovo = sr.ReadLine()) != null)
                {
                    string[] _zeme = slovo.Split(",");
                    seznam_mest.Add(_zeme[0]); // TODO: stat a mesto jako dvojice

                }
                foreach (string _zeme in seznam_mest)
                    Console.WriteLine(_zeme.ToString()); 
            }

            stops.Stop();
            Consoler("Města načtený: " + stops.Elapsed.Milliseconds + " [ms]", "Info");
        }


        private static void Consoler(String message, String type = "Other", bool clear = false)
        {

            /* debug_level - jak moc chci vidět
                (1-4)-(User-State-Info-Error)
            */
            int debug_level = 10;

            /* example:
             *  Consoler("Načítám soubor...", "Info"); // debug_level nejméně 3
             *  Consoler("Načítání se nepovedlo!", "Error"); // debug_level nejméně 4
             */

            if (clear && debug_level <= 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  >>>  F O T B A L  <<<  ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (type == "User" && debug_level > 0)
            {
                Console.WriteLine(message);
            }
            else if (type == "State" && debug_level > 1)
            {
                Console.WriteLine(type + ": " + message);
            }
            else if (type == "Info" && debug_level > 2)
            {
                Console.WriteLine(type + ": " + message);
            }
            else if (type == "Error" && debug_level > 3)
            {
                Console.WriteLine(type + ": " + message);
            }
            else if (debug_level > 4)
            {
                Console.WriteLine("Consoler error: " + "Unknown type - <" + type + "> !");
                Console.WriteLine("Message: " + message);
            }
        }
    }
}
