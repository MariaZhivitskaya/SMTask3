using System;
using System.IO;

namespace SMTask3
{
    class Handler
    {
        private readonly double[] argsKolmogorov =
       {
           0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1,
           1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 2.0,
           2.5, 3.0, 3.5, 4.0, 4.5
        };

        private readonly double[] Kolmogorov =
        {
           1.0, 0.9972, 0.9639, 0.8643, 0.7112, 0.5441, 0.3927, 0.2700,
           0.1777, 0.1122, 0.0681, 0.0397, 0.0222, 0.0120, 0.0062, 0.0007,
           0.0000075, 0.00000003, 
        };

        public double Dn { get; private set; }
        public double KolmogorovCriteriaP { get; private set; }

        public static void WriteFile(double[] sequence, string fileName, double l, int n)
        {
            using (var file = new StreamWriter(fileName))
            {
                file.WriteLine("l = {0}, n = {1}\n", l, n);
                foreach (var element in sequence)
                {
                    file.Write("{0} ", element);
                }
                file.WriteLine("\n");
            }
        }

        public static void WriteFile(double[] sequence, string fileName, int a, int b, int n)
        {
            using (var file = new StreamWriter(fileName))
            {
                file.WriteLine("a = {0}, b = {1}, n = {2}\n", a, b, n);
                foreach (var element in sequence)
                {
                    file.Write("{0} ", element);
                }
                file.WriteLine("\n");
            }
        }

        public bool KolmogorovCriteria(double[] sequence, IDistributionFunction func, double eps)
        {
            int n = sequence.Length;
            IDistributionFunction empiricalDistributionFunction = new EmpiricalDistributionFunction(sequence);
            int numberOfPartitions = n * n;
            double x;
            Dn = 0;

            for (int i = 0; i < numberOfPartitions; i++)
            {
                x = (1.0 * i / numberOfPartitions) * (func.Right() - func.Left()) + func.Left();
                Dn = Math.Max(Dn, Math.Abs(empiricalDistributionFunction.F(x) - func.F(x)));
            }

            KolmogorovCriteriaP = GetKolmogorovDistributionFunction(Math.Sqrt(n) * Dn);

            return KolmogorovCriteriaP > eps;
        }

        private double GetKolmogorovDistributionFunction(double x)
        {
            for (int i = 0; i < argsKolmogorov.Length; i++)
            {
                if (x <= argsKolmogorov[i])
                {
                    return Kolmogorov[i];
                }
            }

            return Math.Pow(10, -10);
        }

        public void WriteFileKolmogorovCriteria(double p, double Dn, bool isCorrect, string fileName)
        {
            using (var file = new StreamWriter(fileName))
            {
                file.WriteLine("Kolmogorov Criteria");
                file.WriteLine("Dn = {0}, p = {1}\n", Dn, p);
                file.WriteLine(WriteResult(isCorrect));
                file.WriteLine("-----------------------------------------");
            }
        }

        private string WriteResult(bool isCorrect)
        {
            return "Random selection is " + (isCorrect ? "correct" : "not correct");
        }
    }
}
