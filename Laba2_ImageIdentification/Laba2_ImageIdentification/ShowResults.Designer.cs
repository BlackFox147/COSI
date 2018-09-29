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
            this.imagePathBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.processButton = new System.Windows.Forms.Button();
            this.openingImage = new System.Windows.Forms.PictureBox();
            this.binaryImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbin = new System.Windows.Forms.TextBox();
            this.resultImage = new System.Windows.Forms.PictureBox();
            this.areasImage = new System.Windows.Forms.PictureBox();
            this.clusteringImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numberOfClusters = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clusteringImage)).BeginInit();
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
            // openingImage
            // 
            this.openingImage.Location = new System.Drawing.Point(749, 497);
            this.openingImage.Name = "openingImage";
            this.openingImage.Size = new System.Drawing.Size(700, 393);
            this.openingImage.TabIndex = 18;
            this.openingImage.TabStop = false;
            // 
            // binaryImage
            // 
            this.binaryImage.Location = new System.Drawing.Point(12, 497);
            this.binaryImage.Name = "binaryImage";
            this.binaryImage.Size = new System.Drawing.Size(700, 393);
            this.binaryImage.TabIndex = 19;
            this.binaryImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(798, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 29);
            this.label2.TabIndex = 36;
            this.label2.Text = "R";
            // 
            // rbin
            // 
            this.rbin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbin.Location = new System.Drawing.Point(848, 12);
            this.rbin.Name = "rbin";
            this.rbin.Size = new System.Drawing.Size(100, 34);
            this.rbin.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(986, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "C";
            // 
            // cbin
            // 
            this.cbin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbin.Location = new System.Drawing.Point(1022, 14);
            this.cbin.Name = "cbin";
            this.cbin.Size = new System.Drawing.Size(100, 34);
            this.cbin.TabIndex = 37;
            // 
            // resultImage
            // 
            this.resultImage.Location = new System.Drawing.Point(749, 71);
            this.resultImage.Name = "resultImage";
            this.resultImage.Size = new System.Drawing.Size(700, 393);
            this.resultImage.TabIndex = 39;
            this.resultImage.TabStop = false;
            // 
            // areasImage
            // 
            this.areasImage.Location = new System.Drawing.Point(12, 922);
            this.areasImage.Name = "areasImage";
            this.areasImage.Size = new System.Drawing.Size(700, 393);
            this.areasImage.TabIndex = 40;
            this.areasImage.TabStop = false;
            // 
            // clusteringImage
            // 
            this.clusteringImage.Location = new System.Drawing.Point(749, 922);
            this.clusteringImage.Name = "clusteringImage";
            this.clusteringImage.Size = new System.Drawing.Size(700, 393);
            this.clusteringImage.TabIndex = 41;
            this.clusteringImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1158, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 29);
            this.label3.TabIndex = 43;
            this.label3.Text = "k";
            // 
            // numberOfClusters
            // 
            this.numberOfClusters.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfClusters.Location = new System.Drawing.Point(1194, 14);
            this.numberOfClusters.Name = "numberOfClusters";
            this.numberOfClusters.Size = new System.Drawing.Size(100, 34);
            this.numberOfClusters.TabIndex = 42;
            // 
            // ShowResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1507, 953);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberOfClusters);
            this.Controls.Add(this.clusteringImage);
            this.Controls.Add(this.areasImage);
            this.Controls.Add(this.resultImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbin);
            this.Controls.Add(this.binaryImage);
            this.Controls.Add(this.openingImage);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.originalImage);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imagePathBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First lab";
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clusteringImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imagePathBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.PictureBox openingImage;
        private System.Windows.Forms.PictureBox binaryImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rbin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cbin;
        private System.Windows.Forms.PictureBox resultImage;
        private System.Windows.Forms.PictureBox areasImage;
        private System.Windows.Forms.PictureBox clusteringImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numberOfClusters;
    }
}

