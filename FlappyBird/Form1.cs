using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 6;
        int gravity = 14;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pipeTop_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score.ToString();

            if (pipeBottom.Left < -50)
            {
                Random rnd = new Random();    
                pipeBottom.Left = rnd.Next(580, 600); ;
                score++;
            }
            if (pipeTop.Left < -50)
            {
                Random rnd2 = new Random();
                pipeTop.Left = rnd2  .Next(620, 650); ;

            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            if (score > 5)
            {
                notifyLabel.Text = "Speed Upgraded to 10";
                pipeSpeed = 10;  
            }
            if (score > 15)
            {
                notifyLabel.Text = "Speed Upgraded to 15";
                pipeSpeed = 15;
            }
            if (score > 25)
            {
                notifyLabel.Text = "Speed Upgraded to 20";
                pipeSpeed = 20;
            }
            if (score > 40)
            {
                notifyLabel.Text = "Speed Upgraded to 25";
                pipeSpeed = 25;
            }
            if (flappyBird.Top < -25)
            {
                endGame();
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -14;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 14;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
        }
    }
}
