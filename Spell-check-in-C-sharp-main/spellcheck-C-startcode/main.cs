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
            // Search Timer
            var Time = new Stopwatch();

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
            int WordPos = 0;
            int WordNotFound = 0;
            //Menu selection statements
            switch (Input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Please input a Word");
                    WordInput = Console.ReadLine();
                    if (WordInput.Length > 0)
                    {
                        Console.WriteLine("Linear search started");
                        Time.Start();
                        WordPos = LinearSearch(dictionary, WordInput);
                        Time.Stop();
                        if (WordPos > 0)
                        {
                            Console.WriteLine($"Word found at position {WordPos} in the dictionary ({Time.Elapsed})");
                        }
                        else
                        {
                            Console.WriteLine($"Word is not in the dictionary ({Time.Elapsed})");
                        }
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
                        Console.WriteLine("Binary search started");
                        Time.Start();
                        WordPos = BinarySearch(dictionary, WordInput);
                        Time.Stop();
                        if (WordPos > 0)
                        {
                            Console.WriteLine($"Word found at position {WordPos} in the dictionary ({Time.Elapsed})");
                        }
                        else
                        {
                            Console.WriteLine($"Word is not in the dictionary ({Time.Elapsed})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Word not inputed, returning to menu");
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Linear search started");
                    Time.Start();
                    for (int i = 0; i < aliceWords.Length; i++)
                    {
                        string alice = aliceWords[i];
                        WordPos = LinearSearch(dictionary, alice);
                        if (WordPos == -1)
                        {
                            WordNotFound++;
                        }
                    }
                    Time.Stop();
                    Console.WriteLine($"number of words not found in dictionary:{WordNotFound} ({Time.Elapsed})");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Binary search started");
                    Time.Start();
                    for (int i = 0; i < aliceWords.Length; i++)
                    {
                        string alice = aliceWords[i];
                        WordPos = BinarySearch(dictionary, alice);
                        if (WordPos == -1)
                        {
                            WordNotFound++;
                        }
                    }
                    Time.Stop();
                    Console.WriteLine($"number of words not found in dictionary:{WordNotFound} ({Time.Elapsed})");
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

    static int LinearSearch(string[] dict, string word)
    {
        // Trim spaces and make word lowercased
        word = word.ToLower().Trim();
        for (int i = 0; i < dict.Length; i++)
        {
            if (dict[i] == word)
            {
                return i;
            }
        }
        return -1;
    }

    static int BinarySearch(string[] dict, string word)
    {
        // Trim spaces and make word lowercased
        word = word.ToLower().Trim();
        int Li = 0;
        int Ui = dict.Length - 1;
        while (Ui >= Li)
        {
            int Mi = ((Li + Ui) / 2);
            int check = word.CompareTo(dict[Mi]);
            if (check == 0)
            {
                return Mi;
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
        return -1;
    }
}