using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Volume_Area_Finder.repeats;

namespace Volume_Area_Finder
{
    class Program : GeoCalculations
    {
        static void Main(string[] args)
        {
            string x, y, z;
            int a, b, c;
            int[] abc;
            double answer;

            GeoCalculations eq = new GeoCalculations();

            Console.WriteLine("Welcome to Volume or Area Finder!");
            Console.WriteLine("==================================" + "\r\n");

            Console.WriteLine("Now please think of a shape?");
            Thread.Sleep(2000);

            do
            {
                Console.WriteLine("\r\n" + "Got it?! Please type in yes or no.");
                x = Console.ReadLine();
            } while (!String.Equals(x, "yes"));

            Thread.Sleep(2000);

            do
            {
                Console.WriteLine("\r\n" + "Ok, Good. So is your shape 2 dimensional or 3 dimensional. Please type either 2 or 3 to continue" + "\r\n");
                z = Console.ReadLine();
            } while (!String.Equals(z, "2") && !String.Equals(z, "3")); 
            
            if (z == "2")
            {
                sides();
                y = Console.ReadLine();

                if (y == "none")
                {

                    string sh = "circle";

                    radius();
                    a = int.Parse(Console.ReadLine());
                    answer = eq.circle(a);
                    area(sh, answer);
                }
                else if (y == "3")
                {
                    string sh = "triangle";

                    @base(sh);
                    a = int.Parse(Console.ReadLine());
                    height(sh);
                    b = int.Parse(Console.ReadLine());
                    answer = eq.triangle(a, b);
                    area(sh, answer);
                }
                else if (y == "4")
                {
                    Console.WriteLine("Are all of it's interior angles 90 degree?");
                    z = Console.ReadLine();

                    if (z == "no")
                    {
                        string sh = "parallelogram";

                        @base(sh);
                        a = int.Parse(Console.ReadLine());
                        height(sh);
                        b = int.Parse(Console.ReadLine());
                        answer = eq.parallel(a, b);
                        area(sh, answer);
                    }
                    else
                    {
                        Console.WriteLine("Are all it's sides equal?");
                        y = Console.ReadLine();

                        if (y == "yes")
                        {
                            string sh = "square";

                            Console.WriteLine("Please tell me the length of one of its sides.");
                            c = int.Parse(Console.ReadLine());
                            answer = eq.square(c);
                            area(sh, answer);

                        }
                        else
                        {
                            string sh = "rectangle";

                            @base(sh);
                            a = int.Parse(Console.ReadLine());
                            height(sh);
                            b = int.Parse(Console.ReadLine());
                            answer = eq.rectangle(a, b);
                            area(sh, answer);
                        }
                    }
                }
            }
            else
            {
                sides();
                y = Console.ReadLine();

                if (y == "none")
                {
                    string sh = "sphere";

                    radius();
                    a = int.Parse(Console.ReadLine());
                    answer = eq.sphere(a);
                    volume(sh, answer);

                }
                else if (y ==  "2")
                {
                    string sh = "cylinder";

                    radius();
                    a = int.Parse(Console.ReadLine());
                    height(sh);
                    b = int.Parse(Console.ReadLine());
                    answer = eq.cylinder(a, b);
                    volume(sh, answer);
                }
                else if (y == "5")
                {
                    string sh = "pyramid";

                    @base(sh);
                    a = int.Parse(Console.ReadLine());
                    height(sh);
                    b = int.Parse(Console.ReadLine());
                    answer = eq.pyramid(a, b);
                    volume(sh, answer);
                }
                else if (y == "6")
                {
                    sidesEquals();
                    z = Console.ReadLine();

                    if ( z == "no")
                    {
                        string sh = "rectangular prism";

                        @base(sh);
                        a = int.Parse(Console.ReadLine());
                        height(sh);
                        b = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please give me its depth");
                        c = int.Parse(Console.ReadLine());
                        answer = eq.rectPrism(a, b, c);
                        volume(sh, answer);
                    }
                    else
                    {
                        string sh = "cube";

                        Console.WriteLine("Please tell me the length of one of its sides.");
                        a = int.Parse(Console.ReadLine());
                        answer = eq.cube(a);
                        volume(sh, answer);
                    }

                }
            } 

        }
    }
}
