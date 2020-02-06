using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace slovni_fotbal
{
	class Program
	{

		private static Hashtable all_words = new Hashtable();
		private static TimeSpan time_limit = TimeSpan.FromSeconds(4); // čas na vymýšlení
		private static List<string> used_words = new List<string>();
		private static string last_word = RandomLetter();
        public static string start_letter;
        public static int player_now = 1;
        public static int player_max = 7; // defaultní počet

		public static void Main(string[] args)
		{

			LoadDictionary(); // načte slovník
			start_letter = RandomLetter(); // vylosuje náhodné písmenko

			Console.Write("Kolik hráčů hraje?");
			try {
				player_max = int.Parse(Console.ReadLine());
			} catch (System.FormatException e) {
			}

			while ( PlayRound() ) // zahraje kolo hry
			{

				if (player_now < player_max) {
					player_now++;
				} else {
					player_now = 1;
				}

				Console.WriteLine("Je na řadě hráč č." + player_now);
			}

			Console.WriteLine("Konec hry. Prohrál hráč č." + player_now);

		}

		private static bool PlayRound()
		{

			Stopwatch stopky = new Stopwatch();
			stopky.Start(); // spustí stopky

			Console.Write("Napiš slovo začínající na \""+start_letter+"\": ");
			string input_word = Console.ReadLine(); // přečte slovo
			stopky.Stop(); // zastaví stopky

			if (input_word == "") {  // napsal vůbec něco?
				Console.WriteLine("Sakra, nic jsi nenapsal :D");
				return false;
			}
			if (stopky.Elapsed > time_limit) {  // stihl to včas napsat?
				Console.WriteLine("Nestihls to vole");
				return false;
			}
			if (!FindWord(input_word)) { // je slovo ve slovníku?
				Console.WriteLine("Slovo nenalezeno");
				return false;
			}
			if (used_words.Contains(input_word)) { // už slovo pužil?
				Console.WriteLine("Slovo už bylo použito!");
				return false;
			}
            if (input_word[0].ToString() != start_letter) { // začíná na správné písmeno?
				Console.WriteLine("Slovo nezačíná na správné písmeno!");
				return false;
            }

			last_word = input_word;
			start_letter = input_word.Substring(input_word.Length - 1);
			used_words.Add(input_word);

			Console.WriteLine("Dobrý, jedeme dál!");
			return true;

		}

		private static string RandomLetter()
		{
			Random _random = new Random();

			int num = _random.Next(0, 26);
			char let = (char)('a' + num);
			return let.ToString();
		}

	private static void LoadDictionary()
		{

			string cesta = "ceska_slova.txt";

			Stopwatch stopky = new Stopwatch();
			stopky.Start();

			if (!File.Exists(cesta)) {
				Console.WriteLine("Soubor slovniku nebyl nalezen!");
				return;
			}

			string radka;
			using (StreamReader sr = new StreamReader(cesta))
			{
				while ((radka = sr.ReadLine()) != null)
				{
					all_words.Add(radka, "");
				}
			}

			stopky.Stop();
			Console.WriteLine("Dictionary loaded in: " + stopky.Elapsed.Milliseconds + " [ms]");
		}

		private static bool FindWord(String slovo)
		{
			return true; // !TODO: for debug only
			if (all_words.ContainsKey(slovo)) {
				return true;
			} else {
				return false;
			}
		}
	}
}
