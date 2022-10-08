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
            Assert.AreEqual(complex.Real, realPart);
            Assert.AreEqual(complex.Imag, 0);
        }

        [TestMethod("Full constructor")]
        public void FullConstr()
        {
            var realPart = 0.1;
            var imagPart = 1.1;
            var complex = new Complex(realPart, imagPart);
            Assert.AreEqual(complex.Real, realPart);
            Assert.AreEqual(complex.Imag, imagPart);
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
            Assert.AreEqual(complex.Real, 0);
            Assert.AreEqual(complex.Imag, 0);
        }

        [TestMethod("1+0i")]
        public void _1And0i()
        {
            var modulus = 1;
            var argument = 0;
            var complex = Complex.FromPolar(modulus, argument);
            Assert.AreEqual(complex.Real, 1);
            Assert.AreEqual(complex.Imag, 0);
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
            Assert.AreEqual(complex.Arg, 0);
        }

        [TestMethod("Arg is 90 when real = 0")]
        public void ArgIsZeroWhenRealIsZero()
        {
            var real = 0;
            var imag = 123;
            var complex = new Complex(real, imag);
            Assert.AreEqual(complex.Arg, 90);
        }

        [TestMethod("Arg is zero when imag = 0")]
        public void ArgIsZeroWhenImagIsZero()
        {
            var real = 1010;
            var imag = 0;
            var complex = new Complex(real, imag);
            Assert.AreEqual(complex.Arg, 0);
        }

        // **************** //
        // Unary operations //
        // **************** //

        [TestMethod("Unary minus")]
        public void UnaryMinus()
        {
            var a = new Complex(1, 2);
            Assert.AreEqual(-a, new Complex(-1, -2));

            a = new Complex(0, 0);
            Assert.AreEqual(-a, a);

            a = new Complex(1.3333, 2 / 60);
            Assert.AreEqual(-a, new Complex(-1.3333, -2 / 60));
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
            Assert.IsTrue(c.Real == -0.9);
            Assert.AreEqual(c.Imag, 2);

            a = new Complex(0, 0);
            Assert.AreEqual(a + a, a);

            b = new Complex(1, 2);
            Assert.AreEqual(b + (-b), a);
        }

    }
}
