using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Run4Fun
{
    public partial class gameForm : Form
    {
        // Wdith of tile.
        private const int tileWidth = 230;

        // Height of tile.
        private const int tileHeight = 200;
        private const int minimumTileHeight = 100;
        private const int maximumTileHeight = 500;

        // The X coordinate for the middle(3rd) tile.
        private static int middleTileX;

        // The player object.
        private Rectangle rectanglePlayer;

        // Player size.
        private const int playerSize = 25;

        // Declaration of the rectangle objects used.
        private Rectangle rectangle1;
        private Rectangle rectangle2;
        private Rectangle rectangle3;
        private Rectangle rectangle4;
        private Rectangle rectangle5;

        /*
        private Rectangle rectangle6;
        private Rectangle rectangle7;
        private Rectangle rectangle8;
        private Rectangle rectangle9;
        private Rectangle rectangle10;
        */

        // TODO Make it work with arraylist.
        private ArrayList rectangles = new ArrayList();

        // Speed of the tile.
        private int speed = 50;

        // Intensity.
        private int intensity = 1;

        private double score = 0;

        public gameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            rectanglePlayer = new Rectangle((Width / 2) - (playerSize / 2), Height - 200, playerSize, playerSize);

            middleTileX = (Width / 2) - (tileWidth / 2);

            rectangle1 = new Rectangle(middleTileX - (2 * tileWidth), -tileHeight, tileWidth, maximumTileHeight);
            rectangle2 = new Rectangle(middleTileX - tileWidth, -tileHeight, tileWidth, maximumTileHeight);
            rectangle3 = new Rectangle(middleTileX, -tileHeight, tileWidth, maximumTileHeight);
            rectangle4 = new Rectangle(middleTileX + tileWidth, -tileHeight, tileWidth, maximumTileHeight);
            rectangle5 = new Rectangle(middleTileX + (2 * tileWidth), -tileHeight, tileWidth, maximumTileHeight);

            /*
            rectangle6 = new Rectangle(middleTileX - (2 * tileWidth), -tileHeight, tileWidth, maximumTileHeight);
            rectangle7 = new Rectangle(middleTileX - tileWidth, -tileHeight, tileWidth, maximumTileHeight);
            rectangle8 = new Rectangle(middleTileX, -tileHeight, tileWidth, maximumTileHeight);
            rectangle9 = new Rectangle(middleTileX + tileWidth, -tileHeight, tileWidth, maximumTileHeight);
            rectangle10 = new Rectangle(middleTileX + (2 * tileWidth), -tileHeight, tileWidth, maximumTileHeight);
            */

            rectangles.Add(rectangle1);
            rectangles.Add(rectangle2);
            rectangles.Add(rectangle3);
            rectangles.Add(rectangle4);
            rectangles.Add(rectangle5);

            // TODO: use of foreach loop
            //for (int i = 0; i < 3; i++)
            //rectangles.Add(new Rectangle(0, 0, 200, 200));
        }

        /// <summary>
        /// Paints the game screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Yellow background.
            graphics.FillRectangle(Brushes.Gold, 385, 0, 1150, 1080);

            // Draw logo.
            graphics.DrawImage(Properties.Resources.logo, 1500, 400);

            if (!outOfScreen(rectangle1))
                graphics.FillRectangle(Brushes.Black, rectangle1);
            if (!outOfScreen(rectangle2))
                graphics.FillRectangle(Brushes.Black, rectangle2);
            if (!outOfScreen(rectangle3))
                graphics.FillRectangle(Brushes.Black, rectangle3);
            if (!outOfScreen(rectangle4))
                graphics.FillRectangle(Brushes.Black, rectangle4);
            if (!outOfScreen(rectangle5))
                graphics.FillRectangle(Brushes.Black, rectangle5);

            /*
            if (!outOfScreen(rectangle6))
                graphics.FillRectangle(Brushes.Black, rectangle6);
            if (!outOfScreen(rectangle7))
                graphics.FillRectangle(Brushes.Black, rectangle7);
            if (!outOfScreen(rectangle8))
                graphics.FillRectangle(Brushes.Black, rectangle8);
            if (!outOfScreen(rectangle9))
                graphics.FillRectangle(Brushes.Black, rectangle9);
            if (!outOfScreen(rectangle10))
                graphics.FillRectangle(Brushes.Black, rectangle10);
            */

            // Player.
            graphics.FillEllipse(Brushes.Red, rectanglePlayer);

            // TODO: use of foreach loop
            //foreach (Rectangle rectangle in rectangles) {
            //graphics.FillRectangle(Brushes.Cyan, rectangle);
            //}
        }

        /// <summary>
        /// Checks whether the rectangle given as parameter is below the screen.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        private bool outOfScreen(Rectangle rectangle)
        {
            return rectangle.Y > Height;
        }

        private Random random = new Random();

        /// <summary>
        /// Generate a random number between 0 and (intensity * screen height).
        /// </summary>
        /// <returns></returns>
        private int generateRandomY()
        {
            return random.Next(maximumTileHeight, intensity * Height);
        }

        /// <summary>
        /// Generate a random number between minimumTileHeight and maximumTileHeight.
        /// </summary>
        /// <returns></returns>
        private int genererateRandomTileHeight()
        {
            return random.Next(100, 500);
        }

        /// <summary>
        /// Repaint every timer tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            // TODO: use of loop
            //for (int i = 0; i < rectangles.Count; i++)
            //rectangles[i] = ...

            score += 1;
            lbScore.Text = score.ToString();

            // 1
            if (outOfScreen(rectangle1))
                rectangle1 = new Rectangle(middleTileX - (2 * tileWidth), -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle1.Y += speed;

            // 2
            if (outOfScreen(rectangle2))
                rectangle2 = new Rectangle(middleTileX - tileWidth, -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle2.Y += speed;

            // 3
            if (outOfScreen(rectangle3))
                rectangle3 = new Rectangle(middleTileX, -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle3.Y += speed;

            // 4
            if (outOfScreen(rectangle4))
                rectangle4 = new Rectangle(middleTileX + tileWidth, -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle4.Y += speed;

            // 5
            if (outOfScreen(rectangle5))
                rectangle5 = new Rectangle(middleTileX + (2 * tileWidth), -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle5.Y += speed;

            /*
            // 6
            if (rectangle6.Y >= Height)
                rectangle6 = new Rectangle(middleTileX - (2 * tileWidth), -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle6.Y += speed;

            // 7
            if (rectangle7.Y >= Height)
                rectangle7 = new Rectangle(middleTileX - tileWidth, -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle7.Y += speed;

            // 8
            if (rectangle8.Y >= Height)
                rectangle8 = new Rectangle(middleTileX, -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle8.Y += speed;

            // 9
            if (rectangle9.Y >= Height)
                rectangle9 = new Rectangle(middleTileX + tileWidth, -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle9.Y += speed;

            // 10
            if (rectangle10.Y >= Height)
                rectangle10 = new Rectangle(middleTileX + (2 * tileWidth), -generateRandomY(), tileWidth, genererateRandomTileHeight());
            else
                rectangle10.Y += speed;
             */

            /*
            // 1
            if (rectangle1.Y >= Height)
                rectangle1 = new Rectangle(middleTileX - (2 * tileWidth), -tileHeight, tileWidth, tileHeight);
            else
                rectangle1.Y += speed;

            // 2
            if (rectangle2.Y >= Height)
                rectangle2 = new Rectangle(middleTileX - tileWidth, -tileHeight, tileWidth, tileHeight);
            else
                rectangle2.Y += speed;

            // 3
            if (rectangle3.Y >= Height)
                rectangle3 = new Rectangle(middleTileX, -tileHeight, tileWidth, tileHeight);
            else
                rectangle3.Y += speed;

            // 4
            if (rectangle4.Y >= Height)
                rectangle4 = new Rectangle(middleTileX + tileWidth, -tileHeight, tileWidth, tileHeight);
            else
                rectangle4.Y += speed;

            // 5
            if (rectangle5.Y >= Height)
                rectangle5 = new Rectangle(middleTileX + (2 * tileWidth), -tileHeight, tileWidth, tileHeight);
            else
                rectangle5.Y += speed;*/

            Invalidate();
        }

        /// <summary>
        /// Close application on form close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Key listener for the player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    rectanglePlayer.X -= tileWidth;
                    break;
                case Keys.Right:
                    rectanglePlayer.X += tileWidth;
                    break;
            }
        }

    }
}
