using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Laba2_ImageIdentification.Cluster;
using Laba2_ImageIdentification.Common;

namespace Laba2_ImageIdentification.ImageProcessing
{
    public class ImageProcessing
    {
        private Bitmap originalImage;
        private int width;
        private int height;

        private readonly int rOpening = 2;

        private readonly bool[] maskOpening =
        {
            false, false, true, false, false,
            false, true, true,  true, false,
            true, true, true, true, true,
            true, true, true,  true, true,
            true, true, true,  true, true,
            false, true, true,  true, false,
            false, false, true, false, false,
        };

        private byte oneByte = 255;
        private byte zeroByte = 0;


        public Bitmap Resize(Bitmap original, int customWidth, int customHeight)
        {
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            float ratioX = (float)customWidth / originalWidth;
            float ratioY = (float)customHeight / originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            var newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(original, 0, 0, newWidth, newHeight);
            }

            width = newWidth;
            height = newHeight;
            originalImage = newImage;

            return newImage;
        }


        public byte[] GetGreyImage(Bitmap original)
        {
            var greyImage = new byte[width * height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var pixel = (originalImage.GetPixel(j, i));

                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    byte I = Convert.ToByte((double)0.2125 * R + 0.7154 * G + 0.0721 * B);
                    int index = i * width + j;
                    greyImage[index] = I;
                }
            }

