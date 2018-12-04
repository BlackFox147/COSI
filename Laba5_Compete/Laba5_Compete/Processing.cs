using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba5_Compete
{
    public class Processing
    {
        private const int N = ReferenceImage.N;
        private const int M = ReferenceImage.M;
        private const double difference = ReferenceImage.D;

        private List<Cluster> clusters;

        private void Init()
        {
            var W = new double[M][];
           
            var random = new Random();
           
            for (int i = 0; i < M; i++)
            {
                W[i] = new double[N];

                for (int j = 0; j < N; j++)
                {
                    double rw = random.NextDouble();
                    //W[i][j] = random.Next(0, 2) == 0 ? rw : rw * (-1);
                    W[i][j] = rw;
                }
            }

            clusters = new List<Cluster>();

            for (int i = 0; i < M; i++)
            {
                clusters.Add(new Cluster(W[i],i));
            }
        }

        public void Training()
        {
            Init();
            
            while (true)
            {
                var D = new double[M];
                //var D = new double[M+1];

                D[0] = ProcessingOneTraining(ReferenceImage.L);
                D[1] = ProcessingOneTraining(ReferenceImage.U);
                D[2] = ProcessingOneTraining(ReferenceImage.T);
                //D[3] = ProcessingOneTraining(ReferenceImage.O);
                D[3] = ProcessingOneTraining(ReferenceImage.K);

                if (D.Max() <= difference)
                {
                    break;
                }
            }
        }

        private double ProcessingOneTraining(double[] input)
        {
            for (int j = 0; j < M; j++)
            {
               clusters[j].CalculateD(input);
            }

            var winer = clusters.Min();

            winer.CountOfWin++;
            winer.Correct(input);

            return winer.D / winer.CountOfWin;
        }
      
        private int WorkProcess(double[] input)
        {
            for (int j = 0; j < M; j++)
            {
                clusters[j].CalculateD(input);
            }

            double winerD = clusters.Select(i => i.D).Min();
            var winer = clusters.Single(i => i.D == winerD);

            return winer.Id;
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