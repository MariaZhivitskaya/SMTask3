using System;

namespace SMTask3
{
    class ExponentialDistribution
        : AbstractGenerator
    {
        private double a;
        private double b;
        private double l;

        public ExponentialDistribution(double l)
        {
            this.l = l;
            a = 0;
            b = 10;
        }


        public override double GetElement()
        {
            double bsvDouble = base.GetElement();
            return -Math.Log(bsvDouble) / l;
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
