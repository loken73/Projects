using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int a_count = 0;
            int e_count = 0;
            int i_count = 0;
            int o_count = 0;
            int u_count = 0;

            Console.WriteLine("This is Vowel Finder");
            Console.WriteLine("======================");

            Console.Write("\r\n" + "Please enter a word: ");
            string givenWord = Console.ReadLine();

            foreach (var ch in givenWord)
            {
                if (!Char.IsLetter(ch))
                {
                    Console.WriteLine("Please enter a word with only alphabetic characters.");
                    Console.Write("\r\n" + "Please enter a word: ");
                    givenWord = Console.ReadLine();
                }

                switch (ch)
                {
                    case 'a':
                        count++;
                        a_count++;
                        break;
                    case 'e':
                        count++;
                        e_count++;
                        break;
                    case 'i':                          
                        count++;
                        i_count++;
                        break;
                    case 'o':
                        count++;
                        o_count++;
                        break;
                    case 'u':
                        count++;
                        u_count++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("\r\n" + "The word {0} had {1} total vowels: ", givenWord, count);
            Console.WriteLine("A: {0}", a_count);
            Console.WriteLine("E: {0}", e_count);
            Console.WriteLine("I: {0}", i_count);
            Console.WriteLine("O: {0}", o_count);
            Console.WriteLine("U: {0}", u_count);
            Console.ReadLine();
        }
    }
}
