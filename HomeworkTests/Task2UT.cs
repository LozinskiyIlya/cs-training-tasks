using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2;

namespace HomeworkTests
{
    [TestClass]
    public class Task2UT

    {
        // *************** //
        // Object creation //
        // *************** //
        [TestMethod("Real constructor")]
        public void RealConstr()
        {
            var realPart = 0.1;
            var complex = new Complex(realPart);
            Assert.AreEqual(realPart, complex.Real);
            Assert.AreEqual(0, complex.Imag);
        }

        [TestMethod("Full constructor")]
        public void FullConstr()
        {
            var realPart = 0.1;
            var imagPart = 1.1;
            var complex = new Complex(realPart, imagPart);
            Assert.AreEqual(realPart, complex.Real);
            Assert.AreEqual(imagPart, complex.Imag);
        }

        // ***************** //
        // Polar coordinates //
        // ***************** //
        [TestMethod("0+0i")]
        public void _0And0i()
        {
            var modulus = 0;
            var argument = 0;
            var complex = Complex.FromPolar(modulus, argument);
            Assert.AreEqual(0, complex.Real);
            Assert.AreEqual(0, complex.Imag);
        }

        [TestMethod("1+0i")]
        public void _1And0i()
        {
            var modulus = 1;
            var argument = 0;
            var complex = Complex.FromPolar(modulus, argument);
            Assert.AreEqual(1, complex.Real);
            Assert.AreEqual(0, complex.Imag);
        }


        /*[TestMethod("0+i")]
        public void _0Andi()
        {
            var modulus = 1;
            var argument = Math.PI / 2;
            var complex = Complex.FromPolar(modulus, argument);
            Assert.AreEqual(complex.Real, 0);
        }

        [TestMethod("-1+0i")]
        public void _Minus1And0i()
        {
            var modulus = 1;
            var argument = Math.PI;
            var complex = Complex.FromPolar(modulus, argument);
            Assert.AreEqual(complex.Real, -1);
            Assert.AreEqual(complex.Imag, 0);
        }

        [TestMethod("-1-i")]
        public void _Minus1AndMinusi()
        {
            var modulus = 1;
            var argument = Math.PI * 3 / 2;
            var complex = Complex.FromPolar(modulus, argument);
            Assert.AreEqual(complex.Real, -1);
            Assert.AreEqual(complex.Imag, -1);
        }*/


        // ************** //
        // Arg and Module //
        // ************** //
        [TestMethod("Arg is zero when z = 0")]
        public void ArgIsZero()
        {
            var real = 0;
            var imag = 0;
            var complex = new Complex(real, imag);
            Assert.AreEqual(0, complex.Arg);
        }

        [TestMethod("Arg is 90 when real = 0")]
        public void ArgIsZeroWhenRealIsZero()
        {
            var real = 0;
            var imag = 123;
            var complex = new Complex(real, imag);
            Assert.AreEqual(90, complex.Arg);
        }

        [TestMethod("Arg is zero when imag = 0")]
        public void ArgIsZeroWhenImagIsZero()
        {
            var real = 1010;
            var imag = 0;
            var complex = new Complex(real, imag);
            Assert.AreEqual(0, complex.Arg);
        }

        // **************** //
        // Unary operations //
        // **************** //

        [TestMethod("Unary minus")]
        public void UnaryMinus()
        {
            var a = new Complex(1, 2);
            Assert.AreEqual(new Complex(-1, -2), -a);

            a = Complex.Zero();
            Assert.AreEqual(a, -a);

            a = new Complex(1.3333, 2 / 60);
            Assert.AreEqual(new Complex(-1.3333, -2 / 60), -a);
        }

        // ********** //
        // Аrithmetic //
        // ********** //

        [TestMethod("Sum")]
        public void Sum()
        {
            var a = new Complex(-4, 2);
            var b = new Complex(3.1, 0);
            var c = a + b;
            Assert.AreEqual(-0.9M, (decimal)c.Real);
            Assert.AreEqual(2, c.Imag);

            a = Complex.Zero();
            Assert.AreEqual(a, a + a);

            b = new Complex(1, 2);
            Assert.AreEqual(a, b + (-b));
        }