            return greyImage;
        }

        public byte[] getBlackWight_Ad(byte[] greyImage, int r, int c)
        {
            var binaryImage = new byte[width * height];
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    int y1 = y - r;
                    int y2 = y + r;
                    int x1 = x - r;
                    int x2 = x + r;

                    if (y1 < 0)
                        y1 = 0;
                    if (y2 >= width)
                        y2 = width - 1;
                    if (x1 < 0)
                        x1 = 0;
                    if (x2 >= height)
                        x2 = height - 1;

                    byte T = getMediumT(greyImage, x1, x2, y1, y2);

                    int index = x * width + y;

                    byte I = greyImage[index] > T + c ? Convert.ToByte(255) : Convert.ToByte(0);
                    binaryImage[index] = I;
                }
            }
            return binaryImage;
        }

        private byte getMediumT(byte[] bytes, int x1, int x2, int y1, int y2)
        {
            var listT = new List<byte>();

            for (int i = x1; i <= x2; i++)
            {
                for (int j = y1; j <= y2; j++)
                {
                    int index = i * width + j;
                    listT.Add(bytes[index]);
                }
            }
            listT.Sort();
            return listT[listT.Count / 2];
        }

        public byte[] Opening(byte[] original)
        {
            return OpeningProcessing(OpeningProcessing(original, TypeOfNoiseElimination.Erosion),
                TypeOfNoiseElimination.Dilation);
        }

        private byte[] OpeningProcessing(byte[] original, TypeOfNoiseElimination typeOfNoiseElimination)
        {
            var openingImage = new byte[width * height];
            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    int y1 = y - rOpening;
                    int y2 = y + rOpening;
                    int x1 = x - rOpening;
                    int x2 = x + rOpening;

                    if (y1 < 0)
                        y1 = 0;
                    if (y2 >= width)
                        y2 = width - 1;
                    if (x1 < 0)
                        x1 = 0;
                    if (x2 >= height)
                        x2 = height - 1;

                    byte core = typeOfNoiseElimination == TypeOfNoiseElimination.Erosion
                        ? Convert.ToByte(255)
                        : Convert.ToByte(0);

                    for (int i = x1; i <= x2; i++)
                    {
                        for (int j = y1; j <= y2; j++)
                        {
                            bool isMask = maskOpening[(rOpening * 2 + 1) * (i - x1) + (j - y1)];

                            bool isCore = typeOfNoiseElimination == TypeOfNoiseElimination.Erosion
                                ? original[i * width + j] < core
                                : original[i * width + j] > core;


                            if (isMask && isCore)
                            {
                                core = typeOfNoiseElimination == TypeOfNoiseElimination.Erosion
                                    ? Convert.ToByte(0)
                                    : Convert.ToByte(255);
                            }

                        }
                    }
                    openingImage[x * width + y] = core;
                }
            }

            return openingImage;
        }

        public byte[] CreateArrayBytes(Bitmap original)
        {
            var bytes = new byte[original.Width * original.Height];

            for (int i = 0; i < original.Height; ++i)
            {
                for (int j = 0; j < original.Width; ++j)
                {
                    var pixel = original.GetPixel(j, i);
                    int index = i * original.Width + j;
                    bytes[index] = pixel.R;
                }
            }
            return bytes;
        }

        public Bitmap CreateImage(byte[] original)
        {
            var resultImage = new Bitmap(width, height);

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    int index = x * width + y;

                    byte I = original[index];
                    resultImage.SetPixel(y, x, Color.FromArgb(I, I, I));
                }
            }

            return resultImage;
        }

        private List<ConnecteArea> ConvertToAreas(byte[] original)
        {
            var resultMap = new List<ConnecteArea>();

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    resultMap.Add(new ConnecteArea(x, y, 0, original[x * width + y]));
                }
            }

            return resultMap;
        }


        public IList<Shape> SelectionOfConnecteAreas(byte[] original)
        {
            var areas = ConvertToAreas(original);

            int numberOfArea = 1;

            var table = new List<TableOfEquals>();

            for (int x = 1; x < height; x++)
            {
                for (int y = 1; y < width; y++)
                {

                    int ax = x;
                    int ay = y;

                    var a = areas[ax * width + ay];
                    int bx = x;
                    int by = y - 1;

                    var b = areas[bx * width + by];

                    int cx = x - 1;
                    int cy = y;

                    var c = areas[cx * width + cy];

                    if (a.Value == zeroByte)
                    {
                        continue;
                    }

                    if (b.NumberOfArea == 0 && c.NumberOfArea == 0)
                    {
                        a.NumberOfArea = numberOfArea++;
                    }
                    else
                    {
                        if ((b.NumberOfArea == 0 && c.NumberOfArea != 0)
                            || b.NumberOfArea != 0 && c.NumberOfArea == 0)
                        {
                            a.NumberOfArea = b.NumberOfArea != 0 ? b.NumberOfArea : c.NumberOfArea;
                        }
                        else
                        {
                            if (b.NumberOfArea != 0 && c.NumberOfArea != 0)
                            {
                                if (b.NumberOfArea == c.NumberOfArea)
                                {
                                    a.NumberOfArea = b.NumberOfArea = c.NumberOfArea;
                                }
                                else
                                {
                                    a.NumberOfArea = b.NumberOfArea;

                                    if (table.Count == 0)
                                    {
                                        table.Add(new TableOfEquals(new List<int>() { b.NumberOfArea, c.NumberOfArea }));
                                        continue;
                                    }

                                    if (table.FirstOrDefault(i => i.ContainsInOne(b.NumberOfArea, c.NumberOfArea)) != null)
                                    {
                                        continue;
                                    }

                                    var isContaintB = table.FirstOrDefault(i => i.Contains(b.NumberOfArea));
                                    var isContaintC = table.FirstOrDefault(i => i.Contains(c.NumberOfArea));

                                    if (isContaintB == null && isContaintC == null)
                                    {
                                        table.Add(new TableOfEquals(new List<int>() { b.NumberOfArea, c.NumberOfArea }));
                                        continue;
                                    }

                                    if (isContaintB != null && isContaintC != null)
                                    {
                                        isContaintB.Equals.AddRange(isContaintC.Equals);
                                        table.Remove(isContaintC);
                                        continue;
                                    }

                                    if (isContaintB != null)
                                    {
                                        isContaintB.Equals.Add(c.NumberOfArea);
                                        continue;
                                    }

                                    if (isContaintC != null)
                                    {
                                        isContaintC.Equals.Add(b.NumberOfArea);
                                        continue;
                                    }

                                    //
                                }
                            }
                        }
                    }

                }
            }

            int k = 1;
            foreach (var row in table)
            {
                var ar = areas.Where(i => row.Contains(i.NumberOfArea)).ToList();
                foreach (var a in ar)
                {
                    a.NumberOfArea = k;
                }

                k++;
            }

            var shapes = new List<Shape>();

            for (int i = 1; i < k; i++)
            {
                shapes.Add(new Shape(areas.Where(a => a.NumberOfArea == i).ToList()));
            }

            return shapes;

        }

        public Bitmap ShowConnecteAreas(IList<Shape> shapes)
        {
            var resultImage = new Bitmap(width, height);

            foreach (var shape in shapes)
            {
                foreach (var pixel in shape.Areas)
                {
                    resultImage.SetPixel(pixel.Y, pixel.X, Color.FromArgb(255, 0, 0));
                }
            }

            return resultImage;
        }


        public IList<Shape> Cluster(IList<Shape> shapes, int number)
        {
            var clusterProcessing = new ClusterProcessing(number, shapes);

            return clusterProcessing.Process();
        }

        public Bitmap UnhideClustering(IList<Shape> shapes, Bitmap original)
        {
            var colors = new Dictionary<int, Color>();

            var clusters = shapes.Select(i => i.NumberOfCluster).Distinct().ToList();
            var rnd = new Random();
            foreach (int cluster in clusters)
            {
                var color = Color.FromArgb(255, rnd.Next(0, 255), rnd.Next(0, 150));
                colors.Add(cluster, color);
            }

            var resultImage = new Bitmap(original, width, height);

            foreach (var shape in shapes)
            {
                var color = colors[shape.NumberOfCluster];
                foreach (var pixel in shape.Areas)
                {
                    resultImage.SetPixel(pixel.Y, pixel.X, color);
                }
            }
            return resultImage;
        }



    }
}
