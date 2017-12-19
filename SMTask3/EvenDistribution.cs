namespace SMTask3
{
    public class EvenDistribution
        : AbstractGenerator
    {
        private double a;
        private double b;

        public EvenDistribution(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double GetElement()
        {
            double elem = base.GetElement();
            return (b - a) * elem + a;
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
