using System;
using System.Collections.Generic;
using System.Drawing;
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
                //if (string.IsNullOrEmpty(fmin.Text)
                //    || string.IsNullOrEmpty(fmax.Text)
                //    || string.IsNullOrEmpty(gmin.Text)
                //    || string.IsNullOrEmpty(gmax.Text))
                //{
                //    MessageBox.Show(this, "Constant value is invalid!");
                //}
                //else
                //{
                //    double c = Convert.ToDouble(fmin.Text);

                    DrawChannelHistograms(_histogramProcessing.CalculateHistogram(_image), originalHistoR, originalHistoG, originalHistoB);

                    //var increaseImage = _imageProcessor
                    //    .Dissection(_image, Convert.ToByte(fmin.Text), Convert.ToByte(fmax.Text), 0, 255, TypeOfDissection.RestrictionOfInputBrightness);
                    //increaseBrightnessImage.Image = increaseImage;
                    //DrawChannelHistograms(_imageProcessor.CalculateHistogram(increaseImage), increaseBrightnessR, increaseBrightnessG, increaseBrightnessB);

                    //var loweringImage = _imageProcessor
                    //    .Dissection(_image, 0, 255, Convert.ToByte(gmin.Text), Convert.ToByte(gmax.Text), TypeOfDissection.RestrictionOfOutputBrightness);
                    //loweringBightnessImage.Image = loweringImage;
                    //DrawChannelHistograms(_imageProcessor.CalculateHistogram(loweringImage), loweringBightnessR, loweringBightnessG, loweringBightnessB);

                    //var filteredMinImage = _imageProcessor
                    //    .Filtration(_image, TypeOfFiltration.Min);
                    //minFiltrationImage.Image = filteredMinImage;
                    //DrawChannelHistograms(_imageProcessor.CalculateHistogram(filteredMinImage), minFiltrationR, minFiltrationG, minFiltrationB);

                    //var filteredMaxImage = _imageProcessor
                    //    .Filtration(_image, TypeOfFiltration.Max);
                    //maxFiltrationImage.Image = filteredMaxImage;
                    //DrawChannelHistograms(_imageProcessor.CalculateHistogram(filteredMaxImage), maxFiltrationR, maxFiltrationG, maxFiltrationB);

                    //var filteredMinMaxImage = _imageProcessor
                    //    .FiltrationMinMax(_image);
                    //minMaxFiltrationImage.Image = filteredMinMaxImage;
                    //DrawChannelHistograms(_imageProcessor.CalculateHistogram(filteredMinMaxImage), minMaxFiltrationR, minMaxFiltrationG, minMaxFiltrationB);

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
