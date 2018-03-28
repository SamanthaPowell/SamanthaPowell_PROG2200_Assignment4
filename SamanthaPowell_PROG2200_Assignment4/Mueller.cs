using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamanthaPowell_PROG2200_Assignment4
{
    public class Mueller
    {
        public Rectangle MuellerBox;
        public Rectangle mainCanvas;
        private int size = 50;

        private int XVelocity;
        private int YVelocity;

        private Random random = new Random();
        
        private Image imageMueller;      
        /// <summary>
        /// Sets primary location of Mueller as random coordinate between coord's specified
        /// </summary>
        /// <param name="mainCanvas"></param>
        public Mueller(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            MuellerBox.X = random.Next(50, mainCanvas.Width);
            MuellerBox.Y = random.Next(50, mainCanvas.Height);

         
            while (XVelocity > -10 && XVelocity < 10)
                XVelocity = random.Next(-30, 30);

            while (YVelocity > -3 && YVelocity < 3)
                YVelocity = random.Next(-30, 30);

            //set size of muellerpng
            MuellerBox.Height = size;
            MuellerBox.Width = size;
            imageMueller = Image.FromFile("Images/robert-mueller.png");

            //set initial position of Mueller
        }
        public int CurrentX { get { return MuellerBox.X; } }
        public int CurrentY { get { return MuellerBox.Y; } }
     
        public int Size { get { return size; } }
        /// <summary>
        /// Moves object's coordinates
        /// </summary>
        public void Move()
        {
            this.MuellerBox.X += XVelocity;
            this.MuellerBox.Y += YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(imageMueller, MuellerBox);
        }
        /// <summary>
        /// If Mueller object collides, will flip object and travel in opposite direction
        /// </summary>
        public void FlipX()
        {
            XVelocity *= -1;
        }

        public void FlipY()
        {
            YVelocity *= -1;
        }
    }
}
