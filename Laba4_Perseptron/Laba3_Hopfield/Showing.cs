using System;

namespace Laba4_Perseptron
{
    public class Showing
    {
        private const int N = ReferenceImage.N;
        private const int M = ReferenceImage.M;

        public void ShowImage(double[] image)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    string temp = image[i * N + j] > 0 ? "a" : ".";

                    Console.Write(temp);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ShowResult(double[] output)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write("{0:f4}  ", output[j]);
            }
            Console.WriteLine();
        }

    }
}
