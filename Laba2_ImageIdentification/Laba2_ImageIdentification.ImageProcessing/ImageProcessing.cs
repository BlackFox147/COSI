using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Laba2_ImageIdentification.Histogram.Models;
using Laba2_ImageIdentification.ImageProcessing.Models;

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

            return newImage;
        }


        public byte[] GetGreyImage(Bitmap original)
        {
            width = original.Width;
            height = original.Height;
            originalImage = original;

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


        //public Bitmap Bradley_threshold(Bitmap original)
        //{
        //    var resultImage = new Bitmap(original, original.Width, original.Height);

        //    int S = original.Width / 64;

        //    int s2 = S / 2;

        //    float t = 0.15f;

        //    var integral_image = new ulong[original.Width * original.Height];
        //    ulong sum;
        //    int count;
        //    int index;
        //    int y1, x1, y2, x2;

        //    //рассчитываем интегральное изображение 


        //    //integral_image = new unsigned long[width * height * sizeof(unsigned long *)];

        //    for (int y = 0; y < original.Width; y++)
        //    {
        //        sum = 0;
        //        for (int x = 0; x < original.Height; x++)
        //        {
        //            index = x * original.Width + y;
        //            sum += original.GetPixel(y,x).G;

        //            if (y == 0)
        //            {
        //                integral_image[index] = sum;
        //            }
        //            else
        //            {
        //                //integral_image.Insert(index, integral_image[index - 1] + sum);
        //                integral_image[index] = integral_image[index - 1] + sum;
        //            }

        //        }
        //    }

        //    //находим границы для локальные областей
        //    for (int y = 0; y < original.Width; y++)
        //    {
        //        for (int x = 0; x < original.Height; x++)
        //        {
        //            index = x * original.Width + y;

        //            y1 = y - s2;
        //            y2 = y + s2;
        //            x1 = x - s2;
        //            x2 = x + s2;

        //            if (y1 < 0)
        //                y1 = 0;
        //            if (y2 >= original.Width)
        //                y2 = original.Width - 1;
        //            if (x1 < 0)
        //                x1 = 0;
        //            if (x2 >= original.Height)
        //                x2 = original.Height - 1;

        //            count = (y2 - y1) * (x2 - x1);

        //            sum = integral_image[x2 * original.Width + y2] - integral_image[x1 * original.Width + y2] -
        //                  integral_image[x2 * original.Width + y1] + integral_image[x1 * original.Width + y1];

        //            if ((long)original.GetPixel(y, x).R * count < (long)(sum * (1.0 - t)))
        //                resultImage.SetPixel(y, x, Color.FromArgb(0, 0, 0));
        //            //res[index] = 0;
        //            else
        //                //res[index] = 255;
        //                resultImage.SetPixel(y, x, Color.FromArgb(255, 255, 255));
        //        }
        //    }

        //    //delete[] integral_image;
        //    return resultImage;
        //}

        //public byte getHp(IList<ChannelHistogram> histograms)
        //{
        //    var histogram = histograms.First(h => h.TypeOfСhannel == TypeOfСhannel.RedСhannel).Histogram;

        //    byte hmax = histogram.FirstOrDefault(x => x.Value == histogram.Values.Max()).Key;

        //    float sum = histogram.Where(k => k.Key <= hmax).Select(i => i.Value).Aggregate<int, float>(0, (current, keyValuePair) => current + keyValuePair);

        //    double p = sum * 0.15;

        //    var list = histogram.Where(k => k.Key >= hmax).Select(i=>i.Key).ToList();
        //    list.Sort();
        //    foreach (var h in list)
        //    {
        //        var f = histogram.Where(k => k.Key >= h).ToList();
        //        double count = getCount(f);
        //        if (count <= p)
        //        {
        //            return h;
        //        }
        //    }

        //    return hmax;

        //}

        //private double getCount(IList<KeyValuePair<byte,int>> hist)
        //{
        //    return hist.Select(i=>i.Value).Aggregate<int, float>(0, (current, keyValuePair) => current + keyValuePair);
        //}

        //public Bitmap getBlackWight(Bitmap original, IList<ChannelHistogram> histograms)
        //{
        //    byte hp = getHp(histograms);

        //    var resultImage = new Bitmap(original.Width, original.Height, PixelFormat.Format24bppRgb);

        //    for (int i = 0; i < original.Width; ++i)
        //    {
        //        for (int j = 0; j < original.Height; ++j)
        //        {
        //            var pixel = original.GetPixel(i, j);

        //            byte I = pixel.R > hp ? Convert.ToByte(255) : Convert.ToByte(0);
        //            resultImage.SetPixel(i, j, Color.FromArgb(I, I, I));
        //        }
        //    }
        //    return resultImage;
        //}


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

        private byte[] CreateArrayBytes(Bitmap original)
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
    }
}
