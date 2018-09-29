using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laba2_ImageIdentification
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
            
            rbin.Text = Convert.ToString(30);
            cbin.Text = Convert.ToString(20);
            numberOfClusters.Text = Convert.ToString(2);
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
                if (string.IsNullOrEmpty(rbin.Text)
                    || string.IsNullOrEmpty(cbin.Text)
                    || string.IsNullOrEmpty(numberOfClusters.Text))
                {
                    MessageBox.Show(this, "Constant value is invalid!");
                }
                else
                {
                    int c = Convert.ToInt32(cbin.Text);
                    int r = Convert.ToInt32(rbin.Text);
                    int number = Convert.ToInt32(numberOfClusters.Text);

                    var greyProcessing = _imageProcessor.GetGreyImage(_image);

                    var binaryProcessing = _imageProcessor.getBlackWight_Ad(greyProcessing, r, c);
                    binaryImage.Image = _imageProcessor.CreateImage(binaryProcessing);

                    var openingProcessing = _imageProcessor.Opening(binaryProcessing);
                    var openingTempImage = _imageProcessor.CreateImage(openingProcessing);
                    openingImage.Image = openingTempImage;

                    var shapes =_imageProcessor.SelectionOfConnecteAreas(openingProcessing);
                    areasImage.Image = _imageProcessor.ShowConnecteAreas(shapes);

                    var clusteringShapes = _imageProcessor.Cluster(shapes, number);
                    resultImage.Image = _imageProcessor.UnhideClustering(clusteringShapes, openingTempImage);

                    //var resultProcessing = _imageProcessor.UnhideClustering(clusteringShapes, _image);
                    //resultImage.Image = resultProcessing;

                    //dilationImageProcessing.Save("D:\\dil.png",ImageFormat.Png);
                    //binaryProcessing.Save("D:\\bin.png", ImageFormat.Png);

                    //dilationImageProcessing.Save("D:\\dil.png", ImageFormat.Png);

                    //int hp = _imageProcessor.getHp(_histogramProcessing.CalculateHistogram(greyImageProcessing));



                }
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
    }
}
