using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using Laba2_ImageIdentification.Histogram.Models;

namespace Laba2_ImageIdentification.Histogram
{
    public class HistogramProcessing
    {
        public IList<ChannelHistogram> CalculateHistogram(Bitmap image)
        {
            var rHistogram = new ChannelHistogram(TypeOfСhannel.RedСhannel);
            var gHistogram = new ChannelHistogram(TypeOfСhannel.GreenСhannel);
            var bHistogram = new ChannelHistogram(TypeOfСhannel.BlueСhannel);

            var resultedHistogram = new List<ChannelHistogram>();

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    AddBrights(rHistogram, gHistogram, bHistogram, image.GetPixel(x, y));
                }
            }

            resultedHistogram.Add(rHistogram);
            resultedHistogram.Add(gHistogram);
            resultedHistogram.Add(bHistogram);

            return resultedHistogram;
        }

        private void AddBrights(ChannelHistogram rHistogram, ChannelHistogram gHistogram, ChannelHistogram bHistogram,
            Color pixel)
        {
            AddBrightForChannel(pixel.R, rHistogram);
            AddBrightForChannel(pixel.G, gHistogram);
            AddBrightForChannel(pixel.B, bHistogram);
        }

        private void AddBrightForChannel(byte bright, ChannelHistogram channelHistogram)
        {
            if (!channelHistogram.Histogram.ContainsKey(bright))
            {
                channelHistogram.Histogram.Add(bright, 0);
            }
            channelHistogram.Histogram[bright]++;
        }

        //public Bitmap Dissection(Bitmap image, byte fmin, byte fmax, byte gmin, byte gmax,
        //    TypeOfDissection typeOfDissection)
        //{
        //    var coefficients = typeOfDissection == TypeOfDissection.RestrictionOfInputBrightness
        //        ? GetInputDissectionCoefficients(fmin, fmax, gmin, gmax)
        //        : GetOutputDissectionCoefficients(fmin, fmax, gmin, gmax);

        //    return SetPixelsForDissection(image, coefficients);
        //}

        //private Bitmap SetPixelsForDissection(Bitmap image, Dictionary<byte, byte> coefficients)
        //{
        //    var resultImage = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);

        //    for (int i = 0; i < image.Width; ++i)
        //    {
        //        for (int j = 0; j < image.Height; ++j)
        //        {
        //            var pixel = image.GetPixel(i, j);

        //            byte newR = coefficients[pixel.R];
        //            byte newG = coefficients[pixel.G];
        //            byte newB = coefficients[pixel.B];

        //            resultImage.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
        //        }
        //    }
        //    return resultImage;
        //}


        //private Dictionary<byte, byte> GetInputDissectionCoefficients(byte fmin, byte fmax, byte gmin, byte gmax)
        //{
        //    double coefficientDissection = (double)gmax / (fmax - fmin);

        //    var inputCoefficients = new Dictionary<byte, byte>();

        //    for (int i = 0; i < 256; i++)
        //    {
        //        if (i < fmin)
        //        {
        //            inputCoefficients.Add(Convert.ToByte(i), 0);
        //        }

        //        if (i >= fmin && i < fmax)
        //        {
        //            byte g = Convert.ToByte((i - fmin) * coefficientDissection);

        //            inputCoefficients.Add(Convert.ToByte(i), g);
        //        }

        //        if (i >= fmax)
        //        {
        //            inputCoefficients.Add(Convert.ToByte(i), 255);
        //        }
        //    }
        //    return inputCoefficients;
        //}

        //private Dictionary<byte, byte> GetOutputDissectionCoefficients(byte fmin, byte fmax, byte gmin, byte gmax)
        //{
        //    double coefficientDissection = (double)(gmax - gmin) / fmax;

        //    var inputCoefficients = new Dictionary<byte, byte>();

        //    for (int i = 0; i <= 255; i++)
        //    {
        //        byte g = Convert.ToByte(i * coefficientDissection + gmin);

        //        inputCoefficients.Add(Convert.ToByte(i), g);
        //    }
        //    return inputCoefficients;
        //}

        //public Bitmap Resize(Bitmap original, int customWidth, int customHeight)
        //{
        //    int originalWidth = original.Width;
        //    int originalHeight = original.Height;

        //    float ratioX = (float)customWidth / originalWidth;
        //    float ratioY = (float)customHeight / originalHeight;
        //    float ratio = Math.Min(ratioX, ratioY);

        //    int newWidth = (int)(originalWidth * ratio);
        //    int newHeight = (int)(originalHeight * ratio);

        //    var newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

        //    using (var graphics = Graphics.FromImage(newImage))
        //    {
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.DrawImage(original, 0, 0, newWidth, newHeight);
        //    }

        //    return newImage;
        //}

        //public Bitmap FiltrationMinMax(Bitmap origin)
        //{
        //    return Filtration(Filtration(origin, TypeOfFiltration.Min), TypeOfFiltration.Max);
        //}

        //public Bitmap Filtration(Bitmap origin, TypeOfFiltration typeOfFiltration)
        //{
        //    var resultImage = new Bitmap(origin.Width, origin.Height, PixelFormat.Format24bppRgb);

        //    for (int i = 1; i < origin.Width - 1; i++)
        //    {
        //        for (int j = 1; j < origin.Height - 1; j++)
        //        {
        //            resultImage.SetPixel(i, j, FiltrationPixel(origin, i, j, typeOfFiltration));
                   
        //        }
        //    }
        //    return resultImage;
        //}

        //private Color FiltrationPixel(Bitmap image, int i, int j, TypeOfFiltration typeOfFiltration)
        //{
        //    var pixelBytes = new List<Color>();

        //    for (int k = i - 1; k < i + 2; k++)
        //    {
        //        for (int m = j - 1; m < j + 2; m++)
        //        {
        //            pixelBytes.Add(image.GetPixel(k, m));
        //        }
        //    }

        //    pixelBytes.RemoveAt(4);
        //    byte newR;
        //    byte newG;
        //    byte newB;

        //    switch (typeOfFiltration)
        //    {
        //        case TypeOfFiltration.Min:
        //            newR = MinFiltrationColor(pixelBytes.Select(p => p.R).ToList());
        //            newG = MinFiltrationColor(pixelBytes.Select(p => p.G).ToList());
        //            newB = MinFiltrationColor(pixelBytes.Select(p => p.B).ToList());
        //            break;
        //        case TypeOfFiltration.Max:
        //            newR = MaxFiltrationColor(pixelBytes.Select(p => p.R).ToList());
        //            newG = MaxFiltrationColor(pixelBytes.Select(p => p.G).ToList());
        //            newB = MaxFiltrationColor(pixelBytes.Select(p => p.B).ToList());
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(typeOfFiltration), typeOfFiltration, null);
        //    }

        //    return Color.FromArgb(newR, newG, newB);
        //}

        //private byte MinFiltrationColor(List<byte> colorBytes)
        //{
        //    colorBytes.Sort();
        //    return colorBytes.First();
        //}

        //private byte MaxFiltrationColor(List<byte> colorBytes)
        //{
        //    colorBytes.Sort();
        //    return colorBytes.Last();
        //}
    }
}
