using System;

namespace SMTask3
{
    public class NormalDistribution
        : AbstractGenerator
    {
        private double a;
        private double b;
        private double m;
        private double d2;

        public NormalDistribution(double m, double d2)
        {
            this.a = -8;
            this.b = -a;
            this.m = m;
            this.d2 = d2;

        }

        public override double GetElement()
        {
            double a1 = base.GetElement();
            double a2 = base.GetElement();
            double res = Math.Sqrt(-2 * Math.Log(a1)) * Math.Cos(2 * Math.PI * a2);
            return m + res * Math.Sqrt(d2);
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
