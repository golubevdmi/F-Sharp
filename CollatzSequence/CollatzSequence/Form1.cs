using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosKol;

namespace CollatzSequence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(1, 15);
            chart1.Series[0].Name = "N";

            chart2.Series[0].Points.AddXY(1, 15);
            chart2.Series[0].Name = "L";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();

            List<int> lst = new List<int>();

            for (int i = Convert.ToInt32(textBox1.Text); i <= Convert.ToInt32(textBox2.Text); i++)
            {
                    chart1.Series[0].Points.AddXY(i, PosKol.PosKol.PosDl(i));
                    lst.Add(PosKol.PosKol.PosDl(i));
            }

            foreach (var val in lst.Distinct())
            {
                    chart2.Series[0].Points.AddXY(val, lst.Where(x => x == val).Count());
            }
        }
    }


}
