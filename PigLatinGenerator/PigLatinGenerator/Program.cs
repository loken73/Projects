using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = "n";

            do
            {
                int r;
                string givenWord;

                if (repeat == "y") { Console.WriteLine(); }

                Console.WriteLine("Pig Latin Generator");
                Console.WriteLine("=========================" + "\r\n");

                Console.Write("Please enter a word: ");
                givenWord = Console.ReadLine();

                if (int.TryParse(givenWord, out r) == true)
                {
                    Console.WriteLine("Please do no enter any numbers and try again." + "\r\n");
                    Console.Write("Please enter a word: ");
                    givenWord = Console.ReadLine();
                }

                foreach (var ch in givenWord)
                {
                    if (!Char.IsLetter(ch))
                    {
                        Console.WriteLine("Please enter only letters into the word. Thanks!");
                        Console.Write("Please enter a word: ");
                        givenWord = Console.ReadLine();
                    }
                }

                int len = givenWord.Length;

                int pigLength = len + 3;

                StringBuilder pigLatin = new StringBuilder(pigLength);

                for (int i = 1; i < len; i++)
                {
                    pigLatin.Append(givenWord[i]);
                }

                pigLatin.Append("-");
                pigLatin.Append(givenWord[0]);
                pigLatin.Append("ay");

                string newWord = pigLatin.ToString();

                Console.WriteLine("\r\n" + "The pig latin translation of {0} is {1}.", givenWord, newWord);

                Console.Write("\r\n" + "Would you like to try another word: ");
                repeat = Console.ReadLine();

                if (repeat != "y")
                {
                    Console.WriteLine("\r\n" + "Thank You for using the Console Pig Latin Generator. Have a great day!");
                    Console.Read();
                }

            } while (repeat == "y");
        }
    }
}