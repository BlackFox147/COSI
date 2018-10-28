using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Hopfield
{
    public class Showing
    {
        private const int n = ReferenceImage.N * ReferenceImage.N;

        private const int N = ReferenceImage.N;

        public void ShowWeightCoefficients(int[] w)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(w[i * n + j].ToString() + "_");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void ShowImage(int[] image)
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

        public void ShowResultRecognizes(IList<bool> recognizes, int persent)
        {
            Console.Write($"{persent} % -> ");
            foreach (bool recognize in recognizes)
            {
                string temp = recognize ? "+ " : "- ";
                Console.Write(temp);
            }
            Console.WriteLine();
        }

    }
}
