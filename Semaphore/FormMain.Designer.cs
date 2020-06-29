namespace Semaphore
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSemaphoreFile = new System.Windows.Forms.TextBox();
            this.buttonSemaphoreFileFind = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMRZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "セマフォファイル：";
            // 
            // textBoxSemaphoreFile
            // 
            this.textBoxSemaphoreFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSemaphoreFile.Location = new System.Drawing.Point(143, 10);
            this.textBoxSemaphoreFile.Name = "textBoxSemaphoreFile";
            this.textBoxSemaphoreFile.Size = new System.Drawing.Size(361, 22);
            this.textBoxSemaphoreFile.TabIndex = 1;
            this.textBoxSemaphoreFile.TextChanged += new System.EventHandler(this.textBoxSemaphoreFile_TextChanged);
            // 
            // buttonSemaphoreFileFind
            // 
            this.buttonSemaphoreFileFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSemaphoreFileFind.Location = new System.Drawing.Point(510, 9);
            this.buttonSemaphoreFileFind.Name = "buttonSemaphoreFileFind";
            this.buttonSemaphoreFileFind.Size = new System.Drawing.Size(66, 23);
            this.buttonSemaphoreFileFind.TabIndex = 2;
            this.buttonSemaphoreFileFind.Text = "参照 ...";
            this.buttonSemaphoreFileFind.UseVisualStyleBackColor = true;
            this.buttonSemaphoreFileFind.Click += new System.EventHandler(this.buttonSemaphoreFileFind_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "OCRデータ：";
            // 
            // textBoxMRZ
            // 
            this.textBoxMRZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMRZ.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMRZ.Location = new System.Drawing.Point(143, 60);
            this.textBoxMRZ.Multiline = true;
            this.textBoxMRZ.Name = "textBoxMRZ";
            this.textBoxMRZ.ReadOnly = true;
            this.textBoxMRZ.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMRZ.Size = new System.Drawing.Size(433, 59);
            this.textBoxMRZ.TabIndex = 4;
            this.textBoxMRZ.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "可視光画像：";
            // 
            // pictureBoxColor
            // 
            this.pictureBoxColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxColor.Location = new System.Drawing.Point(143, 134);
            this.pictureBoxColor.Name = "pictureBoxColor";
            this.pictureBoxColor.Size = new System.Drawing.Size(433, 236);
            this.pictureBoxColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxColor.TabIndex = 6;
            this.pictureBoxColor.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 382);
            this.Controls.Add(this.pictureBoxColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMRZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSemaphoreFileFind);
            this.Controls.Add(this.textBoxSemaphoreFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(604, 421);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSemaphoreFile;
        private System.Windows.Forms.Button buttonSemaphoreFileFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMRZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxColor;
    }
}

