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
    class Trump
    {
        public Rectangle TrumpBox;
        public Rectangle mainCanvas;
        private int size = 40;
        public enum Direction { Left, Right, Up, Down }
        private Image image;

        public Trump(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            //set size of ballBox
            TrumpBox.Height = size;
            TrumpBox.Width = size;

            //set intial position of  trump
            
            TrumpBox.X = (mainCanvas.Width /2) - (size / 2);
            TrumpBox.Y = (mainCanvas.Height / 2) - (size / 2);

            image = Image.FromFile("Images/donald_trump_PNG84.png");

        }
        //create two properties
        public int CurrentX { get { return TrumpBox.X; } }
        public int CurrentY { get { return TrumpBox.Y; } }
        public int Size { get { return size; } }

        /// <summary>
        /// Specified direction and velocity of direction
        /// </summary>
        /// <param name="direction">determines what direction object travels at</param>
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (TrumpBox.X > 25)
                        {
                            TrumpBox.X = TrumpBox.X - 25;
                        }
                        else
                        {
                            TrumpBox.X = 0;
                        }
                        break;
                    }

                case Direction.Right:
                    {
                        //right side isn't a fixed number and is relative, so cannot use above logic
                        //if there is less than 25px left before wall
                        //move to the wall, otherwise move 25
                        if (mainCanvas.Right - TrumpBox.Right < 25)
                        {
                            //move to wall
                            TrumpBox.X = mainCanvas.Width - TrumpBox.Width;
                        }
                        else
                        {
                            //otherwise move full 25
                            TrumpBox.X += 25;
                        }
                        //same as above except in different direction                        
                        break;
                    }
                case Direction.Up:
                    {
                        if (mainCanvas.Top + TrumpBox.Top > -25)
                        {
                            TrumpBox.Y = TrumpBox.Y - 25;
                        }
                        else
                        {
                            TrumpBox.Y = 0;
                        }
                        break;
                    }
                case Direction.Down:
                    {
                        if (TrumpBox.Y > mainCanvas.Height)
                        {
                            TrumpBox.Y = mainCanvas.Height +25;
                        }
                        else
                        {
                            TrumpBox.Y = TrumpBox.Y + 25;
                        }
                        break;
                    }
            }
        }
        public void Draw(Graphics graphics)
        {
            //graphics.FillEllipse(Brushes.White, BallBox);
            graphics.DrawImage(image, TrumpBox);
        }
        //public void FlipX()
        //{
        //    xVelocity = xVelocity * -1;
        //}
        //public void FlipY()
        //{
        //    yVelocity *= -1;
        //}
    }
}
