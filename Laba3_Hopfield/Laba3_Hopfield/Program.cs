using System;

namespace Laba3_Hopfield
{
    public class Program
    {
        static void Main(string[] args)
        {
            var processing = new Processing();

            var w = processing.Training();
            processing.Work(w);

            Console.ReadKey();
        }
    }
}
