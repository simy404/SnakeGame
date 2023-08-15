using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    internal class GameBoard
    {
        private Panel _GameBoard;
        public int BoardWith { get => _GameBoard.Width; set=> _GameBoard.Width=value; }
        public int BoardHeight { get => _GameBoard.Height; set => _GameBoard.Height = value; }

        public GameBoard(Panel GameBoard,Color color)
        {
            _GameBoard = GameBoard;
            GameBoard.BackColor = color;
        }

        public void AddControl(Segment segment) 
        {
           _GameBoard.Controls.Add(segment);
        }

        public void AddFood(Panel food)
        {
            _GameBoard.Controls.Add(food);
        }

    }
}
