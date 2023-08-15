using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    internal class Snake
    {
        private List<Segment> _Snake;
        public int SegmentCount { get =>_Snake.Count; }

        public Segment this[int _SnakeSegment]
        {
            get 
            { 
                return _Snake[_SnakeSegment]; 
            }
            set 
            { 
                _Snake[_SnakeSegment] = value; 
            }
        }
            
        public Snake() 
        {
            _Snake = new List<Segment>();
            
            Segment segment = new Segment();
            segment.Location = new Point(300, 300);

            
            _Snake.Add(segment);
        }        

        public void AddSegment(Segment snakeSegment) 
        {
            _Snake.Add(snakeSegment);
        }

    }
}
