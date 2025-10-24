using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public class Formula4
    {
        public double A { get; set; }
        public int D { get; set; }
        public double C { get; set; }
        public string ImagePath => "/Resources/Formula4.png";

        public Formula4(double a, int d, double c)
        {
            A = a;
            D = d;
            C = c;
        }

        public double Calculate()
        {
            double sum = 0;
            for (int i = 0; i <= D; i++)
            {
                sum += Math.Pow(C + A, i);
            }
            return sum;
        }
    }
}
