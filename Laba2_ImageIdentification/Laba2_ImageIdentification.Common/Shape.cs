using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba2_ImageIdentification.Common
{
    public class Shape
    {
        public List<ConnecteArea> Areas { get; set; }

        public int Perimeter { get; set; }

        public int Square { get; set; }

        public double Compactness { get; set; }

        public double Elongation { get; set; }

        public int NumberOfCluster { get; set; }

        public List<ConnecteArea> Border { get; set; }

        private const int connectivity = 4;

        public Shape(List<ConnecteArea> areasOfShape)
        {
            Areas = areasOfShape;
            Square = GetSquare();
            Perimeter = GetPerimeter();
            Compactness = Math.Pow(Perimeter, 2) / Square;
            Elongation = GetElongation();
        }

        private bool IsContent(int x, int y)
        {
            return Areas.FirstOrDefault(i => i.X == x && i.Y == y) != null;
        }

        private double CenterOfMass(int square, bool isForX, List<int> arrayOfx, List<int> arrayOfy)
        {
            int sum = 0;
            foreach (int x in arrayOfx)
            {
                foreach (int y in arrayOfy)
                {
                    if (IsContent(x, y))
                    {
                        sum += isForX ? x : y;
                    }
                }
            }

            return (double) sum / square;
        }

        private double GetElongation()
        {
            var coordinateOfx = GetСoordinate(true);
            var coordinateOfy = GetСoordinate(false);
           
            double centerOfMassX = CenterOfMass(Square, true, coordinateOfx, coordinateOfy);
            double centerOfMassY = CenterOfMass(Square, false, coordinateOfx, coordinateOfy);

            double m20 = GetDiscreteCentralMoment(2, 0, centerOfMassX, centerOfMassY, coordinateOfx, coordinateOfy);
            double m02 = GetDiscreteCentralMoment(0, 2, centerOfMassX, centerOfMassY, coordinateOfx, coordinateOfy);
            double m11 = GetDiscreteCentralMoment(1, 1, centerOfMassX, centerOfMassY, coordinateOfx, coordinateOfy);

            double sqrt = Math.Sqrt(Math.Pow(m20 - m02, 2) + 4 * Math.Pow(m11, 2));

            double elongation = (m20 + m02 + sqrt) / (m20 + m02 - sqrt);

            return elongation;
        }

        private List<int> GetСoordinate(bool isForX)
        {
            var coordinate = Areas.Select(it => isForX ? it.X: it.Y).Distinct().ToList();
            coordinate.Sort();
            return coordinate;
        }
   
        private double GetDiscreteCentralMoment(int i, int j, double centerOfMassX, double centerOfMassY,
            List<int> arrayOfx, List<int> arrayOfy)
        {
           
            double m = 0;

            foreach (int x in arrayOfx)
            {
                foreach (int y in arrayOfy)
                {
                    if (IsContent(x, y))
                    {
                        m += Math.Pow((x - centerOfMassX), i) * Math.Pow((y - centerOfMassY), j);
                    }
                }
            }

            return m;
        }

        private int GetSquare()
        {
            return Areas.Count();
        }

        private int GetPerimeter()
        {
            Border = new List<ConnecteArea>();

            int perimeter = 0;

            foreach (var pixel in Areas)
            {
                if (CheaknNighborhood(pixel))
                {
                    perimeter++;
                    Border.Add(pixel);
                }
            }

            return perimeter;
        }

        private bool CheaknNighborhood(ConnecteArea pixel)
        {
            var neighborhood = Areas.Where(p => (p.X == pixel.X - 1 && p.Y == pixel.Y)
                                                || (p.X == pixel.X && p.Y == pixel.Y + 1)
                                                || (p.X == pixel.X + 1 && p.Y == pixel.Y)
                                                || (p.X == pixel.X && p.Y == pixel.Y - 1)).ToList();

            return neighborhood.Count != connectivity;
        }

    }
}
