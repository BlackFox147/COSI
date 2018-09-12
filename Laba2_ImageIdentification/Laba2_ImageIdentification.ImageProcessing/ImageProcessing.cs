using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_ImageIdentification.ImageProcessing
{
    public class ImageProcessing
    {
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

        // кнопка Ч/Б
        public Bitmap GetGreyImage(Bitmap original)
        {

            // создаём Bitmap из изображения, находящегося в pictureBox1
            //Bitmap input = new Bitmap(pictureBox1.Image);
            // создаём Bitmap для черно-белого изображения
            var resultImage = new Bitmap(original, original.Width, original.Height);
            // перебираем в циклах все пиксели исходного изображения
            for (int j = 0; j < original.Height; j++)
            {
                for (int i = 0; i < original.Width; i++)
                {
                    // получаем (i, j) пиксель
                    var pixel = (original.GetPixel(i, j));
                    // получаем компоненты цветов пикселя


                    byte R = pixel.R; // красный
                    byte G = pixel.G; // зеленый
                    byte B = pixel.B;

                    byte I = Convert.ToByte((double)0.2125 * R + 0.7154 * G + 0.0721 * B);
                    // синий
                    // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
                    //R = G = B = (R + G + B) / 3.0f;
                    // собираем новый пиксель по частям (по каналам)
                    //UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                    // добавляем его в Bitmap нового изображения
                    //resultImage.SetPixel(i, j, Color.FromArgb((int)newPixel));

                    resultImage.SetPixel(i, j, Color.FromArgb(I, I, I));
                }
            }

            // выводим черно-белый Bitmap в pictureBox2
            //pictureBox2.Image = output;
            return resultImage;
        }
    }
}
