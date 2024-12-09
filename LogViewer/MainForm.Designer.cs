namespace LogViewer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageExplore = new System.Windows.Forms.TabPage();
            this.cbxAnyDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblCurrentFileName = new System.Windows.Forms.Label();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txbFolderPath = new System.Windows.Forms.TextBox();
            this.tabPageViewer = new System.Windows.Forms.TabPage();
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.MainBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblItemCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControlMain.SuspendLayout();
            this.tabPageExplore.SuspendLayout();
            this.tabPageViewer.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageExplore);
            this.tabControlMain.Controls.Add(this.tabPageViewer);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(875, 561);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageExplore
            // 
            this.tabPageExplore.Controls.Add(this.cbxAnyDate);
            this.tabPageExplore.Controls.Add(this.label4);
            this.tabPageExplore.Controls.Add(this.txbLog);
            this.tabPageExplore.Controls.Add(this.btnSave);
            this.tabPageExplore.Controls.Add(this.lblPercent);
            this.tabPageExplore.Controls.Add(this.lblCurrentFileName);
            this.tabPageExplore.Controls.Add(this.MainProgressBar);
            this.tabPageExplore.Controls.Add(this.btnFind);
            this.tabPageExplore.Controls.Add(this.label3);
            this.tabPageExplore.Controls.Add(this.txbQuery);
            this.tabPageExplore.Controls.Add(this.label2);
            this.tabPageExplore.Controls.Add(this.dateTimePicker1);
            this.tabPageExplore.Controls.Add(this.label1);
            this.tabPageExplore.Controls.Add(this.txbFolderPath);
            this.tabPageExplore.Location = new System.Drawing.Point(4, 22);
            this.tabPageExplore.Name = "tabPageExplore";
            this.tabPageExplore.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExplore.Size = new System.Drawing.Size(867, 535);
            this.tabPageExplore.TabIndex = 0;
            this.tabPageExplore.Text = "Explore";
            this.tabPageExplore.UseVisualStyleBackColor = true;
            // 
            // cbxAnyDate
            // 
            this.cbxAnyDate.AutoSize = true;
            this.cbxAnyDate.Location = new System.Drawing.Point(411, 90);
            this.cbxAnyDate.Name = "cbxAnyDate";
            this.cbxAnyDate.Size = new System.Drawing.Size(68, 17);
            this.cbxAnyDate.TabIndex = 13;
            this.cbxAnyDate.Text = "Any date";
            this.cbxAnyDate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Log:";
            // 
            // txbLog
            // 
            this.txbLog.Location = new System.Drawing.Point(121, 261);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbLog.Size = new System.Drawing.Size(727, 218);
            this.txbLog.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(773, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save To File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPercent.Location = new System.Drawing.Point(118, 226);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(67, 16);
            this.lblPercent.TabIndex = 9;
            this.lblPercent.Text = "lblPercent";
            // 
            // lblCurrentFileName
            // 
            this.lblCurrentFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentFileName.AutoSize = true;
            this.lblCurrentFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentFileName.Location = new System.Drawing.Point(398, 226);
            this.lblCurrentFileName.Name = "lblCurrentFileName";
            this.lblCurrentFileName.Size = new System.Drawing.Size(122, 16);
            this.lblCurrentFileName.TabIndex = 8;
            this.lblCurrentFileName.Text = "lblCurrentFileName";
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Location = new System.Drawing.Point(121, 186);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(631, 23);
            this.MainProgressBar.TabIndex = 7;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(773, 186);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Query:";
            // 
            // txbQuery
            // 
            this.txbQuery.Location = new System.Drawing.Point(121, 146);
            this.txbQuery.Name = "txbQuery";
            this.txbQuery.Size = new System.Drawing.Size(727, 20);
            this.txbQuery.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(121, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folder Path:";
            // 
            // txbFolderPath
            // 
            this.txbFolderPath.Location = new System.Drawing.Point(121, 32);
            this.txbFolderPath.Name = "txbFolderPath";
            this.txbFolderPath.Size = new System.Drawing.Size(727, 20);
            this.txbFolderPath.TabIndex = 0;
            // 
            // tabPageViewer
            // 
            this.tabPageViewer.Controls.Add(this.WebBrowser);
            this.tabPageViewer.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewer.Name = "tabPageViewer";
            this.tabPageViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViewer.Size = new System.Drawing.Size(867, 535);
            this.tabPageViewer.TabIndex = 1;
            this.tabPageViewer.Text = "Viewer";
            this.tabPageViewer.UseVisualStyleBackColor = true;
            // 
            // WebBrowser
            // 
            this.WebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrowser.Location = new System.Drawing.Point(6, 6);
            this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(855, 611);
            this.WebBrowser.TabIndex = 2;
            // 
            // MainBackgroundWorker
            // 
            this.MainBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MainBackgroundWorker_DoWork);
            this.MainBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MainBackgroundWorker_ProgressChanged);
            this.MainBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MainBackgroundWorker_RunWorkerCompleted);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblResult,
            this.lblItemCount});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 576);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(899, 22);
            this.MainStatusStrip.TabIndex = 1;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.Text = "lblStatus";
            // 
            // lblResult
            // 
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(755, 17);
            this.lblResult.Spring = true;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemCount
            // 
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(77, 17);
            this.lblItemCount.Text = "lblItemCount";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 598);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogViewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageExplore.ResumeLayout(false);
            this.tabPageExplore.PerformLayout();
            this.tabPageViewer.ResumeLayout(false);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageExplore;
        private System.Windows.Forms.TabPage tabPageViewer;
        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFolderPath;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar MainProgressBar;
        private System.ComponentModel.BackgroundWorker MainBackgroundWorker;
        private System.Windows.Forms.Label lblCurrentFileName;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblResult;
        private System.Windows.Forms.ToolStripStatusLabel lblItemCount;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxAnyDate;
    }
}

