using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTask3
{
    public class EvenDistributionFunction
        : IDistributionFunction
    {

        private double a;
        private double b;
        
        public EvenDistributionFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double F(double x)
        {
            if(x < a) return 0;
            if (x > b) return 1;

            return (x - a) / (b - a);

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
