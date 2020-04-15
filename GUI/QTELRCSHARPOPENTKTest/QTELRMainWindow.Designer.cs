namespace QTELR_Interface
{
    partial class QTELRMainWindow
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
            this.glControl1 = new OpenTK.GLControl();
            this.trackBar_rotateX = new System.Windows.Forms.TrackBar();
            this.trackBar_rotateY = new System.Windows.Forms.TrackBar();
            this.trackBar_rotateZ = new System.Windows.Forms.TrackBar();
            this.trackBar_panX = new System.Windows.Forms.TrackBar();
            this.trackBar_panY = new System.Windows.Forms.TrackBar();
            this.trackBar_panZ = new System.Windows.Forms.TrackBar();
            this.trackBar_zoom = new System.Windows.Forms.TrackBar();
            this.rotateX = new System.Windows.Forms.Label();
            this.rotateY = new System.Windows.Forms.Label();
            this.rotateZ = new System.Windows.Forms.Label();
            this.panX = new System.Windows.Forms.Label();
            this.panY = new System.Windows.Forms.Label();
            this.panZ = new System.Windows.Forms.Label();
            this.textBox_FileDirectory = new System.Windows.Forms.TextBox();
            this.label_DirectoryFile = new System.Windows.Forms.Label();
            this.zoom = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.textBox_FileDirectory = new System.Windows.Forms.TextBox();
            this.bitmapDisplayBox = new System.Windows.Forms.PictureBox();
            this.panZ = new System.Windows.Forms.Label();
            this.trackBar_panZ = new System.Windows.Forms.TrackBar();
            this.cameraPositionLabel = new System.Windows.Forms.Label();
            this.lookingAtLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotateX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotateZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_panX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_panY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitmapDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_panZ)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(187, 12);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(475, 360);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // trackBar_rotateX
            // 
            this.trackBar_rotateX.Location = new System.Drawing.Point(74, 30);
            this.trackBar_rotateX.Maximum = 1095;
            this.trackBar_rotateX.Name = "trackBar_rotateX";
            this.trackBar_rotateX.Size = new System.Drawing.Size(104, 45);
            this.trackBar_rotateX.TabIndex = 6;
            this.trackBar_rotateX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_rotateX.ValueChanged += new System.EventHandler(this.trackBar_rotateX_ValueChanged);
            // 
            // trackBar_rotateY
            // 
            this.trackBar_rotateY.Location = new System.Drawing.Point(74, 60);
            this.trackBar_rotateY.Maximum = 359;
            this.trackBar_rotateY.Name = "trackBar_rotateY";
            this.trackBar_rotateY.Size = new System.Drawing.Size(104, 45);
            this.trackBar_rotateY.TabIndex = 7;
            this.trackBar_rotateY.TickFrequency = 10;
            this.trackBar_rotateY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_rotateY.ValueChanged += new System.EventHandler(this.trackBar_rotateY_ValueChanged);
            // 
            // trackBar_rotateZ
            // 
            this.trackBar_rotateZ.Location = new System.Drawing.Point(74, 111);
            this.trackBar_rotateZ.Maximum = 359;
            this.trackBar_rotateZ.Name = "trackBar_rotateZ";
            this.trackBar_rotateZ.Size = new System.Drawing.Size(104, 45);
            this.trackBar_rotateZ.TabIndex = 8;
            this.trackBar_rotateZ.TickFrequency = 10;
            this.trackBar_rotateZ.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_rotateZ.ValueChanged += new System.EventHandler(this.trackBar_rotateZ_ValueChanged);
            // 
            // trackBar_panX
            // 
            this.trackBar_panX.Location = new System.Drawing.Point(77, 172);
            this.trackBar_panX.Maximum = 10000;
            this.trackBar_panX.Minimum = -10000;
            this.trackBar_panX.Name = "trackBar_panX";
            this.trackBar_panX.Size = new System.Drawing.Size(104, 45);
            this.trackBar_panX.TabIndex = 9;
            this.trackBar_panX.TickFrequency = 100;
            this.trackBar_panX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_panX.ValueChanged += new System.EventHandler(this.trackBar_panX_ValueChanged);
            // 
            // trackBar_panY
            // 
            this.trackBar_panY.Location = new System.Drawing.Point(77, 224);
            this.trackBar_panY.Maximum = 10000;
            this.trackBar_panY.Minimum = -10000;
            this.trackBar_panY.Name = "trackBar_panY";
            this.trackBar_panY.Size = new System.Drawing.Size(104, 45);
            this.trackBar_panY.TabIndex = 10;
            this.trackBar_panY.TickFrequency = 100;
            this.trackBar_panY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_panY.ValueChanged += new System.EventHandler(this.trackBar_panY_ValueChanged);
            // 
            // trackBar_zoom
            // 
            this.trackBar_zoom.Location = new System.Drawing.Point(79, 307);
            this.trackBar_zoom.Maximum = 10000;
            this.trackBar_zoom.Name = "trackBar_zoom";
            this.trackBar_zoom.Size = new System.Drawing.Size(104, 45);
            this.trackBar_zoom.TabIndex = 11;
            this.trackBar_zoom.TickFrequency = 10;
            this.trackBar_zoom.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_zoom.ValueChanged += new System.EventHandler(this.trackBar_zoom_ValueChanged);
            // 
            // rotateX
            // 
            this.rotateX.AutoSize = true;
            this.rotateX.Location = new System.Drawing.Point(22, 30);
            this.rotateX.Name = "rotateX";
            this.rotateX.Size = new System.Drawing.Size(49, 13);
            this.rotateX.TabIndex = 13;
            this.rotateX.Text = "Rotate X";
            // 
            // rotateY
            // 
            this.rotateY.AutoSize = true;
            this.rotateY.Location = new System.Drawing.Point(19, 74);
            this.rotateY.Name = "rotateY";
            this.rotateY.Size = new System.Drawing.Size(49, 13);
            this.rotateY.TabIndex = 14;
            this.rotateY.Text = "Rotate Y";
            // 
            // rotateZ
            // 
            this.rotateZ.AutoSize = true;
            this.rotateZ.Location = new System.Drawing.Point(19, 120);
            this.rotateZ.Name = "rotateZ";
            this.rotateZ.Size = new System.Drawing.Size(49, 13);
            this.rotateZ.TabIndex = 15;
            this.rotateZ.Text = "Rotate Z";
            // 
            // panX
            // 
            this.panX.AutoSize = true;
            this.panX.Location = new System.Drawing.Point(35, 186);
            this.panX.Name = "panX";
            this.panX.Size = new System.Drawing.Size(36, 13);
            this.panX.TabIndex = 16;
            this.panX.Text = "Pan X";
            // 
            // panY
            // 
            this.panY.AutoSize = true;
            this.panY.Location = new System.Drawing.Point(35, 238);
            this.panY.Name = "panY";
            this.panY.Size = new System.Drawing.Size(36, 13);
            this.panY.TabIndex = 17;
            this.panY.Text = "Pan Y";
            // 
            // zoom
            // 
            this.zoom.AutoSize = true;
            this.zoom.Location = new System.Drawing.Point(37, 321);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(34, 13);
            this.zoom.TabIndex = 18;
            this.zoom.Text = "Zoom";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Location = new System.Drawing.Point(353, 428);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(71, 23);
            this.button_OpenFile.TabIndex = 19;
            this.button_OpenFile.Text = "Browse File";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // textBox_FileDirectory
            // 
            this.textBox_FileDirectory.Location = new System.Drawing.Point(439, 430);
            this.textBox_FileDirectory.Name = "textBox_FileDirectory";
            this.textBox_FileDirectory.Size = new System.Drawing.Size(223, 20);
            this.textBox_FileDirectory.TabIndex = 20;
            // 
            // bitmapDisplayBox
            // 
            this.bitmapDisplayBox.Location = new System.Drawing.Point(249, 378);
            this.bitmapDisplayBox.Name = "bitmapDisplayBox";
            this.bitmapDisplayBox.Size = new System.Drawing.Size(98, 79);
            this.bitmapDisplayBox.TabIndex = 21;
            this.bitmapDisplayBox.TabStop = false;
            // 
            // panZ
            // 
            this.panZ.AutoSize = true;
            this.panZ.Location = new System.Drawing.Point(32, 280);
            this.panZ.Name = "panZ";
            this.panZ.Size = new System.Drawing.Size(36, 13);
            this.panZ.TabIndex = 23;
            this.panZ.Text = "Pan Z";
            // 
            // trackBar_panZ
            // 
            this.trackBar_panZ.Location = new System.Drawing.Point(74, 266);
            this.trackBar_panZ.Maximum = 10000;
            this.trackBar_panZ.Minimum = -10000;
            this.trackBar_panZ.Name = "trackBar_panZ";
            this.trackBar_panZ.Size = new System.Drawing.Size(104, 45);
            this.trackBar_panZ.TabIndex = 22;
            this.trackBar_panZ.TickFrequency = 100;
            this.trackBar_panZ.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_panZ.ValueChanged += new System.EventHandler(this.trackBar_panZ_ValueChanged);
            // 
            // cameraPositionLabel
            // 
            this.cameraPositionLabel.AutoSize = true;
            this.cameraPositionLabel.Location = new System.Drawing.Point(13, 378);
            this.cameraPositionLabel.Name = "cameraPositionLabel";
            this.cameraPositionLabel.Size = new System.Drawing.Size(35, 13);
            this.cameraPositionLabel.TabIndex = 24;
            this.cameraPositionLabel.Text = "label1";
            // 
            // lookingAtLabel
            // 
            this.lookingAtLabel.AutoSize = true;
            this.lookingAtLabel.Location = new System.Drawing.Point(12, 403);
            this.lookingAtLabel.Name = "lookingAtLabel";
            this.lookingAtLabel.Size = new System.Drawing.Size(35, 13);
            this.lookingAtLabel.TabIndex = 25;
            this.lookingAtLabel.Text = "label2";
            // 
            // QTELRMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 463);
            this.Controls.Add(this.lookingAtLabel);
            this.Controls.Add(this.cameraPositionLabel);
            this.Controls.Add(this.panZ);
            this.Controls.Add(this.trackBar_panZ);
            this.Controls.Add(this.bitmapDisplayBox);
            this.Controls.Add(this.textBox_FileDirectory);
            this.Controls.Add(this.button_OpenFile);
            this.Controls.Add(this.zoom);
            this.Controls.Add(this.panY);
            this.Controls.Add(this.panX);
            this.Controls.Add(this.rotateZ);
            this.Controls.Add(this.rotateY);
            this.Controls.Add(this.rotateX);
            this.Controls.Add(this.trackBar_zoom);
            this.Controls.Add(this.trackBar_panY);
            this.Controls.Add(this.trackBar_panX);
            this.Controls.Add(this.trackBar_rotateZ);
            this.Controls.Add(this.trackBar_rotateY);
            this.Controls.Add(this.trackBar_rotateX);
            this.Controls.Add(this.glControl1);
            this.Name = "QTELRMainWindow";
            this.Text = "Quick Telemtetry Relay";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotateX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rotateZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_panX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_panY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitmapDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_panZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.TrackBar trackBar_rotateX;
        private System.Windows.Forms.TrackBar trackBar_rotateY;
        private System.Windows.Forms.TrackBar trackBar_rotateZ;
        private System.Windows.Forms.TrackBar trackBar_panX;
        private System.Windows.Forms.TrackBar trackBar_panY;
        private System.Windows.Forms.TrackBar trackBar_zoom;
        private System.Windows.Forms.Label rotateX;
        private System.Windows.Forms.Label rotateY;
        private System.Windows.Forms.Label rotateZ;
        private System.Windows.Forms.Label panX;
        private System.Windows.Forms.Label panY;
        private System.Windows.Forms.Label zoom;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.TextBox textBox_FileDirectory;
        private System.Windows.Forms.PictureBox bitmapDisplayBox;
        private System.Windows.Forms.Label panZ;
        private System.Windows.Forms.TrackBar trackBar_panZ;
        private System.Windows.Forms.Label cameraPositionLabel;
        private System.Windows.Forms.Label lookingAtLabel;
    }
}