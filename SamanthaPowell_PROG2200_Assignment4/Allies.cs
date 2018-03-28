using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamanthaPowell_PROG2200_Assignment4
{
   public class Allies
    {
        public Rectangle AllyBox;
        public Rectangle mainCanvas;
        private int size = 50;
        private Random random = new Random();
        private Image ImageChosen;
        private int img;
        private string[] Images = { "Images/sessions.png", "Images/sean-spicer.png", "Images/michael-flynn.png",
            "Images/scaramucci.png","Images/kellyanne-conway.png", "Images/steve-bannon.png",
            "Images/Omarosa.png", "Images/RexTillerson.png" };
        public Allies(Rectangle mainCanvas)
        {
            CurrentX = random.Next(50, mainCanvas.Width);
            CurrentY = random.Next(20, 100);

            AllyBox.X = CurrentX;
            AllyBox.Y = CurrentY;
            this.mainCanvas = mainCanvas;
            //set size of ballBox
            AllyBox.Height = size;
            AllyBox.Width = size;
            img =  random.Next(0, 8);

            ImageChosen = Image.FromFile(Images[img]);
            
        }
        //create two properties
        //public int CurrentX { get { return AllyBox.X; } }
        //public int CurrentY { get { return AllyBox.Y; } }

        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public int Size { get { return size; } }

        //set intitial random location of objects


        public void Draw(Graphics graphics)
        {
            //graphics.FillEllipse(Brushes.White, BallBox);
            graphics.DrawImage(ImageChosen, AllyBox);
          
          
        }
       
    }
}
