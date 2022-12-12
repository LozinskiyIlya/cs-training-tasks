using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Task9;
using System;
using static Homework.Task9.InversedFunctionCalculator;

namespace HomeworkTests
{
    [TestClass]
    public class Task9UT

    {
        private decimal defaultEps = 0.0001m;
        private Func<decimal, decimal> sin = x => (decimal)Math.Sin((double)x);
        private delegate decimal Del(decimal x);

        // Initialization
        [TestMethod("Init works")]
        public void InitWorks()
        {
            var calc = new InversedFunctionCalculator();
            var result = calc.Inverse(0, 8, 4, defaultEps, x => x * x);
            Assert.AreEqual(2, result);
        }


        // Range checking
        [TestMethod("Invalid segment")]
        public void InvalidSegment()
        {
            var calc = new InversedFunctionCalculator();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var result = calc.Inverse(0, -1, 4, defaultEps, x => x * x);
            });
        }

        [TestMethod("Invalid y")]
        public void Invalidy()
        {
            var calc = new InversedFunctionCalculator();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var result = calc.Inverse(0, 8, 225, defaultEps, x => x * x);
            });
        }


        // Precision
        [TestMethod("Default Eps")]
        public void DefaultEps()
        {
            var eps = defaultEps;
            var y = 0.5m;
            var calc = new InversedFunctionCalculator();
            var result = calc.Inverse(0.1m, 1.3m, y, eps, sin);
            var actual = sin(result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }


        [TestMethod("No precision")]
        public void NoPrecision()
        {
            var eps = 10 * 10 * 10;
            var y = 0.5m;
            var calc = new InversedFunctionCalculator();
            var result = calc.Inverse(0.1m, 1.3m, y, eps, sin);
            var actual = sin(result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }

        [TestMethod("Small precision")]
        public void SmallPrecision()
        {
            var eps = 0.1m;
            var y = 0.5m;
            var calc = new InversedFunctionCalculator();
            var result = calc.Inverse(0.1m, 1.3m, y, eps, sin);
            var actual = sin(result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }

        [TestMethod("High precision")]
        public void HighPrecision()
        {
            var eps = 0.0000001m;
            var y = 0.5m;
            var calc = new InversedFunctionCalculator();
            var result = calc.Inverse(0.1m, 1.3m, y, eps, sin);
            var actual = sin(result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }


        //Different function origin
        [TestMethod("Local function")]
        public void LocalFunc()
        {
            var eps = defaultEps;
            var y = 8;
            var calc = new InversedFunctionCalculator();
            decimal Func(decimal x)
            {
                return x * x + (decimal)Math.Sin((double)x - 2);
            }

            var result = calc.Inverse(2.5m, 3.5m, y, eps, Func);
            var actual = Func(result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }

        [TestMethod("Anonymous function")]
        public void AnonymousFunc()
        {
            var eps = defaultEps;
            var y = 0.5m;
            var calc = new InversedFunctionCalculator();
            var result = calc.Inverse(0.1m, 1.3m, y, eps, delegate (decimal x)
            {
                return (decimal)Math.Sin((double)x);
            });
            var actual = sin(result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }

        [TestMethod("Delegate function")]
        public void DelegateFunc()
        {
            var eps = defaultEps;
            var y = 0.5m;
            var calc = new InversedFunctionCalculator();
            Del f = delegate (decimal x)
            {
                return (decimal)Math.Sin((double)x);
            };
            var result = calc.Inverse(0.1m, 1.3m, y, eps, f.Invoke);
            var actual = f(result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }

        [TestMethod("Lambda function")]
        public void LamdaFunc()
        {
            var eps = defaultEps;
            var y = -0.56m;
            var calc = new InversedFunctionCalculator();
            var result = calc.Inverse(0.3m, 0.9m, y, eps, x => (decimal)Math.Log((double)x));
            var actual = (decimal)Math.Log((double)result);
            Assert.IsTrue(y + eps >= actual);
            Assert.IsTrue(y - eps <= actual);
        }


        // Events
        [TestMethod("Events work")]
        public void EventWork()
        {
            var eps = defaultEps;
            var calc = new InversedFunctionCalculator();
            calc.CalculationProgress += OnCalculationEvent;
            var result = calc.Inverse(0.1m, 1.3m, 0.5m, defaultEps, sin);
            Console.WriteLine($"result = {result}");
        }

        private void OnCalculationEvent(object sender, CalculationEventArgs e)
        {
            Console.WriteLine($"segment: [{e.A} , {e.B}]    function: f({e.CurrentX}) = {e.CurrentY}");
        }
    }
}
