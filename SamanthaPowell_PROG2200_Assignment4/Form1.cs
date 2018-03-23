using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace SamanthaPowell_PROG2200_Assignment4
{
    public partial class Form1 : Form
    {
        Trump trump;
        HashSet<Allies> allies = new HashSet<Allies>();


        public Form1()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            trump = new Trump(this.DisplayRectangle);
        }
        private void gameCanvas_Paint(object sender, PaintEventArgs e)
        {
            trump.Draw(e.Graphics);

        }
        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        public void displayAllies(Graphics graphics)
        {

        }
        

        public void Form1_keyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    {
                        //MOVE THE PADDLE LEFT
                        trump.Move(Trump.Direction.Left);
                        //Invalidate(); //force the paint event to redraw
                        break;
                    }
                case Keys.Right:
                    {
                        //MOVE Trump RIGHT
                        trump.Move(Trump.Direction.Right);
                        //Invalidate();
                        break;
                    }
                case Keys.Up:
                    {
                        //move trump up
                        trump.Move(Trump.Direction.Up);
                        break;
                    }
                case Keys.Down:
                    {
                        trump.Move(Trump.Direction.Down);
                        break;
                    }
                case Keys.Space:
                    {
                        timer1.Enabled = !timer1.Enabled;
                        break;
                    }
                    //case Keys.N:
                    //    {
                    //        balls.Add(new Ball(this.DisplayRectangle));
                    //        break;
                    //    }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            //trump.Move();
            Invalidate();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
