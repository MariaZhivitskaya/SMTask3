using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTask3
{
    class Program
    {
        private static void Main(string[] args)
        {
            int n = 1000;
            int a = 10;
            int b = 15;
            int l = 1;
            int m = 2;
            int d2 = 1;
            double c = -20;

            EvenDistribution evenDistribution = new EvenDistribution(a, b);
            ExponentialDistribution exponentialDistribution = new ExponentialDistribution(l);
            NormalDistribution normalDistribution = new NormalDistribution(m, d2);
            CauchyDistribution cauchyDistribution = new CauchyDistribution(c, m);

            EvenDistributionFunction evenDistributionFunction = new EvenDistributionFunction(a, b);
            ExponentialDistributionFunction exponentialDistributionFunction = new ExponentialDistributionFunction(l);


          
            string fileNameEven = "GeneratorEven.txt";
            string testFileNameEven = "TestsResultsEven.txt";
            string fileNameExponentialn = "GeneratorExponential.txt";
            string testFileNameExponential = "TestsResultsDiscreteExponential.txt";

            Handler handler = new Handler();

            double[] sequenceEven = Generatesequenсe(n, evenDistribution);
            Handler.WriteFile(sequenceEven, fileNameEven, a, b, n);

            double[] sequenceExp = Generatesequenсe(n, exponentialDistribution);
            Handler.WriteFile(sequenceExp, fileNameExponentialn, l, n);

            double eps = 0.01;
            bool estimationResult;

            estimationResult = handler.KolmogorovCriteria(sequenceEven, evenDistributionFunction, eps);
            handler.WriteFileKolmogorovCriteria(handler.KolmogorovCriteriaP, handler.Dn, estimationResult, testFileNameEven);

            estimationResult = handler.KolmogorovCriteria(sequenceExp, exponentialDistributionFunction, eps);
            handler.WriteFileKolmogorovCriteria(handler.KolmogorovCriteriaP, handler.Dn, estimationResult, testFileNameExponential);

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static double[] Generatesequenсe(int n, AbstractGenerator generator)
        {
            double[] sequenсe = new double[n];

            for (int i = 0; i < n; i++)
            {
                sequenсe[i] = generator.GetElement();
            }

            return sequenсe;
        }
    }
}
