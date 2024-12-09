using LogViewer.Base;
using LogViewer.Data;
using LogViewer.Extensions;
using LogViewer.Properties;
using LogViewer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace LogViewer
{
    public partial class MainForm : Form
    {
        private Timer timer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txbFolderPath.Text = Settings.Default.FolderPath;
            txbQuery.Text = Settings.Default.Query;
            dateTimePicker1.Value = DateTime.Parse(Settings.Default.Date);
            cbxAnyDate.Checked = Settings.Default.AnyDate;
            lblResult.Text = "";
            lblPercent.Text = "";
            lblCurrentFileName.Text = "";
            lblStatus.Text = "Ready";
            lblItemCount.Text = $"{DataProvider.CountEventItems()} events saved";
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex > 0)
            {
                DisplayXml();
            }
        }

        private XmlDocument BuildXmlDocument()
        {
            EventItemList eventItemList = new EventItemList();
            eventItemList.EventItems = new List<EventItem>();
            List<EventItem> eventItems = DataProvider.GetEventItems();

            foreach (EventItem item in eventItems)
            {
                EventItem eventItem = item.Msg.FromXml<EventItem>();
                eventItemList.EventItems.Add(eventItem);
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(eventItemList.ToXml());
            return doc;
        }

        private void DisplayXml()
        {
            XmlDocument doc = BuildXmlDocument();
            XslCompiledTransform xTrans = new XslCompiledTransform();
            xTrans.Load("defaultss.xsl");

            StringReader sr = new StringReader(doc.OuterXml);
            XmlReader xReader = XmlReader.Create(sr);

            MemoryStream ms = new MemoryStream();
            xTrans.Transform(xReader, null, ms);
            ms.Position = 0;
            WebBrowser.DocumentStream = ms;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            txbLog.Text = "";
            string query = txbQuery.Text;

            if (query.Length < 3)
            {
                lblStatus.Text = "Invalid query";
                return;
            }
            lblStatus.Text = "Working...";
            lblPercent.Visible = true;
            lblPercent.Text = "0%";
            lblItemCount.Text = "Finding...";
            lblCurrentFileName.Visible = true;
            MainProgressBar.Value = 0;
            MainBackgroundWorker.WorkerReportsProgress = true;
            MainBackgroundWorker.RunWorkerAsync();
        }

        private void MainBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            EnlistFolder();
        }

        private void EnlistFolder()
        {
            string folderPath = txbFolderPath.Text;
            string query = txbQuery.Text;
            DateTime dateTime = dateTimePicker1.Value;
            Settings.Default.AnyDate = cbxAnyDate.Checked;
            string date = dateTime.ToString("yyyy-MM-dd");
            Settings.Default.Date = date;
            Settings.Default.FolderPath = folderPath;
            Settings.Default.Query = query;
            Settings.Default.Save();
            query = query.Replace("-", "");
            if (cbxAnyDate.Checked)
            {
                date = null;
            }

            List<FileItem> fileList = FileService.Enlist(folderPath, date);

            long totalLength = fileList.Sum(x => x.Length);
            long percent = totalLength / 100;

            long processed = 0;
            int fileCount = fileList.Count;
            int leftFileCount = fileList.Count;
            Invoke(new Action<string>(UpdateStatus), $"Working on {fileList.Count} files");

            if (fileList.Count > 0)
            {
                DataProvider.Delete();

                FileItem fileItem = null;

                foreach (FileItem fi in fileList)
                {
                    fi.TotalFileCount = fileCount;
                    fi.TotalLength = totalLength;
                    fi.LeftLength = totalLength - (processed + fi.Length);
                    leftFileCount--;
                    fi.LeftFileCount = leftFileCount;
                    fileItem = fi;

                    Invoke(new Action<FileItem>(UpdateForm), fi);
                    List<LogItem> logs = DataReader.ReadFile(fi.Info.FullName, query);

                    if (logs.Count > 0)
                    {
                        foreach (LogItem log in logs)
                        {
                            EventItem eventItem = log.Item.FromXml<EventItem>();
                            eventItem.Source = $"{log.FilePath}:{log.LineNum}";
                            eventItem.Msg = eventItem.ToXml();
                            DataProvider.InsertEventItem(eventItem);
                        }
                    }

                    processed += fi.Length;
                    int percentProgress = (int)(processed / percent);
                    MainBackgroundWorker.ReportProgress(percentProgress);

                }
                fileItem.LeftLength = totalLength - (processed + fileItem.Length);
                fileItem.Completed = true;
                Invoke(new Action<FileItem>(UpdateForm), fileItem);
            }
            else
            {
                Invoke(new Action<string>(UpdateStatus), "No file found");
            }
        }

        private void UpdateStatus(string value)
        {
            lblStatus.Text = value;
        }

        private void UpdateForm(FileItem fi)
        {
            if (fi.LeftFileCount > 0)
            {
                lblResult.Text = $"{fi.LeftFileCount}/{fi.TotalFileCount} files {BytesToString(fi.LeftLength)}/{BytesToString(fi.TotalLength)}";
            }
            else
            {
                lblResult.Text = $"{fi.TotalFileCount} files {BytesToString(fi.TotalLength)}";
            }

            lblCurrentFileName.Text = $"{fi.Info.Name} {BytesToString(fi.Length)}";

            string[] logLines = txbLog.Lines;
            List<string> lines = new List<string>();
            lines.AddRange(logLines);

            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                line = line.Replace("Working on ", "");
                if (!line.Contains("completed"))
                {
                    line += " completed";
                }

                lines[i] = line;
            }

            if (fi.Completed)
            {
                lines.Add("Completed");
            }
            else
            {
                lines.Add($"Working on {fi.Info.Name}");
            }


            txbLog.Lines = lines.ToArray();
            txbLog.SelectionStart = txbLog.Text.Length;
            txbLog.ScrollToCaret();
        }

        private string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num) + " " + suf[place];
        }

        private void MainBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblPercent.Text = $"{e.ProgressPercentage}%";
            MainProgressBar.Value = e.ProgressPercentage;
        }



        private void MainBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            lblPercent.Visible = false;
            lblCurrentFileName.Visible = false;
            lblStatus.Text = "Completed";
            lblItemCount.Text = $"{DataProvider.CountEventItems()} events found";
            MainProgressBar.Value = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.Filter = "XML|*.xml";
            svd.Title = "Save as xml file";
            svd.FileName = $"{Settings.Default.Date}-{Settings.Default.Query}.xml";
            svd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(svd.FileName))
            {
                XmlDocument doc = BuildXmlDocument();
                doc.Save(svd.FileName);
            }
        }
    }
}
