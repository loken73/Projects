using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volume_Area_Finder
{
    public static class repeats
    {

        public static void sides()
        {
            Console.WriteLine("Does your shape have any sides? If so please let me know how many or just write none indicating 0 sides.");
            //string y = Console.ReadLine();
        }

        public static void circleR()
        {
            //Console.WriteLine("\r\n" + "What is the radius of your circle?");
            //int a = int.Parse(Console.ReadLine());
            //int answer = eq.sphere(a);
            //Console.WriteLine("Your triangle has an area of " + answer);
            //Console.ReadLine();
        }

        public static void @base(string sh)
        {
            Console.WriteLine("What is the base of your {0}.", sh);
        }

        public static void height(string sh)
        {
            Console.WriteLine("What is the height of your {0}.", sh);
        }

        public static void area(string h, double a)
        {
            Console.WriteLine("The area of your {0} is {1}", h, a);
            Console.ReadLine();
        }

        public static void radius()
        {
            Console.WriteLine("\r\n" + "What is the radius?");
        }

        public static void volume(string h, double a)
        {
            Console.WriteLine("The volume of your {0} is {1}", h, a);
            Console.ReadLine();
        }

        public static void sidesEquals()
        {
            Console.WriteLine("Are all it's sides equal?");
        }
    }
}
