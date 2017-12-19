using System;

namespace SMTask3
{
    public abstract class AbstractGenerator
    {
        private MultiplicativeCongruentialMethod MCM;

        public AbstractGenerator()
        {
            int m = 24;
            long M = 2147483648;
            long beta = Beta(m);

            MCM = new MultiplicativeCongruentialMethod(2147483648, beta);
        }

        public virtual double GetElement()
        {
            return MCM.GetElement();
        }

        public abstract double GetLeft();
        public abstract double GetRight();

        private long Beta(int m)
        {
            return (long)(Math.Pow(2, m) + 3);
        }
    }
}
