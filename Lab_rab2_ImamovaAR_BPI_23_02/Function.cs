using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public class Function
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double Calculate(double p, double x, double f, double y, int n, int k)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    double numerator = Math.Pow(p, i) * Math.Pow(x, 3) + Math.Pow(f, j) * Math.Pow(y, 2);
                    double denominator = i * j;
                    double term = numerator / denominator;
                    sum += term;
                }
            }
            return sum;
        }
    }
}