using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using SizeFolderLibrary;

namespace SizeFolder
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            chart1.Series[0]["PieLabelStyle"] = "Disabled";

            folderBrowserDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
            {
                System.IO.DirectoryInfo info = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                var enumerablesDir = info.EnumerateDirectories();
                foreach (var dir in enumerablesDir)
                {
                    chart1.Series[0].Points.AddXY(dir.Name, FileFolder.getSize(dir.FullName));
                    listBox1.Items.Add(dir.Name + "  " + FileFolder.getSize(dir.FullName));
                }

                var enumerablesFiles = info.EnumerateFiles();
                foreach (var file in enumerablesFiles)
                {
                    chart1.Series[0].Points.AddXY(file.Name, file.Length);
                    listBox1.Items.Add(file.Name.ToString() + "  " + file.Length.ToString());
                }

                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

    }
}
