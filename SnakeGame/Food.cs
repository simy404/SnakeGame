using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SnakeGame
{
    internal class Food
    {
        private Panel food;
        public int locationX { get => food.Location.X; }
        public int locationY { get => food.Location.Y; }

        public Food(Size size, Color color, Point point)
        {
            food = new Panel();
            food.Size = size;
            food.BackColor = color;
            food.Location = point;
        }

        public Panel Get()
        {
            return food;
        }

        public void DestroyFood()
        {
            food.Dispose();
        }
    }
}
