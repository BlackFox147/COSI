using System;

namespace Laba5_Compete
{
    public class Showing
    {
        private const int N = ReferenceImage.NLine;
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

        public void ShowResult(int idOfCluster)
        {
            Console.Write("=> {0:d}  ", idOfCluster);
            Console.WriteLine();
        }

    }
}
