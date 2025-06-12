namespace VideoTranscript.UI
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox2 = new GroupBox();
            btnOpenAIKey = new Button();
            lblFile = new Label();
            btnTranscribeVideo = new Button();
            btnSelectFile = new Button();
            panel1 = new Panel();
            lblTime = new Label();
            rtbText = new RichTextBox();
            openFileDialog = new OpenFileDialog();
            timer = new System.Windows.Forms.Timer(components);
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnOpenAIKey);
            groupBox2.Controls.Add(lblFile);
            groupBox2.Controls.Add(btnTranscribeVideo);
            groupBox2.Controls.Add(btnSelectFile);
            groupBox2.Location = new Point(11, 11);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(967, 60);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Action";
            // 
            // btnOpenAIKey
            // 
            btnOpenAIKey.Location = new Point(15, 22);
            btnOpenAIKey.Name = "btnOpenAIKey";
            btnOpenAIKey.Size = new Size(103, 26);
            btnOpenAIKey.TabIndex = 5;
            btnOpenAIKey.Text = "OpenAi Key";
            btnOpenAIKey.UseVisualStyleBackColor = true;
            btnOpenAIKey.Click += button1_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new Point(382, 33);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(38, 15);
            lblFile.TabIndex = 4;
            lblFile.Text = "label1";
            // 
            // btnTranscribeVideo
            // 
            btnTranscribeVideo.Location = new Point(246, 21);
            btnTranscribeVideo.Margin = new Padding(3, 2, 3, 2);
            btnTranscribeVideo.Name = "btnTranscribeVideo";
            btnTranscribeVideo.Size = new Size(130, 27);
            btnTranscribeVideo.TabIndex = 3;
            btnTranscribeVideo.Text = "Transcribe Video";
            btnTranscribeVideo.UseVisualStyleBackColor = true;
            btnTranscribeVideo.Click += btnTranscribeVideo_Click;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(124, 21);
            btnSelectFile.Margin = new Padding(3, 2, 3, 2);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(116, 27);
            btnSelectFile.TabIndex = 2;
            btnSelectFile.Text = "Select File";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblTime);
            panel1.Controls.Add(groupBox2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 87);
            panel1.TabIndex = 4;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(984, 56);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(38, 15);
            lblTime.TabIndex = 5;
            lblTime.Text = "label1";
            // 
            // rtbText
            // 
            rtbText.Dock = DockStyle.Fill;
            rtbText.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbText.Location = new Point(0, 87);
            rtbText.Margin = new Padding(3, 2, 3, 2);
            rtbText.Name = "rtbText";
            rtbText.ReadOnly = true;
            rtbText.Size = new Size(1105, 473);
            rtbText.TabIndex = 5;
            rtbText.Text = "";
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 560);
            Controls.Add(rtbText);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "Video Transcript";
            WindowState = FormWindowState.Maximized;
            Load += FrmMain_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button btnSelectFile;
        private Panel panel1;
        private RichTextBox rtbText;
        private Label lblFile;
        private Button btnTranscribeVideo;
        private OpenFileDialog openFileDialog;
        private Label lblTime;
        private System.Windows.Forms.Timer timer;
        private Button btnOpenAIKey;
    }
}
