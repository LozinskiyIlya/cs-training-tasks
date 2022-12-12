using System;
namespace Homework.Task9
{
    public class InversedFunctionCalculator
    {

        public event EventHandler<CalculationEventArgs> CalculationProgress;

        public class CalculationEventArgs : EventArgs
        {
            public CalculationEventArgs(decimal a, decimal b, decimal x, decimal y)
            {
                A = a;
                B = b;
                CurrentX = x;
                CurrentY = y;
            }

            public decimal A { get; set; }
            public decimal B { get; set; }
            public decimal CurrentX { get; set; }
            public decimal CurrentY { get; set; }
        }

       

        protected virtual void OnCalculationEvent(CalculationEventArgs e)
        {
            EventHandler<CalculationEventArgs> raiseEvent = CalculationProgress;

            if (raiseEvent != null)
            {
                raiseEvent(this, e);
            }
        }

        public decimal Inverse(decimal a, decimal b, decimal y, decimal eps, Func<decimal, decimal> f)
        {
            CheckRange(a, b, y, f);
            return Inverse(a, b, y, f, eps);
        }

        private decimal Inverse(decimal a, decimal b, decimal y, Func<decimal, decimal> f, decimal eps)
        {
            bool increasing = f(a) < f(b);
            return Inverse(a, b, y, f, eps, increasing);
        }

        private decimal Inverse(decimal a, decimal b, decimal y, Func<decimal, decimal> f, decimal eps, bool increasing)
        {
            // new center and value
            decimal center = (a + b) / 2;
            decimal value = f(center);

            // raise event
            OnCalculationEvent(new CalculationEventArgs(a, b, center, value));

            // if precise enough -> return
            if (Math.Abs(value - y) <= eps)
            {
                return center;
            }

            if (increasing)
            {
                if (value > y)
                {
                    // [a, center]
                    return Inverse(a, center, y, f, eps, increasing);
                }

                // [center, b]
                return Inverse(center, b, y, f, eps, increasing);
            }

            if (value > y)
            {
                // [center, b]
                return Inverse(center, b, y, f, eps, increasing);
            }

            // [a, center]
            return Inverse(a, center, y, f, eps, increasing);
        }


        private void CheckRange(decimal a, decimal b, decimal y, Func<decimal, decimal> f)
        {
            if (a >= b)
            {
                throw new ArgumentOutOfRangeException("a, b", $"{a} > {b}");
            }

            if (y < f(a) || y > f(b))
            {
                throw new ArgumentOutOfRangeException("a, b, y", $"{y} is not in [f({a}) , f({b})]");
            }
        }

    }
}