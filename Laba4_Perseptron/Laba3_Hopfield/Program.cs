using System;

namespace Laba4_Perseptron
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var processing = new Processing();

            processing.Training();
            processing.Work();

            Console.ReadKey();
        }
    }
}
