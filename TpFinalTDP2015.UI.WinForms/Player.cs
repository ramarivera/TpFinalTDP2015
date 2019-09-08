using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpFinalTDP2015.UI.WinForms
{
    public partial class Player : Form
    {
        string Dirpath = "D:\\Martín\\Downloads";
        int imgindex;
        List<string> items = new List<string>();
        public Player()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Left < 0 && (Math.Abs(label1.Left) > label1.Width))
                label1.Left = this.Width;
            if (label2.Left < 0 && (Math.Abs(label2.Left) > label2.Width))
                label2.Left = this.Width;

            label1.Left -= 1;
            label2.Left -= 1;
        }

        private void Player_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer2.Enabled = true;
            timer2.Interval = 5000;

            string[] files = Directory.GetFiles(Dirpath, "*.Jpg");
            foreach (string file in files)
            {
                int pos = file.LastIndexOf("||");
                string FName = file.Substring(pos + 1);
                items.Add(FName);
            }
            imgindex = 0;
            pictureBox1.ImageLocation = items[imgindex].ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            imgindex++;
            pictureBox1.ImageLocation = items[imgindex].ToString();
        }
    }
}
