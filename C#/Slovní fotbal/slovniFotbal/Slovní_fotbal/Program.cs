using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace slovni_fotbal
{
    class Program
    {

        private static Hashtable all_words = new Hashtable();
        private static List<string> used_words = new List<string>();
        public static float time_limit = 10; // čas na vymýšlení
        public static bool game_podvod = true; // jak moc chci vědět
        private static string last_word = RandomLetter();
        public static string start_letter;
        public static int player_now = 1; // aktuální hráč
        public static int player_max = 2; // defaultní počet

        public static void Main(string[] args)
        {

            LoadDictionary(); // načte slovník

            while (true) {

                start_letter = RandomLetter(); // vylosuje náhodné písmenko

                Consoler("(napiš) Počet hráčů: ", "User"); // zjistí počet hráčů
                try {player_max = int.Parse(Console.ReadLine()); }
                catch (FormatException e) {Consoler(e.ToString(), "Error"); }
                Consoler(":)", "User", true);

                while ( PlayRound() ) // zahraje kolo hry
                {

                    if (player_now < player_max) {
                        Consoler("Hráč č. " + player_now + " odehrál", "State");
                        player_now++; // krok na dalšího hráče
                    } else {
                        Consoler("Bylo odehráno jedno kolo.", "State");
                        player_now = 1;
                        if (time_limit > 4) { // na konci kola zkrátí čas
                            time_limit = time_limit - time_limit / 10;
                        }
                        Consoler("Čas se zkrátil na: " + time_limit, "State");
                    }

                    Consoler("Je na řadě hráč č." + player_now, "User", true);
                }

                all_words = new Hashtable();
                Consoler("Konec hry - prohrál hráč č." + player_now, "User");
                Consoler("Pokračujeme po stisknutí nějaký klávesy...", "User");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static bool PlayRound()
        {

            Stopwatch stopky = new Stopwatch();
            stopky.Start(); // spustí stopky

            Consoler("Napiš slovo začínající na \""+striped(start_letter)+"\": ", "User");
            string input_word = Console.ReadLine(); // přečte slovo
            stopky.Stop(); // zastaví stopky
            input_word = striped(input_word);

            TimeSpan _limit = TimeSpan.FromSeconds(time_limit);

            if (input_word == "") {  // napsal vůbec něco?
                Consoler("Sakra, nic jsi nenapsal :D", "User", true);
                return false;
            }
            if (stopky.Elapsed > _limit) {  // stihl to včas napsat?
                Consoler("Nestihl jsi to vole - končíš", "User", true);
                return false;
            }
            if (!FindWord(input_word)) { // je slovo ve slovníku?
                Consoler("Slovo "+input_word+" nenalezeno", "User", true);
                return false;
            }
            if (used_words.Contains(input_word)) { // už slovo pužil?
                Consoler("Slovo "+input_word+" už bylo použito!", "User", true);
                return false;
            }
            if (striped(input_word[0].ToString()) != striped(start_letter)) { // začíná správně ?
                Consoler("Slovo "+input_word+" nezačíná na správné písmeno - "+start_letter, "User", true);
                return false;

            }
            last_word = input_word;
            start_letter = input_word.Substring(input_word.Length - 1);
            used_words.Add(input_word);

            Consoler("Dobrý, jedeme dál!", "User", true);
            return true;

        }

        private static string RandomLetter()
        {
            Random _random = new Random();
            int num = _random.Next(0, 26);
            char let = (char)('a' + num);
            string _striped = striped(let.ToString());
            return _striped;
        }

        private static void LoadDictionary()
        {

            string cesta = "ceska_slova.txt";
            Consoler("Načítám soubor: " + cesta, "Info");

            Stopwatch stops = new Stopwatch();
            stops.Start();

            if (!File.Exists(cesta)) {
                Consoler("Soubor slovniku nebyl nalezen!", "Error");
                return;
            }

            string slovo;
            using (StreamReader sr = new StreamReader(cesta))
            {
                while ((slovo = sr.ReadLine()) != null)
                {
                    slovo = striped(slovo); // očistit znaky
                    if (!all_words.ContainsKey(slovo)) {
                        all_words.Add(slovo, "");
                    }

                }
            }

            stops.Stop();
            Consoler("Slovník načten: " + stops.Elapsed.Milliseconds + " [ms]", "Info");
        }

        private static bool FindWord(String slovo)
        {
            if (game_podvod) return true;
            slovo = striped(slovo); // očistit znaky
            return all_words.ContainsKey(slovo);
        }

        private static string striped(String slovo) {
            slovo = slovo.ToLower();
            slovo = Regex.Replace(slovo, "ě", "e");
            slovo = Regex.Replace(slovo, "š", "s");
            slovo = Regex.Replace(slovo, "č", "c");
            slovo = Regex.Replace(slovo, "ř", "r");
            slovo = Regex.Replace(slovo, "ž", "z");
            slovo = Regex.Replace(slovo, "ý", "y");
            slovo = Regex.Replace(slovo, "á", "a");
            slovo = Regex.Replace(slovo, "í", "i");
            slovo = Regex.Replace(slovo, "é", "e");
            return  slovo;
        }

        /*
         *  Consoler - lepší výpis do console
         *
         *  1.parametr - 'message' - zpráva co se má vypsat
         *  2.parametr - 'type'    - o jaký typ se jedná
         *  3.parametr - 'clear'   - má se vymazat console před vypsáním? (defaultně ne)
         *
         */
        private static void Consoler(String message, String type = "Other", bool clear = false)
        {

            /* debug_level - jak moc chci vidět
                (1-4)-(User-State-Info-Error)
            */
            int debug_level = 1;

            /* example:
             *  Consoler("Načítám soubor...", "Info"); // debug_level nejméně 3
             *  Consoler("Načítání se nepovedlo!", "Error"); // debug_level nejméně 4
             */

            if (clear && debug_level <= 2) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  >>>  F O T B A L  <<<  ");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (type == "User" && debug_level > 0) {
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
                Console.WriteLine("Consoler error: "+"Unknown type - <" + type + "> !");
                Console.WriteLine("Message: " + message);
            }
        }
    }
}
