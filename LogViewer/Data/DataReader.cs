using System.Collections.Generic;
using System.IO;
using System.Threading;
using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using LogViewer.Base;

namespace LogViewer.Data
{
    public class DataReader
    {
        public static List<LogItem> ReadFile(string path, string query)
        {
            Thread.Sleep(100);
            List<LogItem> logs = new List<LogItem>();
            List<string> lines = new List<string>();
            int counter = 0;
            int lineNum = -1;

            string line;

            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        counter++;

                        if (line.IndexOf("</event>", StringComparison.Ordinal) >= 0)
                        {
                            lines.Add(line);
                            lineNum++;

                            string item = string.Join("", lines);
                            string content = item.Replace("-", "");

                            if (content.Contains(query))
                            {
                                var logItem = new LogItem
                                {
                                    FilePath = path,
                                    LineNum = counter - lineNum,
                                    Item = item
                                };
                                logs.Add(logItem);
                            }

                            lineNum = -1;
                            lines.Clear();
                        }
                        else
                        {
                            lines.Add(line);
                            //lineNum++;
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                lineNum++;
                            }
                        }

                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //ConsoleService.AddLog("Path", path, "Logs", logs.Count);

            return logs;
        }
    }
}