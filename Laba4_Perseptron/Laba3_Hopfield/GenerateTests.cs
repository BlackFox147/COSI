using System;
using System.Collections.Generic;

namespace Laba4_Perseptron
{
    public class GenerateTests
    {
        private const int n = ReferenceImage.N * ReferenceImage.N;

        public double[] GenerateNoise(double[] original, int percent)
        {
            var resultW = new double[n];
            original.CopyTo(resultW, 0);

            int countNoise = (n / 100) * percent;

            var rnd = new Random();
            var randoms = new HashSet<int>();

            while (true)
            {
                if (randoms.Count >= countNoise)
                {
                    break;
                }

                randoms.Add(rnd.Next(0, n - 1));
            }

            foreach (int random in randoms)
            {
                resultW[random] = (-1) * resultW[random];
            }

            return resultW;
        }

        public double[] GenerateNoiseInvert(double[] original, int percent)
        {
            var resultW = new double[n];
            original.CopyTo(resultW, 0);

            int countNoise = (n / 100) *(100 - percent);

            var rnd = new Random();
            var randoms = new HashSet<int>();

            while (true)
            {
                if (randoms.Count >= countNoise)
                {
                    break;
                }

                randoms.Add(rnd.Next(0, n - 1));
            }

            for (int i =0; i<n;i++)
            {
                if (randoms.Contains(i))
                {
                    continue;
                }
                resultW[i] = (-1) * resultW[i];
            }
           
            return resultW;
        }
    }
}