// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

using System;
using System.Text.RegularExpressions;

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
                    WordInput = Console.ReadLine().ToLower().Trim();
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
                        Console.WriteLine(LinearCheckArray(dictionary, WordInput));
                    }
                    else
                    {
                        Console.WriteLine("Word not inputed, returning to menu");
                    }
                    break;
                case 3:
                    Console.Clear();
                    WordInput = Console.ReadLine();
                    if (WordInput.Length > 0)
                    {
                        Console.WriteLine(LinearCheckArray(aliceWords, WordInput));
                    }
                    else
                    {
                        Console.WriteLine("Word not inputed, returning to menu");
                    }
                    break;
                case 4:
                    Console.Clear();
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
                case 5:
                    Console.Clear();
                    WordInput = Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("no option chosen, try again");
                    break;
            }
            //loop menu
            Menu();
        }
    }

    //Linear Search
    public static string LinearCheckArray(string[] array, string word)
    {
        word = word.ToLower();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == word)
            {
                return word + " is in the dictionary at position " + i.ToString();
            }
        }
        return word + " is not in the dictionary";
    }

    //Binary Search
    public static string BinaryCheckArray(string[] array, string word)
    {
        int Li = 0;
        int Ui = array.Length;
        while (Ui >= Li)
        {
            int Mi = ((Li + Ui) / 2);
            int check = word.CompareTo(array[Mi]);
            if (check == 0)
            {
                return word + " is in the dictionary at position " + Mi.ToString();
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

        return word + " is not in the dictionary";

    }
}