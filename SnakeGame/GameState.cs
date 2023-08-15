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
        private GameBoard GameBoard;
        private Snake Snake;
        private Food food;
        private bool isFoodGenerated = false;
        Direction direction;
        public event Action IsFoodGenerate;
        public GameState(Panel _GameBoard)
        {
            GameBoard = new GameBoard(_GameBoard, Color.Black);
            Snake = new Snake();           
            GameBoard.AddControl(Snake[0]);
            GenerateFood();
        }

        public void UpdateSnakePosition()
        {
            int lockX = Snake[0].Location.X;
            int lockY = Snake[0].Location.Y;

            switch (direction)
            {
                case Direction.Left:
                    lockX -= 20;
                    break;
                case Direction.Right:
                    lockX += 20;
                    break;
                case Direction.Up:
                    lockY -= 20;
                    break;
                case Direction.Down:
                    lockY += 20;
                    break;
            }

            lockX = IsSnakeInsideGrid(lockX, 0, GameBoard.BoardWith - 20);
            lockY = IsSnakeInsideGrid(lockY, 0, GameBoard.BoardHeight - 20);


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

        public void DeterminateDirection(Keys key)
        {
            switch (key)
            {
                case Keys.A when direction is not Direction.Right:
                    direction = Direction.Left;
                    break;
                case Keys.D when direction is not Direction.Left:
                    direction = Direction.Right;
                    break;
                case Keys.W when direction is not Direction.Down:
                    direction = Direction.Up;
                    break;
                case Keys.S when direction is not Direction.Up:
                    direction = Direction.Down;
                    break;
                default:                    
                    break;
            }
        }

        public void GenerateFood()
        {
            if (isFoodGenerated == true) return;
            
            Random randCord = new Random();
            int CordX = randCord.Next(0, GameBoard.BoardWith / 20) * 20;
            int CordY = randCord.Next(0, GameBoard.BoardHeight / 20) * 20;
            
            Size Size = new Size(20, 20);
            Color BackColor = Color.Red;
            Point Location = new Point(CordX, CordY);
            food = new Food(Size, BackColor, Location);
            
            GameBoard.AddFood(food.Get());
            isFoodGenerated = true;
        }

        public void IsEatFood()
        {
            if (isFoodGenerated is false) return;

            int sLockX = Snake[0].Location.X;
            int slockY = Snake[0].Location.Y;

            int fLockX = food.locationX;
            int fLockY = food.locationY;

            if (sLockX == fLockX && slockY == fLockY)
            {
                food.DestroyFood();
                isFoodGenerated = false;                
                AddSegment();

                //Trigger GenerateFood() func
                IsFoodGenerate?.Invoke();
            }

        }

        public void SnakeMove()
        {
            for (int i = Snake.SegmentCount - 1; i > 0; i--)
            {
                Snake[i].Location = Snake[i - 1].Location;
            }
        }

        public  bool CheckSelfCollision()
        {
            for (int i = 2; i < Snake.SegmentCount; i++)
            {
                if (Snake[0].Location == Snake[i].Location)
                    return true;                  
            }
                return false;
        }

        private void AddSegment()
        {
            Segment segment = new Segment();
            Snake.AddSegment(segment);
            GameBoard.AddControl(segment);
        }


    }
}
