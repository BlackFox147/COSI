using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Laba2_ImageIdentification.Histogram.Models;

namespace Laba2_ImageIdentification
{
    public partial class ShowResults : Form
    {
        private string _imagePath;

        private Bitmap _image;

        private readonly ImageProcessing.ImageProcessing _imageProcessor;
        private readonly Histogram.HistogramProcessing _histogramProcessing;

        public ShowResults()
        {
            InitializeComponent();

            _imageProcessor = new ImageProcessing.ImageProcessing();
            _histogramProcessing = new Histogram.HistogramProcessing();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "png files (*.png)|*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _imagePath = openFileDialog.FileName;
                    if (!string.IsNullOrEmpty(_imagePath))
                    {
                        imagePathBox.Text = _imagePath;
                        LoadImage();
                    }
                }
            }
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(rbin.Text)
                //    || string.IsNullOrEmpty(cbin.Text))
                //{
                //    MessageBox.Show(this, "Constant value is invalid!");
                //}
                //else
                //{
                //int c = Convert.ToInt32(cbin.Text);
                //int r = Convert.ToInt32(rbin.Text);

                //var greyProcessing = _imageProcessor.GetGreyImage(_image);

                //var binaryProcessing = _imageProcessor.getBlackWight_Ad(greyProcessing, r, c);

                //binaryImage.Image = _imageProcessor.CreateImage(binaryProcessing);

                //var openingProcessing = _imageProcessor.Opening(binaryProcessing);

                //grayImage.Image = _imageProcessor.CreateImage(openingProcessing);




                var openingProcessing = _imageProcessor.Opening(_imageProcessor.CreateArrayBytes(_image));
                

                var temp =_imageProcessor.SelectionOfConnecteAreas(openingProcessing, _imageProcessor.CreateImage(openingProcessing));
                grayImage.Image = temp;





                //dilationImageProcessing.Save("D:\\dil.png",ImageFormat.Png);
                //binaryProcessing.Save("D:\\bin.png", ImageFormat.Png);

                //dilationImageProcessing.Save("D:\\dil.png", ImageFormat.Png);

                //int hp = _imageProcessor.getHp(_histogramProcessing.CalculateHistogram(greyImageProcessing));



                //}
                //}
            }
            catch (FormatException)
            {
                MessageBox.Show(this, "Constant value is invalid!");
            }
        }

        private void LoadImage()
        {
            _image = _imageProcessor.Resize(new Bitmap(_imagePath), originalImage.Width, originalImage.Height);

            originalImage.Image = _image;
        }

        private void DrawChannelHistograms(IList<ChannelHistogram> histograms, Chart chartR, Chart chartG, Chart chartB)
        {
            var rHistogram = histograms.First(h => h.TypeOfСhannel == TypeOfСhannel.RedСhannel).Histogram;
            var gHistogram = histograms.First(h => h.TypeOfСhannel == TypeOfСhannel.GreenСhannel).Histogram;
            var bHistogram = histograms.First(h => h.TypeOfСhannel == TypeOfСhannel.BlueСhannel).Histogram;

            for (int i = 0; i < 256; i++)
            {
                chartR.Series["R"].Points.AddXY(i, rHistogram.Keys.Contains((byte)i) ? rHistogram[(byte)i] : 0);
                chartG.Series["G"].Points.AddXY(i, gHistogram.Keys.Contains((byte)i) ? gHistogram[(byte)i] : 0);
                chartB.Series["B"].Points.AddXY(i, bHistogram.Keys.Contains((byte)i) ? bHistogram[(byte)i] : 0);
            }
        }
    }
}
