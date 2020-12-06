using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        int scaleValue = 50;
        int boardSize = 15;
        int[,] snakeLocation = new int[16, 16]; //boardSize + 1
        int[,] foodLocation = new int[16, 16]; //boardSize + 1
        Button[,] snakePieces = new Button[16, 16];
        bool foodExists = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            for (int x = 1; x <= boardSize; x++)
            {
                for (int y = 1; y <= boardSize; y++)
                {
                    Random random = new Random();
                    startButton.Visible = false;
                    Button gridButton = new Button();
                    gridButton.Location = new Point(x * scaleValue, y * scaleValue);
                    this.Controls.Add(gridButton);
                    gridButton.Size = new Size(scaleValue, scaleValue);
                    if (random.Next(0, 100) >= 91 && foodExists == false)
                    {
                        foodExists = true;
                        Button foodButton = new Button();
                        this.Controls.Add(foodButton);
                        foodButton.BackColor = Color.Red;
                        foodButton.Location = new Point(x * scaleValue, y * scaleValue);
                        foodButton.Size = new Size(scaleValue, scaleValue);
                        foodButton.BringToFront();
                        foodLocation[x, y] = 1;

                    }
                    else if (x == boardSize && y == boardSize && foodExists == false)
                    {
                        foodExists = true;
                        Button foodButton = new Button();
                        this.Controls.Add(foodButton);
                        foodButton.BackColor = Color.Red;
                        foodButton.Location = new Point(x * scaleValue, y * scaleValue);
                        foodButton.Size = new Size(scaleValue, scaleValue);
                        foodButton.BringToFront();
                        foodLocation[x, y] = 1;
                    }

                    Button snake = new Button();
                    if (foodLocation[Convert.ToInt32(Math.Round(boardSize / 2.0)), Convert.ToInt32(Math.Round(boardSize / 2.0))] != 1)
                    {
                        snake.Location = new Point(Convert.ToInt32(Math.Round(boardSize / 2.0)) * scaleValue, Convert.ToInt32(Math.Round(boardSize / 2.0)) * scaleValue);
                    }
                    else
                    {
                        snake.Location = new Point(Convert.ToInt32(Math.Round(boardSize / 2.0)) * scaleValue + 1 * scaleValue, Convert.ToInt32(Math.Round(boardSize / 2.0)) * scaleValue);
                    }
                    snake.BackColor = Color.Green;
                    snake.BringToFront();
                    this.Controls.Add(snake);
                    snake.Size = new Size(scaleValue, scaleValue);
                }
            }
        }
    }
}
