using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Lab_2;

namespace Lab2_task
{
    public partial class Form1 : Form
    {
        private List<GraphElement> elements = new List<GraphElement>();
        bool dragging;
        int dx = 0, dy = 0;
        int eli = -1;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //elements.Add(new GraphObject());
            panel1.Refresh();
            if (eli % 2 == 0) elements.Add(new Ellipse(rand.Next(panel1.Width), rand.Next(panel1.Height)));
            else elements.Add(new Lab_2.Rectangle(rand.Next(panel1.Width), rand.Next(panel1.Height)));
            panel2.Refresh();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
          // toolStripTextBox1.Text =  Random()
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer rickroll = new System.Media.SoundPlayer(@"\\Mac\Home\Downloads\rick_roll.wav");
            //rickroll.Play();
            this.panel2.Visible = false;
            axWindowsMediaPlayer1.URL = (@"\\Mac\Home\Downloads\Nevgo.mp4");
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Visible = true;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
    }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Visible = false;
            this.panel2.Visible = true;
            elements.Clear();
            panel2.Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            axWindowsMediaPlayer1.URL = (@"\\Mac\Home\Downloads\troll.mp4");
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Visible = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            axWindowsMediaPlayer1.URL = (@"\\Mac\Home\Downloads\nyancat.mp4");
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Visible = true;
        }

        private void fiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BigInteger counter = new BigInteger(1);

            for (int n = 1; n < 605; n++)
            {
                //BigInteger bigInt = new BigInteger(Math.Pow(1 + Math.Sqrt(5), n) - Math.Pow(1 - Math.Sqrt(5), n)) / (Math.Pow(2, n) * Math.Sqrt(5));
                //double fi = (Math.Pow(1 + Math.Sqrt(5), n) - Math.Pow(1 - Math.Sqrt(5), n)) / (Math.Pow(2, n) * Math.Sqrt(5));
                // Console.Write(fi + " , ");
                BigInteger bigIntChisl = new BigInteger(Math.Pow(1 + Math.Sqrt(5), n) - Math.Pow(1 - Math.Sqrt(5), n));
                BigInteger bigIntZnam = new BigInteger(Math.Pow(2, n) * Math.Sqrt(5));
                Console.Write(BigInteger.Divide(bigIntChisl, bigIntZnam) + " , ");
            }
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
        }

        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (GraphElement elem in elements) elem.draw(e.Graphics);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragging) dragging = false;
            else return;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dragging) return;
            Point p = new Point(e.Location.X - dx, e.Location.Y - dy);
            foreach (GraphElement el in elements) if (el.Selected) el.Location = p;
            panel2.Invalidate();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (GraphElement el in elements.Reverse<GraphElement>())
            {
                el.ifcontainsPoint(e.Location);
                if (el.Selected) { dragging = true; dx = e.Location.X - el.Location.X; dy = e.Location.Y - el.Location.Y; return; }
            }
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (eli % 2 == 0) elements.Add(new Ellipse(e.X, e.Y));
            else elements.Add(new Lab_2.Rectangle(e.X, e.Y));
            panel2.Refresh();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (GraphElement elem in elements.Reverse<GraphElement>())
            {
                elem.ifcontainsPoint(e.Location);
                if (elem.Selected) return;
            }
            panel2.Refresh();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            List<GraphElement> elements1 = new List<GraphElement>();
            foreach (GraphElement elem in elements)
            {
                if (!elem.Selected) { elements1.Add(elem); }
            }
            elements = elements1;
            panel2.Refresh();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            foreach (GraphElement elem in elements)
            {
                if (elem.Selected) { Point rp = new Point(rand.Next(panel1.Width), rand.Next(panel1.Height)); elem.Location = rp; }
            }
            panel2.Refresh();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            eli++;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (eli % 2 == 0)
            {
                toolStripTextBox1.Text = "OFF";
                toolStripTextBox1.BackColor = Color.White;
            }
            else
            {
                toolStripTextBox1.Text = "ON";
                toolStripTextBox1.BackColor = Color.ForestGreen;
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eli % 2 == 0) elements.Add(new Ellipse(rand.Next(panel1.Width), rand.Next(panel1.Height)));
            else elements.Add(new Lab_2.Rectangle(rand.Next(panel1.Width), rand.Next(panel1.Height)));
            panel1.Refresh();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Visible = false;
            this.panel2.Visible = true;
            elements.Clear();
            panel2.Refresh();
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void evilFibonachiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BigInteger counter = new BigInteger(1);

            for (int n = 1; n < 605; n++)
            {
            
                BigInteger bigIntChisl = new BigInteger(Math.Pow(1 + Math.Sqrt(5), n) - Math.Pow(1 - Math.Sqrt(5), n));
                BigInteger bigIntZnam = new BigInteger(Math.Pow(2, n) * Math.Sqrt(5));
                MessageBox.Show(BigInteger.Divide(bigIntChisl, bigIntZnam) + " ");
        }

    }
        
            private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.TimeOfDay.ToString();
        }



        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // toolStripLabel1.Text = DateTime.Now.TimeOfDay.ToString();
            toolStripLabel1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0");
        }
    }
}
