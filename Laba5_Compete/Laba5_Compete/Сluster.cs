using System;

namespace Laba5_Compete
{
    public class Cluster : IComparable<Cluster>
    {
        private const int N = ReferenceImage.N;
        private const double Alpha = ReferenceImage.A;

        public double[] W { get; }
        
        public int CountOfWin { get; set; }

        public int Id { get; }

        public double D { get; private set; }

        public Cluster(double[] w, int id)
        {
            CountOfWin = 1;
            Id = id;
            W = w;
        }

        public void CalculateD(double[] input)
        {
            double sum = 0;
            for (int k = 0; k < N; k++)
            {
                //sum += Math.Pow(input[k] - W[k], 2);
                double p = input[k];
                double w = W[k];

                sum += Math.Pow(p - w, 2);
            }

            D = sum * CountOfWin;
        }

        public void Correct(double[] input)
        {
            const double a = Alpha;

            for (int k = 0; k < N; k++)
            {
                double newW = W[k] + a*(input[k] - W[k]);
                W[k] = newW;
            }
        }


        public int CompareTo(Cluster obj)
        {
            if (D < obj.D)
            {
                return -1;
            }

            if (D > obj.D)
            {
                return 1;
            }

            return 0;
        }
    }
}
