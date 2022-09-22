using System;


namespace Task2
{
    public class Complex
    {
        private double real;
        private double imag;

        public Complex(double real)
        {
            this.real = real;
        }

        public Complex(double real, double imag)
        {
            this.real = real;
            this.imag = imag;
        }

        public double Real { get => real; set => real = value; }
        public double Imag { get => imag; set => imag = value; }

        public double Mod { get => Math.Sqrt(real * real + imag * imag); }
        public double Arg { get => real == imag && real == 0 ? 0 : Math.Atan2(imag, real) * 180 / Math.PI; }

        public static Complex FromPolar(double abs, double arg)
        {
            double radians = Math.PI * arg / 180.0;
            return new Complex(abs * Math.Cos(radians), abs * Math.Sin(radians));
        }
    }
}
