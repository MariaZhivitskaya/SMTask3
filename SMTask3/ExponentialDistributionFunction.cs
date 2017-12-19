using System;

namespace SMTask3
{
    public class ExponentialDistributionFunction
        : IDistributionFunction
    {
        private double a;
        private double b;
        private double l;

        public ExponentialDistributionFunction(int l)
        {
            a = 0;
            b = 10;
            this.l = l;
        }

        public double F(double x)
        {
            return 1 - Math.Exp(-l * x);
        }
       
        public double Left()
        {
            return a;
        }

        public double Right()
        {
            return b;
        }
    }
}
