
using System;

namespace Homework.Task2
{
    public class Sphere : Body3D
    {
        private decimal r;

        public Sphere(decimal radius)
        {
            r = radius;
        }

        public decimal Raduis { get => r; set => r = value; }
        public decimal Diameter { get => 2 * r; }

        public override decimal Perimeter()
        {
            return 0;
        }

        public override decimal SurfaceArea()
        {
            double _r = (double)r;
            return (decimal)(Math.PI * Math.Pow(_r, 2) * 4);
        }

        public override decimal Volume()
        {
            double _r = (double)r;
            return (decimal)(Math.PI * Math.Pow(_r, 3) * 4 / 3);
        }
    }
}
