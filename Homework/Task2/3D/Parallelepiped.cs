
namespace Homework.Task2
{
    public class Parallelepiped : Body3D
    {
        private decimal l;
        private decimal w;
        private decimal h;

        public Parallelepiped(decimal length, decimal width, decimal height)
        {
            l = length;
            w = width;
            h = height;
        }
        public decimal Length { get => l; set => l = value; }
        public decimal Width { get => w; set => w = value; }
        public decimal Height { get => h; set => h = value; }

        public override decimal Perimeter()
        {
           return 4 * (l + w + h);
        }

        public override decimal SurfaceArea()
        {
            return 2 * (l * w + w * h + l * h);
        }

        public override decimal Volume()
        {
            return l * w * h;
        }
    }
}
