using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// contains ally objects which will display on load and be collected throughout game
/// </summary>
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

        /// <summary>
        /// //create two properties and set initial location as randomized between specified coordinates
        /// </summary>
        /// <param name="mainCanvas">Game Form object</param>
        public Allies(Rectangle mainCanvas)
        {
            CurrentX = random.Next(50, mainCanvas.Width);
            CurrentY = random.Next(0, 500);

            AllyBox.X = CurrentX;
            AllyBox.Y = CurrentY;
            this.mainCanvas = mainCanvas;
            //set size of ballBox
            AllyBox.Height = size;
            AllyBox.Width = size;
            img =  random.Next(0, 8);

            ImageChosen = Image.FromFile(Images[img]);
            
        }
        

        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public int Size { get { return size; } }

      
        /// <summary>
        /// Draws objects
        /// </summary>
        /// <param name="graphics">imported graphics object</param>

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(ImageChosen, AllyBox);    
        }
       
    }
}
