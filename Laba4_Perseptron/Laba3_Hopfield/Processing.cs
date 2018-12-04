using System;
using System.Linq;

namespace Laba4_Perseptron
{
    public class Processing
    {
        private const int N = ReferenceImage.N * ReferenceImage.N;
        private const int H = ReferenceImage.H;
        private const int M = ReferenceImage.M;
        private const double alpha = ReferenceImage.A;
        private const double difference = ReferenceImage.D;

        private double[][] V;
        private double[][] W;
        private double[] T;
        private double[] Q;

        private void Init()
        {
            V = new double[N][];
            W = new double[H][];
            Q = new double[H];
            T = new double[M];
            var random = new Random();

            for (int i = 0; i < N; i++)
            {
                V[i] = new double[H];

                for (int j = 0; j < H; j++)
                {
                    double rv = random.NextDouble();
                    V[i][j] = random.Next(0, 2) == 0 ? rv : rv * (-1);
                }
            }

            for (int j = 0; j < H; j++)
            {
                double rq = random.NextDouble();
                Q[j] = random.Next(0, 2) == 0 ? rq : rq * (-1);
            }

            for (int i = 0; i < H; i++)
            {
                W[i] = new double[M];

                for (int j = 0; j < M; j++)
                {
                    double rw = random.NextDouble();
                    W[i][j] = random.Next(0, 2) == 0 ? rw : rw * (-1);
                }
            }

            for (int j = 0; j < M; j++)
            {
                double rt = random.NextDouble();
                T[j] = random.Next(0, 2) == 0 ? rt : rt * (-1);
            }

        }

        private double[] PerformingSingleOperation(double[][] w, double[] input, 
            double [] line, int inputSize, int outputSize)
        {
            var result = new double[outputSize];

            for (int j = 0; j < outputSize; j++)
            {
                double sum = 0;
                for (int k = 0; k < inputSize; k++)
                {
                    sum += w[k][j] * input[k];
                }

                result[j] = ActivationFunction(sum + line[j]);
            }

            return result;
        }

        private double ActivationFunction(double s)
        {
            double eInS = 1 / Math.Pow(Math.E, s);
            return 1 / (1 + eInS);
        }

        public void Training()
        {
            Init();
            
            while (true)
            {
                var D = new double[M];

                D[0] = ProcessingOneTraining(ReferenceImage.L, ReferenceImage.Y[0]);
                D[1] = ProcessingOneTraining(ReferenceImage.U, ReferenceImage.Y[1]);
                D[2] = ProcessingOneTraining(ReferenceImage.T, ReferenceImage.Y[2]);
                D[3] = ProcessingOneTraining(ReferenceImage.O, ReferenceImage.Y[3]);
                D[4] = ProcessingOneTraining(ReferenceImage.K, ReferenceImage.Y[4]);

                if (D.Max() <= difference)
                {
                    break;
                }
            }
        }

        private double ProcessingOneTraining(double[] input, double[] yI)
        {
            var g = PerformingSingleOperation(V, input, Q, N, H);
            var y = PerformingSingleOperation(W, g, T, H, M);

            var gradOut = CalcOutputLocalGrad(yI, y);
            var gradHid = CalcHiddenLocalGrad(g, gradOut, W);

            Correct(W, T, gradOut, M, H, g);
            Correct(V, Q, gradHid, H, N, input);

            return GetMaxD(yI, y);
        }

        private double GetMaxD(double[] yI, double[] y)
        {
            var d = new double[M];
            for (int i = 0; i < M; i++)
            {
                d[i] = Math.Abs(yI[i] - y[i]);
            }

            return d.Max();
        }

        private double[] CalcOutputLocalGrad(double[] yI, double[] y)
        {
            var g = new double[M];
            
            for (int j = 0; j < M; j++)
            {
                g[j] = (yI[j] - y[j]) * y[j] * (1 - y[j]);
            }

            return g;
        }

        private double[] CalcHiddenLocalGrad(double[] y,
            double[] outputGrad, double [][] W)
        {
            var g = new double[H];

            for (int j = 0; j < H; j++)
            {
                double sumGandW = 0;
                for (int m = 0; m < M; m++)
                {
                    sumGandW += outputGrad[m] * W[j][m];
                }

                g[j] = y[j] * (1 - y[j]) * sumGandW;
            }

            return g;
        }

        private void Correct(double[][] weights, double[] line, 
            double[] localGrad, int output, int input, double[] y)
        {
            double a = alpha;

            for (int j = 0; j < input; j++)
            {
                for (int k = 0; k < output; k++)
                {
                    double w = weights[j][k];
                    double deltaW = a * y[j] * localGrad[k];
                    weights[j][k] = w + deltaW;
                }
            }

            for (int j = 0; j < output; j++)
            {
                line[j] += a * localGrad[j];
            }
        }

        private double[] WorkProcess(double[] input)
        {
            var g = PerformingSingleOperation(V, input, Q, N, H);
            var y = PerformingSingleOperation(W, g, T, H, M);

            return y;
        }

        public void Work()
        {
            var generateTests = new GenerateTests();

            var showing = new Showing();
            showing.ShowImage(ReferenceImage.L);
            showing.ShowImage(ReferenceImage.U);
            showing.ShowImage(ReferenceImage.T);
            showing.ShowImage(ReferenceImage.O);
            showing.ShowImage(ReferenceImage.K);

            foreach (int persent in ReferenceImage.Persents)
            {
                Console.WriteLine("#########***************************#########");
                Console.WriteLine($"=> {persent}%");

                Console.WriteLine("------");
                Console.WriteLine($"=> L => {persent}%");
                var inputL = persent < 50
                    ? generateTests.GenerateNoise(ReferenceImage.L, persent)
                    : generateTests.GenerateNoiseInvert(ReferenceImage.L, persent);

                showing.ShowResult(WorkProcess(inputL));

                Console.WriteLine("------");
                Console.WriteLine($"=> U => {persent}%");
                var inputU = persent < 50
                    ? generateTests.GenerateNoise(ReferenceImage.U, persent)
                    : generateTests.GenerateNoiseInvert(ReferenceImage.U, persent);
                showing.ShowResult(WorkProcess(inputU));

                Console.WriteLine("------");
                Console.WriteLine($"=> T => {persent}%");
                var inputT = persent < 50
                    ? generateTests.GenerateNoise(ReferenceImage.T, persent)
                    : generateTests.GenerateNoiseInvert(ReferenceImage.T, persent);
                showing.ShowResult(WorkProcess(inputT));

                Console.WriteLine("------");
                Console.WriteLine($"=> O => {persent}%");
                var inputO = persent < 50
                    ? generateTests.GenerateNoise(ReferenceImage.O, persent)
                    : generateTests.GenerateNoiseInvert(ReferenceImage.O, persent);
                showing.ShowResult(WorkProcess(inputO));

                Console.WriteLine("------");
                Console.WriteLine($"=> K => {persent}%");
                var inputK = persent < 50
                    ? generateTests.GenerateNoise(ReferenceImage.K, persent)
                    : generateTests.GenerateNoiseInvert(ReferenceImage.K, persent);
                showing.ShowResult(WorkProcess(inputK));

                Console.WriteLine();
            }
        }
    }
}