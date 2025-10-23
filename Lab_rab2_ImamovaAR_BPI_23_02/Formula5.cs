using System;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public class Formula5
    {
        public int N { get; set; }
        public int K { get; set; }
        public double P { get; set; }
        public double X { get; set; }
        public double F { get; set; }
        public double Y { get; set; }

        public Formula5(int n, int k, double p, double x, double f, double y)
        {
            N = n;
            K = k;
            P = p;
            X = x;
            F = f;
            Y = y;
        }

        public double Calculate()
        {
            double Z = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    double numerator = Math.Pow(P, i) * Math.Pow(X, 3) + Math.Pow(F, j) * Math.Pow(Y, 2);
                    double denominator = i * j;
                    Z += numerator / denominator;
                }
            }
            return Z;
        }
    }
}