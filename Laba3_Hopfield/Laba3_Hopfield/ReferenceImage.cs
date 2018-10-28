using System.Collections.Generic;

namespace Laba3_Hopfield
{
    public static class ReferenceImage
    {
        public const int N = 10;
        public const int testN = 4;

        public static readonly int[] test1 = new int[testN] { -1, 1, -1, 1 };
        public static readonly int[] test2 = new int[testN] { 1, -1, 1, 1 };
        public static readonly int[] test3 = new int[testN] { -1, 1, -1, -1 };

        public static readonly List<int> LowPersents = new List<int>
        {
            10, 20, 30, 35, 40, 45, 50
        };

        public static readonly List<int> HighPersents = new List<int>
        {
            60, 70, 80, 90, 100
        };

        public static readonly int[] E = new int[N* N]
        {
            1,1,1,1,1,1,1,1,1,-1,
            1,1,1,1,1,1,1,1,1,-1,
            1,1,-1,-1,-1,-1,-1,-1,-1,-1,
            1,1,-1,-1,-1,-1,-1,-1,-1,-1,
            1,1,1,1,1,1,1,-1,-1,-1,
            1,1,1,1,1,1,1,-1,-1,-1,
            1,1,-1,-1,-1,-1,-1,-1,-1,-1,
            1,1,-1,-1,-1,-1,-1,-1,-1,-1,
            1,1,1,1,1,1,1,1,1,-1,
            1,1,1,1,1,1,1,1,1,-1
        };

        public static readonly int[] O = new int[N * N]
        {
            -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,
            -1,1,1,1,1,1,1,1,1,-1,
            -1,1,1,1,1,1,1,1,1,-1,
            -1,1,1,-1,-1,-1,-1,1,1,-1,
            -1,1,1,-1,-1,-1,-1,1,1,-1,
            -1,1,1,-1,-1,-1,-1,1,1,-1,
            -1,1,1,-1,-1,-1,-1,1,1,-1,
            -1,1,1,1,1,1,1,1,1,-1,
            -1,1,1,1,1,1,1,1,1,-1,
            -1,-1,-1,-1,-1,-1,-1,-1,-1,-1
        };

        public static readonly int[] Sh = new int[N* N]
        {
            1,1,-1,-1,-1,-1,-1,-1,1,1,
            1,1,-1,-1,-1,-1,-1,-1,1,1,
            1,1,-1,-1,-1,-1,-1,-1,1,1,
            1,1,-1,-1,-1,-1,-1,-1,1,1,
            1,1,-1,-1,1,1,-1,-1,1,1,
            1,1,-1,-1,1,1,-1,-1,1,1,
            1,1,-1,-1,1,1,-1,-1,1,1,
            1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,1,1
        };

    }
}