        [TestMethod("Sub")]
        public void Sub()
        {
            var a = new Complex(-4, 2);
            var b = new Complex(3.1, 4);
            var c = b - a;
            Assert.AreEqual(7.1M, (decimal)c.Real);
            Assert.AreEqual(2, c.Imag);

            a = Complex.Zero();
            Assert.AreEqual(a, a - a);

            b = new Complex(1, 2);
            Assert.AreEqual(a, b - b);
        }

        [TestMethod("Mult")]
        public void Mult()
        {
            var a = new Complex(-4, 2);
            var b = new Complex(3, 1);
            var c = a * b;
            Assert.AreEqual(new Complex(-14, 2), c);
            Assert.AreEqual(b * a, c);

            a = Complex.Zero();
            Assert.AreEqual(a, a * a);

            b = new Complex(1, 2);
            Assert.AreEqual(a, a * b);
            Assert.AreEqual(a, b * a);
        }

        [TestMethod("Div")]
        public void Div()
        {
            var a = new Complex(-4, 2);
            var b = new Complex(3, 1);
            var c = a / b;
            Assert.AreEqual(new Complex(-1, 1), c);
            Assert.AreEqual(b * c, a);

            a = Complex.Zero();
            Assert.ThrowsException<DivideByZeroException>(() => a / a);

            b = new Complex(1, 2);
            Assert.AreEqual(a / b, a);
        }

        // ******** //
        // Equality //
        // ******** //

        [TestMethod("==")]
        public void EqualOperator()
        {
            var a = new Complex(-4, 2);
            var b = new Complex(3, 1);
            Assert.IsFalse(a == b);

            a = Complex.Zero();
            Assert.IsTrue(a == new Complex(0, 0));

            a = new Complex(1, 2);
            b = new Complex(1, 2);
            Assert.IsTrue(a == b);

            Complex c = null;
            Complex d = null;
            Assert.IsTrue(c == d);
            Assert.IsTrue(c == null);
        }

        [TestMethod("!=")]
        public void NotEqualOperator()
        {
            var a = new Complex(-4, 2);
            var b = new Complex(3, 1);
            Assert.IsTrue(a != b);

            a = Complex.Zero();
            Assert.IsFalse(a != new Complex(0, 0));

            a = new Complex(1, 2);
            b = new Complex(1, 2);
            Assert.IsFalse(a != b);
        }

        [TestMethod("Equals")]
        public void Equals()
        {
            var a = new Complex(4, -2);
            var b = new Complex(-4, 2);
            Assert.IsFalse(a.Equals(b));

            a = Complex.Zero();
            Assert.IsTrue(a.Equals(new Complex(0, 0)));

            a = new Complex(1.3, -2);
            b = new Complex(1.3, -2);
            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod("HashCode")]
        public void HashCode()
        {
            var a = new Complex(4, -2);
            var b = new Complex(-4, 2);
            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());

            a = Complex.Zero();
            Assert.AreEqual((0,0).GetHashCode(), a.GetHashCode());

            a = new Complex(1.3, -2);
            b = new Complex(1.3, -2);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        // ******** //
        // ToString //
        // ******** //

        [TestMethod("ToString")]
        public void _ToString()
        {
            var a = new Complex(4, -2);
            Assert.AreEqual("4-2i", a.ToString());
            Console.WriteLine(a);

            a = Complex.Zero();
            Assert.AreEqual("0", a.ToString());
            Console.WriteLine(a);

            a = new Complex(1.3, 2);
            Assert.AreEqual("1,3+2i", a.ToString());
            Console.WriteLine(a);

            a = new Complex(1, 0);
            Assert.AreEqual("1", a.ToString());
            Console.WriteLine(a);

            a = new Complex(1, 1);
            Assert.AreEqual("1+i", a.ToString());
            Console.WriteLine(a);

            a = new Complex(1, -1);
            Assert.AreEqual("1-i", a.ToString());
            Console.WriteLine(a);

            a = new Complex(0, -221);
            Assert.AreEqual("-221i", a.ToString());
            Console.WriteLine(a);
        }

        /*Класс должен иметь возможность преобразовывать комплексное число в строку
       обычной записи комплексного числа.Строка, должна быть “красивая” (т.е. 1-2i, а не 1
       + -2i, или 1, а не 1+0i, или 2i, а не 0+2i, или 1+i, а не 1+1i). Должна быть возможность
       распечатки числа как Console.WriteLine(complex). Преобразование достигается при
       помощи перегрузки метода ToString().*/
    }
}
