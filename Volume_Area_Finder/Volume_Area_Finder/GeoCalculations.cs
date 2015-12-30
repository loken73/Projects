using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volume_Area_Finder
{
    public class GeoCalculations
    {
        public double circle(int r)
        {
            return Math.PI * r * r;
        }

        public double triangle(int b, int h)
        {
            return (1D / 2D) * b * h;
        }

        public double rectangle (int w, int h)
        {
            return w * h;
        }

        public double square (int a)
        {
            return a * a;
        }

        public double parallel(int b, int h)
        {
            return b * h;
        }

        public double cube(int a)
        {
            return a * a * a;
        }

        public double rectPrism(int a, int b, int c)
        {
            return a * b * c;
        }

        public double cylinder(int b, int h)
        {
            return (1D/3D) * Math.PI * (b * b) * h;
        }

        public double pyramid(int b, int h)
        {
            return (1D / 3D) * b * h;
        }

        public double sphere(int r)
        {
            return (4D / 3D) * Math.PI * r * r * r;
        } 
    }
}
