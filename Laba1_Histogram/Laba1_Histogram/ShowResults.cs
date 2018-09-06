using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Laba1_Histogram.ImageProcessing.Models;

namespace Laba1_Histogram
{
    public partial class ShowResults : Form
    {
        private string _imagePath;

        private Bitmap _image;

        private readonly ImageProcessing.ImageProcessing _imageProcessor;

        public ShowResults()
        {
            InitializeComponent();
            
            _imageProcessor = new ImageProcessing.ImageProcessing();
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
                if (string.IsNullOrEmpty(constant.Text))
                {
                    MessageBox.Show(this, "Constant value is invalid!");
                }
                else
                {
                    double c = Convert.ToDouble(constant.Text);

                    DrawChannelHistograms(_imageProcessor.Calculate(_image), originalHisto);

                    //var changedImage = this._imageProcessor.LogCorrection(this._image, c);
                    //this.changedImageBox.Image = (Image)changedImage;
                    //this.DrawChannelHistograms(this._imageProcessor.Calculate(changedImage), this.changedHisto);

                    //var filteredImage = this._imageProcessor.RobertsonFilter(this._image);
                    //this.filteredImage.Image = filteredImage;
                    //this.DrawChannelHistograms(this._imageProcessor.Calculate(filteredImage), this.filteredHisto);
                }
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

        private static void DrawChannelHistograms(IList<ChannelHistogram> histograms, Chart chart)
        {
            var rHistogram = histograms.First(h => h.TypeOfСhannel == TypeOfСhannel.RedСhannel).Histogram;
            var gHistogram = histograms.First(h => h.TypeOfСhannel == TypeOfСhannel.GreenСhannel).Histogram;
            var bHistogram = histograms.First(h => h.TypeOfСhannel == TypeOfСhannel.BlueСhannel).Histogram;

            for (int i = 0; i < 256; i++)
            {
                chart.Series["R"].Points.AddXY(i, rHistogram.Keys.Contains((byte) i) ? rHistogram[(byte) i] : 0);
                chart.Series["G"].Points.AddXY(i, gHistogram.Keys.Contains((byte) i) ? gHistogram[(byte) i] : 0);
                chart.Series["B"].Points.AddXY(i, bHistogram.Keys.Contains((byte) i) ? bHistogram[(byte) i] : 0);
            }
        }
    }
}
