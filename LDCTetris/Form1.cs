using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDCTetris
{
    public partial class Form1 : Form
    {
        Shape currentShape;
        Shape nextShape;
        Timer timer = new Timer();
        Timer timerDisplay = new Timer();
        int timerCount = 0;
        public Form1()
        {
            InitializeComponent();

            // Load the playing area
            LoadCanvas();

            // Generate a shape
            currentShape = getRandomShapeCentered();
            nextShape = getNextShape();

            // Timer
            timer.Tick += TimerEveryTick;
            timer.Interval = 500;
            timer.Start();

            // Display Time
            timerDisplay.Tick += TimerDisplayTick;
            timerDisplay.Interval = 1000;
            timerDisplay.Start();

            // Listener to KeyDown
            this.KeyDown += Form1KeyDown;
        }

        private void Form1KeyDown(object obj, KeyEventArgs e)
        {
            var moveX = 0;
            var moveY = 0;

            // calculate X & Y move values based on the key pressed
            switch (e.KeyCode)
            {
                case Keys.Left:
                    moveY--;
                    break;

                case Keys.Right:
                    moveY++;
                    break;

                case Keys.Down:
                    moveX++;
                    break;

                case Keys.Up:
                    currentShape.turn();
                    break;
                case Keys.Z:
                    clearGrid();
                    break;
                default:
                    return;
            }

            var isMoveSuccess = checkForMoveShape(moveX, moveY);

            // Rollback if needed
            if(!isMoveSuccess && e.KeyCode == Keys.Up)
            {
                currentShape.rollBack();
            }
        }

        private void TimerEveryTick(object obj, EventArgs e)
        {
            // Try to move down the shape
            var isMoveSuccess = checkForMoveShape(toDown: 1);

            if (!isMoveSuccess)
            {
                // Copy working image into canvas image
                canvasBitmap = new Bitmap(workingBitmap);

                // Update the canvas
                updateCanvasWithCurrentShape();

                // Generate next shape
                currentShape = nextShape;
                nextShape = getNextShape();

                scoringSystem();
            }
        }

        private void TimerDisplayTick(object obj, EventArgs e)
        {
            timerCount++;
            int min = timerCount / 60;
            int sec = timerCount % 60;
            labelTime.Text = string.Format("{0}:{1}",min.ToString("00"),sec.ToString("00"));
        }

        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        readonly int canvasWidth = 15;
        readonly int canvasHeight = 20;
        int[,] canvasDotArray;
        readonly int dotSize = 20;

        private void LoadCanvas()
        {
            // Resize Picture box 1
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            // Create Bitmap with picture box's size
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            canvasGraphics = Graphics.FromImage(canvasBitmap);
            
            // Background
            canvasGraphics.FillRectangle(Brushes.White, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

            // Load bitmap into picture box
            pictureBox1.Image = canvasBitmap;

            // Init canvas dot array, 0 by default
            canvasDotArray = new int[canvasWidth, canvasHeight];
        }

        int currentX;
        int currentY;

        private Shape getRandomShapeCentered()
        {
            // We take a shape from the Handler Method
            var shape = ShapesHandler.GetRandomShape();

            // Calculate the X and Y values as if the shape lies in the center
            currentX = 7; // half of the width of playing area
            currentY = -shape.Height; // negative shape size offset to start offscreen

            return shape;
        }

        private bool checkForMoveShape(int toDown = 0, int toSide = 0)
        {
            // Calculate next coords
            var newX = currentX + toSide;
            var newY = currentY + toDown;

            // Check for area hitboxes
            if( newX < 0 || 
                newX + currentShape.Width > canvasWidth || 
                newY + currentShape.Height > canvasHeight )
            {
                return false;
            }

            // Check other shapes hitboxes
            for (int i = 0; i < currentShape.Width; i++)
            {
                for(int j = 0; j < currentShape.Height; j++)
                {
                    if( newY + j > 0 && 
                        canvasDotArray[newX + i, newY + j] == 1 &&
                        currentShape.Dots[j, i] == 1 )
                    {
                        return false;
                    }
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }

        Bitmap workingBitmap;
        Graphics workingGraphics;

        private void drawShape()
        {
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                    {
                        if (currentShape.Color == "red")
                        {
                            workingGraphics.FillRectangle(Brushes.Red, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else if (currentShape.Color == "yellow")
                        {
                            workingGraphics.FillRectangle(Brushes.Yellow, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else if (currentShape.Color == "blue")
                        {
                            workingGraphics.FillRectangle(Brushes.Blue, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else if (currentShape.Color == "green")
                        {
                            workingGraphics.FillRectangle(Brushes.Green, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else if (currentShape.Color == "orange")
                        {
                            workingGraphics.FillRectangle(Brushes.Orange, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else if (currentShape.Color == "purple")
                        {
                            workingGraphics.FillRectangle(Brushes.Purple, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else if (currentShape.Color == "cyan")
                        {
                            workingGraphics.FillRectangle(Brushes.Cyan, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                        else
                        {
                            workingGraphics.FillRectangle(Brushes.Black, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                        }
                    }
                }
            }

            pictureBox1.Image = workingBitmap;        
        }

        private void updateCanvasWithCurrentShape()
        {
            for(int i = 0; i < currentShape.Width; i++)
            {
                for(int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] == 1)
                    {
                        if (!checkGameOver())
                        {
                            canvasDotArray[currentX + i, currentY + j] = 1;
                        }
                    }
                }
            }
        }

        private Boolean checkGameOver()
        {
            if(currentY < 0)
            {
                timer.Stop();
                MessageBox.Show("Game Over!");
                Application.Exit();
                return true;
            }
            return false;
        }

        int score;
        public void scoringSystem()
        {
            // check through each rows
            for(int i = 0; i < canvasHeight; i++)
            {
                int j;
                for(j = canvasWidth - 1; j >= 0; j--)
                {
                    if(canvasDotArray[j, i] == 0)
                    {
                        break;
                    }
                }

                if(j == -1)
                {
                    // Update lavels
                    score += 100;
                    scoreLabel.Text = "Score: " + score;
                    levelLabel.Text = "Niveau: " + score / 1000;
                    // MORE SPEEEEEEEEEED
                    timer.Interval -= 20;

                    // Update the dot array based on the check
                    for (j = 0; j < canvasWidth; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            canvasDotArray[j, k] = canvasDotArray[j, k - 1];
                        }

                        canvasDotArray[j, 0] = 0;
                    }
                }
            }
            drawGrid();
        }

        private void drawGrid()
        {
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    canvasGraphics.FillRectangle(
                        canvasDotArray[i, j] == 1 ? Brushes.Gray : Brushes.White,
                        i * dotSize, j * dotSize, dotSize, dotSize
                    );
                }
            }

            pictureBox1.Image = canvasBitmap;
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;

        private Shape getNextShape()
        {
            var shape = getRandomShapeCentered();

            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);

            nextShapeGraphics.FillRectangle(Brushes.LightGray, 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);

            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {
                    switch (shape.Color)
                    {
                        case "red":
                            nextShapeGraphics.FillRectangle(
                                shape.Dots[i, j] == 1 ? Brushes.Red : Brushes.LightGray,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                            break;

                        case "blue":
                            nextShapeGraphics.FillRectangle(
                                shape.Dots[i, j] == 1 ? Brushes.Blue : Brushes.LightGray,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                            break;

                        case "green":
                            nextShapeGraphics.FillRectangle(
                                shape.Dots[i, j] == 1 ? Brushes.Green : Brushes.LightGray,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                            break;

                        case "orange":
                            nextShapeGraphics.FillRectangle(
                                shape.Dots[i, j] == 1 ? Brushes.Orange : Brushes.LightGray,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                            break;

                        case "purple":
                            nextShapeGraphics.FillRectangle(
                                shape.Dots[i, j] == 1 ? Brushes.Purple : Brushes.LightGray,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                            break;

                        case "cyan":
                            nextShapeGraphics.FillRectangle(
                                shape.Dots[i, j] == 1 ? Brushes.Cyan : Brushes.LightGray,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                            break;

                        case "yellow":
                            nextShapeGraphics.FillRectangle(
                                shape.Dots[i, j] == 1 ? Brushes.Yellow : Brushes.LightGray,
                                (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize
                            );
                            break;
                    }
                }
            }

            scoreBox.Size = nextShapeBitmap.Size;
            scoreBox.Image = nextShapeBitmap;

            return shape;
        }

        private void clearGrid()
        {
            canvasDotArray = new int[canvasWidth, canvasHeight];
            drawGrid();
        }
    }
}
