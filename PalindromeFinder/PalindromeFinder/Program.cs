using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer = "n";

            do
            {
                if (answer == "y") { Console.WriteLine(); }

                Console.Write("Please enter a word: ");
                string givenWord = (Console.ReadLine());

                int len = givenWord.Length - 1;

                StringBuilder re = new StringBuilder(len);

                for (; len >= 0; len--)
                {
                    re.Append(givenWord[len]);
                }

                string reverse = re.ToString();

                if (String.Equals(reverse, givenWord))
                {
                    Console.WriteLine("\r\n" + "The word {0} is a palindrome.", givenWord);
                    
                }
                else
                {
                    Console.WriteLine("\r\n" + "The word {0} is not a palindrome because backwards it spells {1}.", givenWord, reverse);
                   
                }

                Console.Write("\r\n" + "Are there any other words you would like to check. Please press 'y' to try another word. ");
                answer = Console.ReadLine();

            } while (String.Equals(answer, "y") == true);

            if (String.Equals(answer, "y") == false)
            {
                Console.WriteLine("Thank You for using Palindrome finder. Hope you have a great day!");
                Console.ReadLine();
            }
        }
    }
}