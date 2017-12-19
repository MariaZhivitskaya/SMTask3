namespace SMTask3
{
    class NormalDistributionFunction
        : IDistributionFunction
    {
        private double a;
        private double b;
        private double m;
        private double d2;

        public NormalDistributionFunction(double m, double d2)
        {
            a = -8;
            b = -a;
            this.m = m;
            this.d2 = d2;
        }

        public double F(double x)
        {
            return 0;
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
