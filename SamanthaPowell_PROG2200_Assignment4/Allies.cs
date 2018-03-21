using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamanthaPowell_PROG2200_Assignment4
{
    class Allies
    {
        public Rectangle AllyBox;
        public Rectangle mainCanvas;
        private int size = 40;
        private int xVelocity;
        private int yVelocity;
        private Random random = new Random();
        private Image imageSessions;

        public Allies(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            //set size of ballBox
            AllyBox.Height = size;
            AllyBox.Width = size;

            //set intial position of ball
            AllyBox.X = (mainCanvas.Width / 2) - (size / 2);
            AllyBox.Y = (mainCanvas.Height / 2) - (size / 2);


            imageSessions = Image.FromFile("Images/sessions.png");

        }
        //create two properties
        public int CurrentX { get { return AllyBox.X; } }
        public int CurrentY { get { return AllyBox.Y; } }
        public int Size { get { return size; } }


        public void Draw(Graphics graphics)
        {
            //graphics.FillEllipse(Brushes.White, BallBox);
            graphics.DrawImage(imageSessions, AllyBox);
        }
       
    }
}
