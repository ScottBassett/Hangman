using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to Scott's amazing game of European Countries Hangman!\n\n" +
                               "*********************************************\n");
            Console.ResetColor();

            //Get random word stuff
            string[] words = { "Germany", "France", "Italy", "Greece", "Poland", "Sweden", "Portugal", "Belgium", "Croatia", "Norway", 
                "Finland", "Belarus", "Ukraine", "Spain", "Romania", "Austria"};
            Random random = new Random();
            int randomIndex = random.Next(0, words.Length);
            string selectedWord = words[randomIndex];
            string upperCaseWord = selectedWord.ToUpper();
            string hiddenWord = "";
            int guesses = 0;

            for (int i = 0; i < selectedWord.Length; i++)
            {
                hiddenWord += "*";   
            }
           
            List<char> usedLetters = new List<char>();
            //Guessing stuff
            while(hiddenWord.Contains("*"))
            {
                Console.WriteLine($"Word: {string.Join(" ", hiddenWord.ToCharArray())}");
                Console.Write("Guess a letter >> ");
                char guessedLetter = char.Parse(Console.ReadLine().ToUpper());
                if (!usedLetters.Contains(guessedLetter))
                {
                    usedLetters.Add(guessedLetter);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"\nYou've already guessed {guessedLetter}!\n");
                    Console.ResetColor();
                    continue;
                }
                bool containsLetter = false;
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (upperCaseWord[i] == guessedLetter)
                    {
                        hiddenWord = hiddenWord.Remove(i,1);
                        hiddenWord = hiddenWord.Insert(i, selectedWord[i].ToString());
                        containsLetter = true;
                    }
                }
                if (containsLetter == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYes! {guessedLetter} is in the word\n");
                    guesses++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry, {guessedLetter} is not in the word\n");
                    guesses++;
                }
                Console.ResetColor(); 
            }   
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Congratulations, you win! The country was {selectedWord}\nIt took you {guesses} guesses.");

            string rainbowBeats = "Please play again!";
            int lastColour = -1;
            for (int i = 0; i < rainbowBeats.Length; i++)
            {
                int randomColour = random.Next(9, 15);
                while (randomColour == lastColour)
                {
                    randomColour = random.Next(9, 15);
                }
                lastColour = randomColour;
                Console.ForegroundColor = (ConsoleColor)randomColour;
                Console.Write(rainbowBeats[i]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

  

