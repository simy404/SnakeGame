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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static GameState gameState;
        Direction direction = Direction.up;
        private void Form1_Load(object sender, EventArgs e)
        {
            gameState = new GameState(panel1);              
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameState.CheckSelfCollision()) {
                gameState.UpdateGame(direction);
            } 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gameState.Move((Keys)e.KeyValue, out direction);
            button1.Text = e.KeyCode.ToString();            
        }
    }
}
