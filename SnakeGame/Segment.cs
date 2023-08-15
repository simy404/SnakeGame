using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    internal class Segment : Panel
    {
        public Segment() {
            Size = new Size(20, 20);
            BackColor = Color.Gray;
        }
    }
}
