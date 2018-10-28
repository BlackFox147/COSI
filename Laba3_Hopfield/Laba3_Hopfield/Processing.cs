using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba3_Hopfield
{
    public class Processing
    {
        private const int n = ReferenceImage.N * ReferenceImage.N;
        private const int N = ReferenceImage.N;

        private int[] GetWeightCoefficientsForInputVector(int[] original)
        {
            var resultW = new int[n * n];

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    resultW[i * n + j] = original[i] * original[j];
                }
            }

            return resultW;
        }

        private int[] SumWeightCoefficients(int[] wE, int[] wO, int[] wSh)
        {
            var resultW = new int[n * n];

            for (int i = 0; i < n * n; i++)
            {
                resultW[i] = wE[i] + wO[i] + wSh[i];
            }

            return resultW;
        }

        private int[] ZeroingMainDiagonal(int[] original)
        {
            var resultW = new int[n * n];
            original.CopyTo(resultW, 0);

            for (int i = 0; i < n; i++)
            {
                resultW[i * n + i] = 0;
            }

            return resultW;
        }

        private int[] PerformingSingleOperation(int[] w, int[] input)
        {
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int k = 0; k < n; k++)
                {
                    sum += w[i * n + k] * input[k];
                }

                result[i] = sum;
            }

            return result;
        }


        public int[] Training()
        {
            var wE = GetWeightCoefficientsForInputVector(ReferenceImage.E);
            var wO = GetWeightCoefficientsForInputVector(ReferenceImage.O);
            var wSh = GetWeightCoefficientsForInputVector(ReferenceImage.Sh);

            var w = SumWeightCoefficients(wE, wO, wSh);
            var resultW = ZeroingMainDiagonal(w);
            return resultW;
        }

        private int[] PerformingBipolarActivationFunction(int[] original)
        {
            var result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = original[i] > 0 ? 1 : -1;
            }

            return result;
        }

        private int[] WorkProcess(int[] w, int[] input)
        {
            var state = new int[n];
            input.CopyTo(state, 0);

            while (true)
            {
                var tempInput = PerformingSingleOperation(w, state);
                var newState = PerformingBipolarActivationFunction(tempInput);

                if (newState.SequenceEqual(state))
                {
                    break;
                }

                newState.CopyTo(state, 0);
            }
            return state;
        }

        public void Work(int[] w)
        {
            var generateTests = new GenerateTests();

            var showing = new Showing();
            showing.ShowImage(ReferenceImage.E);
            showing.ShowImage(ReferenceImage.O);
            showing.ShowImage(ReferenceImage.Sh);

            foreach (int lowPersent in ReferenceImage.LowPersents)
            {
                Console.WriteLine("***************************");
                Console.WriteLine($"=> {lowPersent}%");

                Console.WriteLine("------");
                Console.WriteLine($"=> E => {lowPersent}%");
                var inputE = generateTests
                    .GenerateNoise(ReferenceImage.E, lowPersent);
                showing.ShowImage(inputE);
                showing.ShowImage(WorkProcess(w, inputE));

                Console.WriteLine("------");
                Console.WriteLine($"=> O => {lowPersent}%");
                var inputO = generateTests
                    .GenerateNoise(ReferenceImage.O, lowPersent);
                showing.ShowImage(inputO);
                showing.ShowImage(WorkProcess(w, inputO));

                Console.WriteLine("------");
                Console.WriteLine($"=> Sh => {lowPersent}%");
                var inputSh = generateTests
                    .GenerateNoise(ReferenceImage.Sh, lowPersent);
                showing.ShowImage(inputSh);
                showing.ShowImage(WorkProcess(w, inputSh));
            }

            foreach (int highPersent in ReferenceImage.HighPersents)
            {
                Console.WriteLine("***************************");
                Console.WriteLine($"=> {highPersent}%");

                Console.WriteLine("------");
                Console.WriteLine($"=> E => {highPersent}%");
                var inputE = generateTests
                    .GenerateNoiseInvert(ReferenceImage.E, highPersent);
                showing.ShowImage(inputE);
                showing.ShowImage(WorkProcess(w, inputE));

                Console.WriteLine("------");
                Console.WriteLine($"=> O => {highPersent}%");
                var inputO = generateTests
                    .GenerateNoiseInvert(ReferenceImage.O, highPersent);
                showing.ShowImage(inputO);
                showing.ShowImage(WorkProcess(w, inputO));

                Console.WriteLine("------");
                Console.WriteLine($"=> Sh => {highPersent}%");
                var inputSh = generateTests
                    .GenerateNoiseInvert(ReferenceImage.Sh, highPersent);
                showing.ShowImage(inputSh);
                showing.ShowImage(WorkProcess(w, inputSh));
            }
        }
    }
}