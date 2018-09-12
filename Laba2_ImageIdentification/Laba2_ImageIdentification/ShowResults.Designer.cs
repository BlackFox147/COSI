namespace Laba2_ImageIdentification
{
    partial class ShowResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.imagePathBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.processButton = new System.Windows.Forms.Button();
            this.originalHistoR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.originalHistoB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.originalHistoG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grayImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalHistoR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalHistoB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalHistoG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imagePathBox
            // 
            this.imagePathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePathBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagePathBox.Location = new System.Drawing.Point(12, 12);
            this.imagePathBox.Name = "imagePathBox";
            this.imagePathBox.Size = new System.Drawing.Size(384, 34);
            this.imagePathBox.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(403, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(105, 34);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // originalImage
            // 
            this.originalImage.Location = new System.Drawing.Point(12, 71);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(700, 393);
            this.originalImage.TabIndex = 2;
            this.originalImage.TabStop = false;
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(607, 12);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(105, 34);
            this.processButton.TabIndex = 3;
            this.processButton.Text = "GO";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // originalHistoR
            // 
            chartArea1.Name = "ChartArea1";
            this.originalHistoR.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.originalHistoR.Legends.Add(legend1);
            this.originalHistoR.Location = new System.Drawing.Point(742, 71);
            this.originalHistoR.Name = "originalHistoR";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.LegendText = "R";
            series1.Name = "R";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "G";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.Name = "B";
            this.originalHistoR.Series.Add(series1);
            this.originalHistoR.Series.Add(series2);
            this.originalHistoR.Series.Add(series3);
            this.originalHistoR.Size = new System.Drawing.Size(700, 393);
            this.originalHistoR.TabIndex = 9;
            this.originalHistoR.Text = "chart1";
            // 
            // originalHistoB
            // 
            chartArea2.Name = "ChartArea1";
            this.originalHistoB.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.originalHistoB.Legends.Add(legend2);
            this.originalHistoB.Location = new System.Drawing.Point(742, 487);
            this.originalHistoB.Name = "originalHistoB";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.LegendText = "R";
            series4.Name = "R";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series5.Legend = "Legend1";
            series5.Name = "G";
            series6.ChartArea = "ChartArea1";
            series6.Color = System.Drawing.Color.Blue;
            series6.Legend = "Legend1";
            series6.Name = "B";
            this.originalHistoB.Series.Add(series4);
            this.originalHistoB.Series.Add(series5);
            this.originalHistoB.Series.Add(series6);
            this.originalHistoB.Size = new System.Drawing.Size(700, 393);
            this.originalHistoB.TabIndex = 16;
            this.originalHistoB.Text = "chart1";
            // 
            // originalHistoG
            // 
            chartArea3.Name = "ChartArea1";
            this.originalHistoG.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.originalHistoG.Legends.Add(legend3);
            this.originalHistoG.Location = new System.Drawing.Point(12, 487);
            this.originalHistoG.Name = "originalHistoG";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.LegendText = "R";
            series7.Name = "R";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series8.Legend = "Legend1";
            series8.Name = "G";
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.Blue;
            series9.Legend = "Legend1";
            series9.Name = "B";
            this.originalHistoG.Series.Add(series7);
            this.originalHistoG.Series.Add(series8);
            this.originalHistoG.Series.Add(series9);
            this.originalHistoG.Size = new System.Drawing.Size(700, 393);
            this.originalHistoG.TabIndex = 17;
            this.originalHistoG.Text = "chart2";
            // 
            // grayImage
            // 
            this.grayImage.Location = new System.Drawing.Point(12, 914);
            this.grayImage.Name = "grayImage";
            this.grayImage.Size = new System.Drawing.Size(700, 393);
            this.grayImage.TabIndex = 18;
            this.grayImage.TabStop = false;
            // 
            // ShowResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1507, 953);
            this.Controls.Add(this.grayImage);
            this.Controls.Add(this.originalHistoG);
            this.Controls.Add(this.originalHistoB);
            this.Controls.Add(this.originalHistoR);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.originalImage);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePathBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First lab";
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalHistoR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalHistoB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalHistoG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imagePathBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart originalHistoR;
        private System.Windows.Forms.DataVisualization.Charting.Chart originalHistoB;
        private System.Windows.Forms.DataVisualization.Charting.Chart originalHistoG;
        private System.Windows.Forms.PictureBox grayImage;
    }
}

