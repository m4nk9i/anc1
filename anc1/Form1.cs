using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anc1
{
    public partial class Form1 : Form
    {
        public Graphics gr;
        private Swiat swiat;
        public Bitmap bm;
        public Graphics tgr;
        public Form1()
        {
            InitializeComponent();
            bm= new Bitmap(panel1.Width, panel1.Height);
            tgr = Graphics.FromImage(bm);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            gr = panel1.CreateGraphics();
            init();
            swiat.gr = tgr;
        }

        public void init()
        {
            swiat = new Swiat();
            swiat.init();
        }

        public void rusz()
        {
            swiat.rusz();

        }

        public void rysuj()
        {
            tgr.Clear(Color.White);
            swiat.rysuj();
            gr.DrawImage(bm, new Point(0, 0));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rusz();
            rysuj();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text += swiat.mrowki[trackBar1.Value].ToString();
        }
    }
}
