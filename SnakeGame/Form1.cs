using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class SnakeGame : Form
    {
        static GameState gameState;
        
        public SnakeGame()
        {
            InitializeComponent();
            gameState = new GameState(panel1);
            gameState.IsFoodGenerate += () => gameState.GenerateFood();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameState.CheckSelfCollision()) {
                gameState.IsEatFood();
                gameState.UpdateSnakePosition();
                gameState.SnakeMove();
            } 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gameState.DeterminateDirection((Keys)e.KeyValue);
                      
        }
    }
}
