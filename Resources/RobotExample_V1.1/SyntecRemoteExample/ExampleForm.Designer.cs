namespace SyntecRemoteClient
{
    partial class ExampleForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExampleForm));
			this.btnNCFileList = new System.Windows.Forms.Button();
			this.lbInformation = new System.Windows.Forms.ListBox();
			this.btnUploadNCFile = new System.Windows.Forms.Button();
			this.btnDeleteNCFile = new System.Windows.Forms.Button();
			this.btnInformation = new System.Windows.Forms.Button();
			this.btnStatus = new System.Windows.Forms.Button();
			this.lbJointCoord = new System.Windows.Forms.ListBox();
			this.lbTCP = new System.Windows.Forms.ListBox();
			this.labelMechCoord = new System.Windows.Forms.Label();
			this.labelAbsCoord = new System.Windows.Forms.Label();
			this.labelInformation = new System.Windows.Forms.Label();
			this.btnDownloadNCFile = new System.Windows.Forms.Button();
			this.btnSetMainNC = new System.Windows.Forms.Button();
			this.btnAuto = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.lbConnectedIP = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnRateDown = new System.Windows.Forms.Button();
			this.btnRateUp = new System.Windows.Forms.Button();
			this.tbInputIP = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbPLCbits = new System.Windows.Forms.TextBox();
			this.btnRead = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnJOG = new System.Windows.Forms.Button();
			this.btnCoord = new System.Windows.Forms.Button();
			this.btnXBack = new System.Windows.Forms.Button();
			this.btnXFore = new System.Windows.Forms.Button();
			this.btnYBack = new System.Windows.Forms.Button();
			this.btnYFore = new System.Windows.Forms.Button();
			this.btnZBack = new System.Windows.Forms.Button();
			this.btnZFore = new System.Windows.Forms.Button();
			this.btnABack = new System.Windows.Forms.Button();
			this.btnBBack = new System.Windows.Forms.Button();
			this.btnCBack = new System.Windows.Forms.Button();
			this.btnAFore = new System.Windows.Forms.Button();
			this.btnBFore = new System.Windows.Forms.Button();
			this.btnCFore = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnNCFileList
			// 
			this.btnNCFileList.Location = new System.Drawing.Point(30, 185);
			this.btnNCFileList.Name = "btnNCFileList";
			this.btnNCFileList.Size = new System.Drawing.Size(160, 25);
			this.btnNCFileList.TabIndex = 23;
			this.btnNCFileList.Text = "NC File List";
			this.btnNCFileList.UseVisualStyleBackColor = true;
			this.btnNCFileList.Click += new System.EventHandler(this.btnNCFileList_Click);
			// 
			// lbInformation
			// 
			this.lbInformation.FormattingEnabled = true;
			this.lbInformation.ItemHeight = 12;
			this.lbInformation.Location = new System.Drawing.Point(360, 235);
			this.lbInformation.Name = "lbInformation";
			this.lbInformation.Size = new System.Drawing.Size(280, 172);
			this.lbInformation.TabIndex = 24;
			// 
			// btnUploadNCFile
			// 
			this.btnUploadNCFile.Location = new System.Drawing.Point(30, 220);
			this.btnUploadNCFile.Name = "btnUploadNCFile";
			this.btnUploadNCFile.Size = new System.Drawing.Size(160, 25);
			this.btnUploadNCFile.TabIndex = 25;
			this.btnUploadNCFile.Text = "Upload NC File";
			this.btnUploadNCFile.UseVisualStyleBackColor = true;
			this.btnUploadNCFile.Click += new System.EventHandler(this.btnUploadNCFile_Click);
			// 
			// btnDeleteNCFile
			// 
			this.btnDeleteNCFile.Location = new System.Drawing.Point(30, 290);
			this.btnDeleteNCFile.Name = "btnDeleteNCFile";
			this.btnDeleteNCFile.Size = new System.Drawing.Size(160, 25);
			this.btnDeleteNCFile.TabIndex = 55;
			this.btnDeleteNCFile.Text = "Delete NC File";
			this.btnDeleteNCFile.UseVisualStyleBackColor = true;
			this.btnDeleteNCFile.Click += new System.EventHandler(this.btnDeleteNCFile_Click);
			// 
			// btnInformation
			// 
			this.btnInformation.Location = new System.Drawing.Point(30, 115);
			this.btnInformation.Name = "btnInformation";
			this.btnInformation.Size = new System.Drawing.Size(160, 25);
			this.btnInformation.TabIndex = 59;
			this.btnInformation.Text = "Information";
			this.btnInformation.UseVisualStyleBackColor = true;
			this.btnInformation.Click += new System.EventHandler(this.btnInformation_Click);
			// 
			// btnStatus
			// 
			this.btnStatus.Location = new System.Drawing.Point(30, 150);
			this.btnStatus.Name = "btnStatus";
			this.btnStatus.Size = new System.Drawing.Size(160, 25);
			this.btnStatus.TabIndex = 60;
			this.btnStatus.Text = "Status";
			this.btnStatus.UseVisualStyleBackColor = true;
			this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
			// 
			// lbJointCoord
			// 
			this.lbJointCoord.FormattingEnabled = true;
			this.lbJointCoord.ItemHeight = 12;
			this.lbJointCoord.Location = new System.Drawing.Point(360, 35);
			this.lbJointCoord.Name = "lbJointCoord";
			this.lbJointCoord.Size = new System.Drawing.Size(130, 172);
			this.lbJointCoord.TabIndex = 77;
			// 
			// lbTCP
			// 
			this.lbTCP.FormattingEnabled = true;
			this.lbTCP.ItemHeight = 12;
			this.lbTCP.Location = new System.Drawing.Point(510, 35);
			this.lbTCP.Name = "lbTCP";
			this.lbTCP.Size = new System.Drawing.Size(130, 172);
			this.lbTCP.TabIndex = 89;
			// 
			// labelMechCoord
			// 
			this.labelMechCoord.AutoSize = true;
			this.labelMechCoord.Location = new System.Drawing.Point(360, 20);
			this.labelMechCoord.Name = "labelMechCoord";
			this.labelMechCoord.Size = new System.Drawing.Size(82, 12);
			this.labelMechCoord.TabIndex = 93;
			this.labelMechCoord.Text = "Joint Coordinate";
			// 
			// labelAbsCoord
			// 
			this.labelAbsCoord.AutoSize = true;
			this.labelAbsCoord.Location = new System.Drawing.Point(510, 20);
			this.labelAbsCoord.Name = "labelAbsCoord";
			this.labelAbsCoord.Size = new System.Drawing.Size(120, 12);
			this.labelAbsCoord.TabIndex = 94;
			this.labelAbsCoord.Text = "Tool Center Point (TCP)";
			// 
			// labelInformation
			// 
			this.labelInformation.AutoSize = true;
			this.labelInformation.Location = new System.Drawing.Point(360, 220);
			this.labelInformation.Name = "labelInformation";
			this.labelInformation.Size = new System.Drawing.Size(100, 12);
			this.labelInformation.TabIndex = 95;
			this.labelInformation.Text = "Current Information";
			// 
			// btnDownloadNCFile
			// 
			this.btnDownloadNCFile.Location = new System.Drawing.Point(30, 255);
			this.btnDownloadNCFile.Name = "btnDownloadNCFile";
			this.btnDownloadNCFile.Size = new System.Drawing.Size(160, 25);
			this.btnDownloadNCFile.TabIndex = 96;
			this.btnDownloadNCFile.Text = "Download NC File";
			this.btnDownloadNCFile.UseVisualStyleBackColor = true;
			this.btnDownloadNCFile.Click += new System.EventHandler(this.btnDownloadNCFile_Click);
			// 
			// btnSetMainNC
			// 
			this.btnSetMainNC.Location = new System.Drawing.Point(30, 325);
			this.btnSetMainNC.Name = "btnSetMainNC";
			this.btnSetMainNC.Size = new System.Drawing.Size(160, 25);
			this.btnSetMainNC.TabIndex = 97;
			this.btnSetMainNC.Text = "Set Main NC File";
			this.btnSetMainNC.UseVisualStyleBackColor = true;
			this.btnSetMainNC.Click += new System.EventHandler(this.btnSetMainNC_Click);
			// 
			// btnAuto
			// 
			this.btnAuto.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnAuto.Location = new System.Drawing.Point(210, 115);
			this.btnAuto.Name = "btnAuto";
			this.btnAuto.Size = new System.Drawing.Size(60, 60);
			this.btnAuto.TabIndex = 103;
			this.btnAuto.Text = "Auto Mode";
			this.btnAuto.UseVisualStyleBackColor = true;
			this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
			// 
			// btnStart
			// 
			this.btnStart.BackColor = System.Drawing.Color.PaleGreen;
			this.btnStart.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnStart.Location = new System.Drawing.Point(210, 255);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(60, 60);
			this.btnStart.TabIndex = 105;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// lbConnectedIP
			// 
			this.lbConnectedIP.FormattingEnabled = true;
			this.lbConnectedIP.ItemHeight = 12;
			this.lbConnectedIP.Location = new System.Drawing.Point(210, 35);
			this.lbConnectedIP.Name = "lbConnectedIP";
			this.lbConnectedIP.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lbConnectedIP.Size = new System.Drawing.Size(130, 64);
			this.lbConnectedIP.TabIndex = 107;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(210, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 12);
			this.label1.TabIndex = 108;
			this.label1.Text = "Select Connected IP:";
			// 
			// btnReset
			// 
			this.btnReset.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnReset.Location = new System.Drawing.Point(280, 115);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(60, 60);
			this.btnReset.TabIndex = 109;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnPause
			// 
			this.btnPause.BackColor = System.Drawing.Color.Pink;
			this.btnPause.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnPause.Location = new System.Drawing.Point(280, 255);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(60, 60);
			this.btnPause.TabIndex = 110;
			this.btnPause.Text = "Hold";
			this.btnPause.UseVisualStyleBackColor = false;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(30, 361);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(159, 46);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 111;
			this.pictureBox1.TabStop = false;
			// 
			// btnRateDown
			// 
			this.btnRateDown.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnRateDown.Location = new System.Drawing.Point(210, 185);
			this.btnRateDown.Name = "btnRateDown";
			this.btnRateDown.Size = new System.Drawing.Size(60, 60);
			this.btnRateDown.TabIndex = 112;
			this.btnRateDown.Text = "Rate   -";
			this.btnRateDown.UseVisualStyleBackColor = true;
			this.btnRateDown.Click += new System.EventHandler(this.btnRateDown_Click);
			// 
			// btnRateUp
			// 
			this.btnRateUp.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnRateUp.Location = new System.Drawing.Point(280, 185);
			this.btnRateUp.Name = "btnRateUp";
			this.btnRateUp.Size = new System.Drawing.Size(60, 60);
			this.btnRateUp.TabIndex = 113;
			this.btnRateUp.Text = "Rate   +";
			this.btnRateUp.UseVisualStyleBackColor = true;
			this.btnRateUp.Click += new System.EventHandler(this.btnRateUp_Click);
			// 
			// tbInputIP
			// 
			this.tbInputIP.Location = new System.Drawing.Point(8, 21);
			this.tbInputIP.Name = "tbInputIP";
			this.tbInputIP.Size = new System.Drawing.Size(160, 22);
			this.tbInputIP.TabIndex = 114;
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(8, 50);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(160, 25);
			this.btnConnect.TabIndex = 116;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnConnect);
			this.groupBox1.Controls.Add(this.tbInputIP);
			this.groupBox1.Location = new System.Drawing.Point(22, 21);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(175, 85);
			this.groupBox1.TabIndex = 117;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connect to IP:";
			// 
			// tbPLCbits
			// 
			this.tbPLCbits.Location = new System.Drawing.Point(10, 21);
			this.tbPLCbits.Name = "tbPLCbits";
			this.tbPLCbits.Size = new System.Drawing.Size(120, 22);
			this.tbPLCbits.TabIndex = 118;
			// 
			// btnRead
			// 
			this.btnRead.Font = new System.Drawing.Font("PMingLiU", 9F);
			this.btnRead.Location = new System.Drawing.Point(10, 50);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(120, 25);
			this.btnRead.TabIndex = 119;
			this.btnRead.Text = "Read";
			this.btnRead.UseVisualStyleBackColor = true;
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnRead);
			this.groupBox2.Controls.Add(this.tbPLCbits);
			this.groupBox2.Location = new System.Drawing.Point(205, 323);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(140, 85);
			this.groupBox2.TabIndex = 121;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "PLC bits";
			// 
			// btnJOG
			// 
			this.btnJOG.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnJOG.Location = new System.Drawing.Point(660, 35);
			this.btnJOG.Name = "btnJOG";
			this.btnJOG.Size = new System.Drawing.Size(60, 60);
			this.btnJOG.TabIndex = 122;
			this.btnJOG.Text = "JOG Mode";
			this.btnJOG.UseVisualStyleBackColor = true;
			this.btnJOG.Click += new System.EventHandler(this.btnJOG_Click);
			// 
			// btnCoord
			// 
			this.btnCoord.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnCoord.Location = new System.Drawing.Point(730, 35);
			this.btnCoord.Name = "btnCoord";
			this.btnCoord.Size = new System.Drawing.Size(60, 60);
			this.btnCoord.TabIndex = 123;
			this.btnCoord.Text = "Coord.";
			this.btnCoord.UseVisualStyleBackColor = true;
			this.btnCoord.Click += new System.EventHandler(this.btnCoord_Click);
			// 
			// btnXBack
			// 
			this.btnXBack.BackColor = System.Drawing.SystemColors.Info;
			this.btnXBack.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnXBack.Location = new System.Drawing.Point(660, 115);
			this.btnXBack.Name = "btnXBack";
			this.btnXBack.Size = new System.Drawing.Size(60, 40);
			this.btnXBack.TabIndex = 124;
			this.btnXBack.Text = "C1 / X -";
			this.btnXBack.UseVisualStyleBackColor = false;
			this.btnXBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXBack_MouseDown);
			this.btnXBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXBack_MouseUp);
			// 
			// btnXFore
			// 
			this.btnXFore.BackColor = System.Drawing.SystemColors.Info;
			this.btnXFore.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnXFore.Location = new System.Drawing.Point(730, 115);
			this.btnXFore.Name = "btnXFore";
			this.btnXFore.Size = new System.Drawing.Size(60, 40);
			this.btnXFore.TabIndex = 125;
			this.btnXFore.Text = "C1 / X +";
			this.btnXFore.UseVisualStyleBackColor = false;
			this.btnXFore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXFore_MouseDown);
			this.btnXFore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXFore_MouseUp);
			// 
			// btnYBack
			// 
			this.btnYBack.BackColor = System.Drawing.SystemColors.Info;
			this.btnYBack.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnYBack.Location = new System.Drawing.Point(660, 165);
			this.btnYBack.Name = "btnYBack";
			this.btnYBack.Size = new System.Drawing.Size(60, 40);
			this.btnYBack.TabIndex = 126;
			this.btnYBack.Text = "C2 / Y -";
			this.btnYBack.UseVisualStyleBackColor = false;
			this.btnYBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYBack_MouseDown);
			this.btnYBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYBack_MouseUp);
			// 
			// btnYFore
			// 
			this.btnYFore.BackColor = System.Drawing.SystemColors.Info;
			this.btnYFore.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnYFore.Location = new System.Drawing.Point(730, 165);
			this.btnYFore.Name = "btnYFore";
			this.btnYFore.Size = new System.Drawing.Size(60, 40);
			this.btnYFore.TabIndex = 127;
			this.btnYFore.Text = "C2 / Y +";
			this.btnYFore.UseVisualStyleBackColor = false;
			this.btnYFore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYFore_MouseDown);
			this.btnYFore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYFore_MouseUp);
			// 
			// btnZBack
			// 
			this.btnZBack.BackColor = System.Drawing.SystemColors.Info;
			this.btnZBack.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnZBack.Location = new System.Drawing.Point(660, 215);
			this.btnZBack.Name = "btnZBack";
			this.btnZBack.Size = new System.Drawing.Size(60, 40);
			this.btnZBack.TabIndex = 128;
			this.btnZBack.Text = "C3 / Z -";
			this.btnZBack.UseVisualStyleBackColor = false;
			this.btnZBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZBack_MouseDown);
			this.btnZBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZBack_MouseUp);
			// 
			// btnZFore
			// 
			this.btnZFore.BackColor = System.Drawing.SystemColors.Info;
			this.btnZFore.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnZFore.Location = new System.Drawing.Point(730, 215);
			this.btnZFore.Name = "btnZFore";
			this.btnZFore.Size = new System.Drawing.Size(60, 40);
			this.btnZFore.TabIndex = 129;
			this.btnZFore.Text = "C3 / Z +";
			this.btnZFore.UseVisualStyleBackColor = false;
			this.btnZFore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZFore_MouseDown);
			this.btnZFore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZFore_MouseUp);
			// 
			// btnABack
			// 
			this.btnABack.BackColor = System.Drawing.SystemColors.Info;
			this.btnABack.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnABack.Location = new System.Drawing.Point(660, 265);
			this.btnABack.Name = "btnABack";
			this.btnABack.Size = new System.Drawing.Size(60, 40);
			this.btnABack.TabIndex = 130;
			this.btnABack.Text = "C4 / A -";
			this.btnABack.UseVisualStyleBackColor = false;
			this.btnABack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnABack_MouseDown);
			this.btnABack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnABack_MouseUp);
			// 
			// btnBBack
			// 
			this.btnBBack.BackColor = System.Drawing.SystemColors.Info;
			this.btnBBack.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnBBack.Location = new System.Drawing.Point(660, 315);
			this.btnBBack.Name = "btnBBack";
			this.btnBBack.Size = new System.Drawing.Size(60, 40);
			this.btnBBack.TabIndex = 131;
			this.btnBBack.Text = "C5 / B -";
			this.btnBBack.UseVisualStyleBackColor = false;
			this.btnBBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBBack_MouseDown);
			this.btnBBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBBack_MouseUp);
			// 
			// btnCBack
			// 
			this.btnCBack.BackColor = System.Drawing.SystemColors.Info;
			this.btnCBack.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnCBack.Location = new System.Drawing.Point(660, 365);
			this.btnCBack.Name = "btnCBack";
			this.btnCBack.Size = new System.Drawing.Size(60, 40);
			this.btnCBack.TabIndex = 132;
			this.btnCBack.Text = "C6 / C -";
			this.btnCBack.UseVisualStyleBackColor = false;
			this.btnCBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCBack_MouseDown);
			this.btnCBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCBack_MouseUp);
			// 
			// btnAFore
			// 
			this.btnAFore.BackColor = System.Drawing.SystemColors.Info;
			this.btnAFore.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnAFore.Location = new System.Drawing.Point(730, 265);
			this.btnAFore.Name = "btnAFore";
			this.btnAFore.Size = new System.Drawing.Size(60, 40);
			this.btnAFore.TabIndex = 133;
			this.btnAFore.Text = "C4 / A +";
			this.btnAFore.UseVisualStyleBackColor = false;
			this.btnAFore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAFore_MouseDown);
			this.btnAFore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAFore_MouseUp);
			// 
			// btnBFore
			// 
			this.btnBFore.BackColor = System.Drawing.SystemColors.Info;
			this.btnBFore.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnBFore.Location = new System.Drawing.Point(730, 315);
			this.btnBFore.Name = "btnBFore";
			this.btnBFore.Size = new System.Drawing.Size(60, 40);
			this.btnBFore.TabIndex = 134;
			this.btnBFore.Text = "C5 / B +";
			this.btnBFore.UseVisualStyleBackColor = false;
			this.btnBFore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBFore_MouseDown);
			this.btnBFore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBFore_MouseUp);
			// 
			// btnCFore
			// 
			this.btnCFore.BackColor = System.Drawing.SystemColors.Info;
			this.btnCFore.Font = new System.Drawing.Font("PMingLiU", 12F);
			this.btnCFore.Location = new System.Drawing.Point(730, 365);
			this.btnCFore.Name = "btnCFore";
			this.btnCFore.Size = new System.Drawing.Size(60, 40);
			this.btnCFore.TabIndex = 135;
			this.btnCFore.Text = "C6 / C +";
			this.btnCFore.UseVisualStyleBackColor = false;
			this.btnCFore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCFore_MouseDown);
			this.btnCFore.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCFore_MouseUp);
			// 
			// ExampleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 437);
			this.Controls.Add(this.btnCFore);
			this.Controls.Add(this.btnBFore);
			this.Controls.Add(this.btnAFore);
			this.Controls.Add(this.btnCBack);
			this.Controls.Add(this.btnBBack);
			this.Controls.Add(this.btnABack);
			this.Controls.Add(this.btnZFore);
			this.Controls.Add(this.btnZBack);
			this.Controls.Add(this.btnYFore);
			this.Controls.Add(this.btnYBack);
			this.Controls.Add(this.btnXFore);
			this.Controls.Add(this.btnXBack);
			this.Controls.Add(this.btnCoord);
			this.Controls.Add(this.btnJOG);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnRateUp);
			this.Controls.Add(this.btnRateDown);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbConnectedIP);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnAuto);
			this.Controls.Add(this.btnSetMainNC);
			this.Controls.Add(this.btnDownloadNCFile);
			this.Controls.Add(this.labelInformation);
			this.Controls.Add(this.labelAbsCoord);
			this.Controls.Add(this.labelMechCoord);
			this.Controls.Add(this.lbTCP);
			this.Controls.Add(this.lbJointCoord);
			this.Controls.Add(this.btnStatus);
			this.Controls.Add(this.btnInformation);
			this.Controls.Add(this.btnDeleteNCFile);
			this.Controls.Add(this.btnUploadNCFile);
			this.Controls.Add(this.lbInformation);
			this.Controls.Add(this.btnNCFileList);
			this.Name = "ExampleForm";
			this.Text = "SYNTEC Remote API Example";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button btnNCFileList;
		private System.Windows.Forms.ListBox lbInformation;
		private System.Windows.Forms.Button btnUploadNCFile;
		private System.Windows.Forms.Button btnDeleteNCFile;
		private System.Windows.Forms.Button btnInformation;
		private System.Windows.Forms.Button btnStatus;
		private System.Windows.Forms.ListBox lbJointCoord;
		private System.Windows.Forms.ListBox lbTCP;
		private System.Windows.Forms.Label labelMechCoord;
		private System.Windows.Forms.Label labelAbsCoord;
		private System.Windows.Forms.Label labelInformation;
		private System.Windows.Forms.Button btnDownloadNCFile;
		private System.Windows.Forms.Button btnSetMainNC;
		private System.Windows.Forms.Button btnAuto;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ListBox lbConnectedIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnRateDown;
		private System.Windows.Forms.Button btnRateUp;
		private System.Windows.Forms.TextBox tbInputIP;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbPLCbits;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnJOG;
        private System.Windows.Forms.Button btnCoord;
        private System.Windows.Forms.Button btnXBack;
        private System.Windows.Forms.Button btnXFore;
        private System.Windows.Forms.Button btnYBack;
        private System.Windows.Forms.Button btnYFore;
        private System.Windows.Forms.Button btnZBack;
        private System.Windows.Forms.Button btnZFore;
        private System.Windows.Forms.Button btnABack;
        private System.Windows.Forms.Button btnBBack;
        private System.Windows.Forms.Button btnCBack;
        private System.Windows.Forms.Button btnAFore;
        private System.Windows.Forms.Button btnBFore;
		private System.Windows.Forms.Button btnCFore;
    }
}

