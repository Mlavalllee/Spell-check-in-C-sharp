// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

class Program
{

    public static void Main(string[] args)
    {
        // Load data files into arrays
        String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        String[] aliceWords = Regex.Split(aliceText, @"\s+");

        //start menu
        Menu();

        // Menu loop
        void Menu()
        {
            // Exit blooean
            bool Stop = false;

            //Menu Text
            Console.WriteLine();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1: Spell Check a Word(Linear Search)");
            Console.WriteLine("2: Spell Check a Word (Binary Search)");
            Console.WriteLine("3: Spell Check Alice In Wonderland (Linear Search)");
            Console.WriteLine("4: Spell Check Alice In Wonderland (Binary Search)");
            Console.WriteLine("5: Exit");
            Console.WriteLine("Enter menu selection (1-5):");
            int Input = int.Parse(Console.ReadLine());
            string WordInput = null;

            //Menu selection statements
            switch (Input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Please input a Word");
                    WordInput = Console.ReadLine();
                    if (WordInput.Length > 0)
                    {
                        Console.WriteLine(WordSearch(dictionary, WordInput, "Linear"));
                    }
                    else
                    {
                        Console.WriteLine("Word not inputed, returning to menu");
                    }
                    break;
                case 2:
                    Console.Clear();
                    WordInput = Console.ReadLine();
                    if (WordInput.Length > 0)
                    {
                        Console.WriteLine(WordSearch(dictionary, WordInput, "Binary"));
                    }
                    else
                    {
                        Console.WriteLine("Word not inputed, returning to menu");
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(AliceSearch(dictionary, aliceWords, "Linear"));
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine(AliceSearch(dictionary, aliceWords, "Binary"));
                    break;
                case 5:
                    Console.Clear();
                    Stop = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("no option chosen, try again");
                    break;
            }
            //loop menu
            if (Stop != true)
            {
                Menu();
            }
        }
    }

    public static string WordSearch(string[] Dict, string word, string SearchType)
    {
        // Search Timer
        var Time = new Stopwatch();
        // Trim spaces and make word lowercased
        word = word.ToLower().Trim();

        // Linear Word Search
        if (SearchType == "Linear")
        {
            Time.Start();

            for (int i = 0; i < Dict.Length; i++)
            {
                if (Dict[i] == word)
                {
                    Time.Stop();
                    return $"{word} is in the dictionary at position { i.ToString()} ({Time.Elapsed})";
                }
            }
            Time.Stop();
            return $"word is not in dictionary ({Time.Elapsed})";
        }
        //Binary Word Search
        else
        {
            Time.Start();

            // Lower and Upper Index
            int Li = 0;
            int Ui = Dict.Length - 1;

            while (Ui >= Li)
            {
                int Mi = (Li + Ui) / 2;
                int check = word.CompareTo(Dict[Mi]);
                if (check == 0)
                {
                    Time.Stop();
                    return $"word is in dictionary at position { Mi.ToString()} ({Time.Elapsed})";
                }
                else if (check > 0)
                {
                    Li = Mi + 1;
                }
                else // item > than value at middle index
                {
                    Ui = Mi - 1;
                }
            }
            Time.Stop();
            return $"{word} is not in dictionary ({Time.Elapsed})";
        }
    }

    public static string AliceSearch(string[] Dict, string[] alice, string SearchType)
    {
        //Searh Timer
        var Time = new Stopwatch();
        // word counter
        int Found = 0;
        int NotFound = 0;
        int Total = 0;

        //Linear Search
        if (SearchType == "Linear")
        {
            Time.Start();
            for (int i = 0; i < alice.Length; i++)
            {
                string word = alice[i].ToLower().Trim();
                for (int x = 0; x < Dict.Length; x++)
                {
                    if (Dict[x] == word)
                    {
                        Found++;
                        break;
                    }
                }
                NotFound++;
            }
        }
        // Binary Search
        else
        {
            Time.Start();
            for (int i = 0; i < alice.Length; i++)
            {
                string word = alice[i].ToLower().Trim();
                // Lower and Upper Index
                int Li = 0;
                int Ui = Dict.Length - 1;
                while (Ui >= Li)
                {
                    int Mi = (Li + Ui) / 2;
                    int check = word.CompareTo(Dict[Mi]);
                    if (check == 0)
                    {
                        Found++;
                        break;
                    }
                    else if (check > 0)
                    {
                        Li = Mi + 1;
                    }
                    else // item > than value at middle index
                    {
                        Ui = Mi - 1;
                    }
                }
                NotFound++;
            }
        }
        Time.Stop();
        Total = NotFound - Found;
        return $"Number of words not found in the dictionary: {Total} ({Time.Elapsed})";
    }
}