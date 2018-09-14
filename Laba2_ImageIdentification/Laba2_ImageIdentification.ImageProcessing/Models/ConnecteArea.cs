namespace Laba2_ImageIdentification.ImageProcessing.Models
{
    public class ConnecteArea
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int NumberOfArea { get; set; }

        public byte Value { get; set; }

        public ConnecteArea(int x, int y, int numberOfArea, byte value)
        {
            X = x;
            Y = y;
            NumberOfArea = numberOfArea;
            Value = value;
        }

        public ConnecteArea()
        {
            X = 0;
            Y = 0;
            NumberOfArea = 0;
            Value = 0;
        }

       
    }
}
