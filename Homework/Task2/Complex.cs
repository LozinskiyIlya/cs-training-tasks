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


        public static Complex operator -(Complex c) =>
            new Complex(-c.Real, -c.Imag);

        public static Complex operator -(Complex a, Complex b) =>
            new Complex(a.Real - b.Real, a.Imag - b.Imag);

        public static Complex operator +(Complex a, Complex b) =>
           new Complex(a.Real + b.Real, a.Imag + b.Imag);

        public static Complex operator *(Complex a, Complex b) =>
            new Complex(a.Real * b.Real - a.Imag * b.Imag, a.Real * b.Imag + a.Imag * b.Real);


        public static Complex operator /(Complex a, Complex b)
        {
            var denom = b.Real * b.Real + b.Imag * b.Imag;
            return new Complex((a.Real * b.Real + a.Imag * b.Imag) / denom, (a.Real * b.Imag - a.Imag * b.Real) / denom);
        }

        public static bool operator ==(Complex a, Complex b)
        {
            if (a is null)
            {
                if (b is null)
                {
                    return true;
                }

                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Complex a, Complex b) => !(a == b);


        public override bool Equals(object obj)
        {
            var a = obj as Complex;
            return real == a.Real && imag == a.Imag;
        }

        public override int GetHashCode() => (Real, Imag).GetHashCode();

        /*Класс должен иметь возможность преобразовывать комплексное число в строку
        обычной записи комплексного числа.Строка, должна быть “красивая” (т.е. 1-2i, а не 1
        + -2i, или 1, а не 1+0i, или 2i, а не 0+2i, или 1+i, а не 1+1i). Должна быть возможность
        распечатки числа как Console.WriteLine(complex). Преобразование достигается при
        помощи перегрузки метода ToString().*/

        public override string ToString()
        {
            string re = real == 0 ? "" : real.ToString();
            string im = imag == 0 ? "" : imag == 1 ? "i" : imag.ToString() + "i";
            string sign = imag > 0 ? "+" : "";
            return re + sign + im;
        }
    }
}
