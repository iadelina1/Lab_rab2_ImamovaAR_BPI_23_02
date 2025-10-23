using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public class Formula3
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public Formula3(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public double Calculate()
        {
            return C * Math.Pow(A, 2) + D * Math.Pow(B, 2);
        }
    }
}