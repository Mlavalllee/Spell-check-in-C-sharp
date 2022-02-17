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

        //loop
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
                        Console.WriteLine(LinearCheckArray(dictionary, WordInput));
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
                        Console.WriteLine(BinaryCheckArray(dictionary, WordInput));
                    }
                    else
                    {
                        Console.WriteLine("Word not inputed, returning to menu");
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(AliceLinearCheckArray(dictionary, aliceWords));
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine(BinaryCheckArray(dictionary, aliceText));
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

    //Linear Search a word
    public static string LinearCheckArray(string[] array, string word)
    {
        //Searh Timer
        var Time = new Stopwatch();
        TimeSpan TotalTime = Time.Elapsed;
        Time.Start();

        // Trim spaces and make word lowercased
        word = word.ToLower().Trim();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == word)
            {
                Time.Stop();
                TotalTime = Time.Elapsed;
                return $"{word} is in the dictionary at position { i.ToString()} ({TotalTime})";
            }
        }
        Time.Stop();
        TotalTime = Time.Elapsed;
        return $"word is not in dictionary ({TotalTime})";
    }

    //Binary Search a word
    public static string BinaryCheckArray(string[] array, string word)
    {
        // Search Timer
        var Time = new Stopwatch();
        TimeSpan TotalTime = Time.Elapsed;
        Time.Start();

        // Trim spaces and make word lowercased
        word = word.ToLower().Trim();

        // Lower and Upper Index
        int Li = 0;
        int Ui = array.Length;

        while (Ui >= Li)
        {
            int Mi = ((Li + Ui) / 2);
            int check = word.CompareTo(array[Mi]);
            if (check == 0)
            {
                Time.Stop();
                TotalTime = Time.Elapsed;
                return $"word is in dictionary at position { Mi.ToString()} ({TotalTime})";
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
        TotalTime = Time.Elapsed;
        return $"{word} is not in dictionary ({TotalTime})";

    }

    public static string AliceLinearCheckArray(string[] array, string[] alice)
    {
        //Searh Timer
        var Time = new Stopwatch();
        TimeSpan TotalTime = Time.Elapsed;
        Time.Start();

        // word counter
        int Found = 0;
        int NotFound = 0;
        int Total = 0;

        for (int i = 0; i < alice.Length; i++)
        {
            string word = alice[i].ToLower().Trim();
            for (int x = 0; x < array.Length; x++)
            {
                if (array[x] == word)
                {
                    Found++;
                    break;
                }
            }
            NotFound++;
        }
        Time.Stop();
        TotalTime = Time.Elapsed;
        Total = NotFound - Found;
        return $"Number of words not found in the dictionary: {Total} ({TotalTime})";
    }







}