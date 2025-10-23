using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public class Formula1
    {
        public double A { get; set; }
        public double F { get; set; }

        public Formula1(double a, double f)
        {
            A = a;
            F = f;
        }

        public double Calculate()
        {
            return Math.Sin(F * A);
        }
    }
}
