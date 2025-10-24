using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public class Formula2
    {
        public double A { get; set; }
        public double B { get; set; }
        public double F { get; set; }
        public string ImagePath => "/Resources/Formula2.png";

        public Formula2(double a, double b, double f)
        {
            A = a;
            B = b;
            F = f;
        }

        public double Calculate()
        {
            return Math.Cos(F * A) + Math.Sin(F * B);
        }
    }
}
