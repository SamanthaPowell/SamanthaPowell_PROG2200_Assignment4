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
        List<Allies> allies = new List<Allies>();
        Mueller mueller;
        private bool gameOver;
        //sound effects
        MciPlayer Catastrophy = new MciPlayer("Sounds/Catastrophy.mp3", "1");
        MciPlayer GoodJob = new MciPlayer("Sounds/GoodJob.mp3", "2");
        MciPlayer TremendousImpact = new MciPlayer("Sounds/TremendousImpact.mp3", "3");
        public int countAllies;

        public Form1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Loads form and game objects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            trump = new Trump(this.DisplayRectangle);
            mueller = new Mueller(this.DisplayRectangle);
            for (int x = 0; x < 8; x++)
            {
                allies.Add(new Allies(this.DisplayRectangle));
            }
            timer1.Stop();
            MessageBox.Show("Help Trump navigate through his own border wall and demise to collect allies " +
                    "before MEANIE MUELLER gets to you first");

            timer1.Start();
         
        }

        /// <summary>
        /// Paints objects on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gameCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (gameOver == true)
            {
                
                timer1.Stop();
                MessageBox.Show("GAME OVER. Sad!");
                //gameOver = false;
                System.Environment.Exit(0);
                
            }
            else
            {
                
                mueller.Draw(e.Graphics);
                trump.Draw(e.Graphics);
                foreach (Allies ally in allies)
                {
                    ally.Draw(e.Graphics);
                }
                DisplayAllyCount(e.Graphics);
            }
           

        }

      
        public void displayAllies(Graphics graphics)
        {

        }
        /// <summary>
        /// Moves trump object depending on which arrow key is being pressed down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

            }
        }
        /// <summary>
        /// Checks Trump object collisions
        /// </summary>
        private void CheckForCollisions()
        {

            //first remove any allies objects that miss the paddle
            for (int x = 0; x < allies.Count; x++)
                if (trump.TrumpBox.IntersectsWith(allies[x].AllyBox))
                {
                    allies.Remove(allies[x]);
                    countAllies++;
                    GoodJob.PlayFromStart();
                }
            
            

        }
        /// <summary>
        /// Checks for MUeller object collision with walls and Trump object
        /// </summary>
        private void MuellerCollision()
        {
            if (mueller.CurrentX <= this.DisplayRectangle.Left)
            {
                mueller.FlipX();
            }

            //collision with right wall
            if (mueller.CurrentX + mueller.Size >= this.DisplayRectangle.Right)
            {
                mueller.FlipX();
            }

            //collision with ceiling
            if (mueller.CurrentY >this.DisplayRectangle.Top)
            {
                mueller.FlipY();
                // boing.PlayFromStart();
            }
            //collision with bottom wall
            if (mueller.CurrentY < this.DisplayRectangle.Bottom)
            {
                mueller.FlipY();
            }
            if (mueller.MuellerBox.IntersectsWith(trump.TrumpBox))
            {
                Catastrophy.PlayFromStart();
                gameOver = true;
            }
        }

            private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        public void timer1_Tick(object sender, EventArgs e)
        {

            mueller.Move();
            CheckForCollisions();
            MuellerCollision();
           // DisplayAllyCount(e.Graphics);
            Invalidate();
        }

        public void DisplayAllyCount(Graphics graphics)
        {
            //for (int x = 0; x > allies.Count;)
            //    if (trump.TrumpBox.IntersectsWith(allies[x].AllyBox))
            //    {
                    //x++;
                //ask the hashset for it's current count
                    string display = String.Format("Trump allies: {0}", countAllies );
                    Font font = new Font("Verdana", 20);
                    graphics.DrawString(display, font, Brushes.White, 200, 20);
                    
                
         
        }

        private void ChooseLevelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

    }
}
