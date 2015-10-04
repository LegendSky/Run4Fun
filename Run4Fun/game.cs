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

        // TODO Make it work with arraylist.
        private List<Rectangle> rectangles = new List<Rectangle>();

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

            rectangles.Add(rectangle1);
            rectangles.Add(rectangle2);
            rectangles.Add(rectangle3);
            rectangles.Add(rectangle4);
            rectangles.Add(rectangle5);

            //for (int i = 0; i < 5; i++)
            //rectangles.Add(new Rectangle(50, 50, 50, 50));
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

            // Player.
            graphics.FillEllipse(Brushes.Red, rectanglePlayer);

            // Draw all rectangles.
            foreach (Rectangle rect in rectangles)
            {
                if (!outOfScreen(rect))
                    graphics.FillRectangle(Brushes.Black, rect);
            }
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
        /// Modify the rectangles every tick of the timer, then repaint.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            // Score increases by 1 every tick.
            score += 1;
            lbScore.Text = score.ToString();

            // Iterate over rectangles list.
            for (int i = 0; i < rectangles.Count; i++)
            {
                Rectangle rect = rectangles[i];

                // If the tile is out of screen, create new tile. Otherwise increase the tile's Y by speed.
                if (outOfScreen(rect))
                    rect = new Rectangle(rect.X, -generateRandomY(), rect.Width, genererateRandomTileHeight());
                else
                    rect.Y += speed;

                // Assign the modified rectangle to the index of the list.
                rectangles[i] = rect;
            }
            // Repaint.
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
