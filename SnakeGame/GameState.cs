using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    internal class GameState
    {
        private Panel GameBoard;
        private List<Panel> Snake;
        private Panel SnakeSegment;
        private Panel food;
        private bool isFoodGenerated = false;
        public GameState(Panel _GameBoard)
        {
            GameBoard = _GameBoard;
            GameBoard.BackColor = Color.Black;

            Snake = new List<Panel>();

            SnakeSegment = new Panel();
            SnakeSegment.Location = new Point(580, 200);
            SnakeSegment.Size = new Size(20, 20);
            SnakeSegment.BackColor = Color.Gray;

            Snake.Add(SnakeSegment);
            GameBoard.Controls.Add(Snake[0]);
        }

        private void SnakeDirection(Direction direction)
        {
            int lockX = Snake[0].Location.X;
            int lockY = Snake[0].Location.Y;

            switch (direction)
            {
                case Direction.left:
                    lockX -= 20;
                    break;
                case Direction.right:
                    lockX += 20;
                    break;
                case Direction.up:
                    lockY -= 20;
                    break;
                case Direction.down:
                    lockY += 20;
                    break;
            }

            lockX = IsSnakeInsideGrid(lockX, 0, GameBoard.Width - 20);
            lockY = IsSnakeInsideGrid(lockY, 0, GameBoard.Width - 20);


            Snake[0].Location = new Point(lockX, lockY);
        }

        private int IsSnakeInsideGrid(int value, int minValue, int maxValue)
        {
            if (value < minValue)
                return maxValue;
            if (value > maxValue)
                return minValue;
            return value;
        }

        public void Move(Keys key, out Direction direction)
        {
            switch (key)
            {
                case Keys.A:
                    direction = Direction.left;
                    break;
                case Keys.D:
                    direction = Direction.right;
                    break;
                case Keys.W:
                    direction = Direction.up;
                    break;
                case Keys.S:
                    direction = Direction.down;
                    break;
                default:
                    direction = Direction.none;
                    break;
            }
        }

        private void GenerateFood()
        {
            if (isFoodGenerated == true) return;
            Random randCord = new Random();
            int CordX = randCord.Next(0, GameBoard.Width / 20) * 20;
            int CordY = randCord.Next(0, GameBoard.Width / 20) * 20;

            food = new Panel();
            food.Size = new Size(20, 20);
            food.BackColor = Color.Red;
            food.Location = new Point(CordX, CordY);
            GameBoard.Controls.Add(food);

            isFoodGenerated = true;
        }

        private void EatFood()
        {
            if (isFoodGenerated is false) return;

            int sLockX = Snake[0].Location.X;
            int slockY = Snake[0].Location.Y;

            int fLockX = food.Location.X;
            int fLockY = food.Location.Y;

            if (sLockX == fLockX && slockY == fLockY)
            {
                food.Dispose();
                isFoodGenerated = false;                
                AddSegment();
            }

        }

        private void SnakeMove()
        {
            for (int i = Snake.Count - 1; i > 0; i--)
            {
                Snake[i].Location = Snake[i - 1].Location;
            }
        }

        public  bool CheckSelfCollision()
        {
            for (int i = 2; i < Snake.Count; i++)
            {
                if (Snake[0].Location == Snake[i].Location)
                    return true;
                        //todo game is over when eaten food;                   
            }
            return false;
        }

        private void AddSegment()
        {
            Panel Segment = new Panel();
            Segment.Size = new Size(20, 20);
            Segment.BackColor = Color.Gray;
            Snake.Add(Segment);
            GameBoard.Controls.Add(Segment);
        }

        public void UpdateGame(Direction direction)
        {
            SnakeDirection(
    direction);
            GenerateFood();
            EatFood();
            SnakeMove();
        }
    }
}
