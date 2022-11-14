using System;


namespace Homework.Task2
{
    public class Tetrahedron : Body3D
    {
        private decimal e;

        public decimal Edge { get => e; set => e = value; }

        public Tetrahedron(decimal edge)
        {
            e = edge;
        }

        public override decimal Perimeter()
        {
            return 6 * e;
        }

        public override decimal SurfaceArea()
        {
            double _e = (double)e;
            return (decimal)(Math.Pow(_e, 2) * Math.Sqrt(3));
        }

        public override decimal Volume()
        {
            double _e = (double)e;
            return (decimal)(Math.Pow(_e, 3) * Math.Sqrt(2) / 12);
        }
    }
}
