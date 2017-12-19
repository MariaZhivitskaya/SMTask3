using System;

namespace SMTask3
{
    class CauchyDistribution
        : AbstractGenerator
    {
        private double a;
        private double b;
        private double c;
        private double m;

        public CauchyDistribution(double c, double m)
        {
            a = -50;
            b = -a;
            this.m = m;
            this.c = c;
        }


        public override double GetElement()
        {
            AbstractGenerator norm = new NormalDistribution(0, 1);
            return m + c * Math.Tan(Math.PI * (base.GetElement()));
        }

        public override double GetLeft()
        {
            return a;
        }

        public override double GetRight()
        {
            return b;
        }
    }
}
