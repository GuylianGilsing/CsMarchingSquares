using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using GuylianGilsing.MarchingSquares;

namespace CsMarchingSquares
{
    public partial class Form1 : Form
    {
        private PictureBox pcbCanvas = null;

        private int pointDistance = 32;
        private MsqAlgorithm marchingSquaresAlgorithm = null;

        Timer tmr = new Timer();

        int t = 0;

        public Form1()
        {
            InitializeComponent();
            this.CreateExtraComponents();

            this.Width = 640;
            this.Height = 480;
            this.BackColor = Color.Red;

            this.Load += this.Form1_Load;
        }

        private void CreateExtraComponents()
        {
            // Create the canvas
            this.pcbCanvas = new PictureBox();
            this.pcbCanvas.Top = 0;
            this.pcbCanvas.Left = 0;
            this.pcbCanvas.Width = this.Width;
            this.pcbCanvas.Height = this.Height;
            this.pcbCanvas.BackColor = Color.Gray;
            this.pcbCanvas.BringToFront();

            this.pcbCanvas.Paint += this.Draw;

            this.Controls.Add(this.pcbCanvas);
            this.Update();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            this.marchingSquaresAlgorithm = new MsqAlgorithm(this.Width, this.Height, 32);

            // Generate and set the algorithm points
            List<MsqPoint> algoPoints = this.GeneratePoints();
            this.marchingSquaresAlgorithm.SetPoints(algoPoints);

            tmr.Tick += this.Tick;
            tmr.Interval = 10;
            tmr.Start();
        }

        private void Tick(Object sender, EventArgs e)
        {
            this.pcbCanvas.Refresh();

            if(this.t < this.marchingSquaresAlgorithm.squaresToMarch.Count)
            {
                this.t += 1;
            }
            else
            {
                this.t = 0;
            }
        }

        /// <summary>
        /// Creates and returns a list of points that can be used by the algorithm.
        /// </summary>
        private List<MsqPoint> GeneratePoints()
        {
            // Create a point list to feed to the algorithm
            List<MsqPoint> algoPoints = new List<MsqPoint>();
            for(int y = 0; y <= (this.Height / this.pointDistance) + 2; y += 1)
            {
                for(int x = 0; x <= (this.Width / this.pointDistance) + 2; x += 1)
                {
                    // Create the color
                    Random rng = new Random();

                    // Set the point to either black or white based on the middle value:
                    // * 128 - 255 = black
                    // * 0 - 127 = white
                    byte color = (byte)((rng.Next(0, 255) >= 128) ? 255 : 0);

                    // Create and register the point
                    MsqPoint point = new MsqPoint(x * this.pointDistance, y * this.pointDistance, color);
                    algoPoints.Add(point);
                }
            }

            return algoPoints;
        }

        private void Draw(Object a_sender, PaintEventArgs a_e)
        {
            // this.DrawSquares(a_e);
            this.DrawPoints(a_e);

            this.DrawSquare(this.t, a_e);
        }

        private void DrawSquare(int a_index, PaintEventArgs a_e)
        {
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 1);

            MsqSquare square = this.marchingSquaresAlgorithm.squaresToMarch[a_index];

            pen.Color = Color.Black;
            a_e.Graphics.FillRectangle(brush, new Rectangle(square.topLeft.x, square.topLeft.y, square.width - 1, square.height - 1));
        }

        private void DrawSquares(PaintEventArgs a_e)
        {
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 1);

            foreach(MsqSquare square in this.marchingSquaresAlgorithm.squaresToMarch)
            {
                Console.WriteLine($"tl: {square.topLeft.x} br: {square.bottomRight.x} w: {square.width} h: {square.height}");

                pen.Color = Color.Black;
                a_e.Graphics.FillRectangle(brush, new Rectangle(square.topLeft.x, square.topLeft.y, square.width - 1, square.height - 1));
            }
        }

        private void DrawPoints(PaintEventArgs a_e)
        {
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush, 1);

            foreach(MsqSquare square in this.marchingSquaresAlgorithm.squaresToMarch)
            {
                MsqPoint topLeft = new MsqPoint(square.topLeft.x, square.topLeft.y, square.topLeft.color);
                MsqPoint topRight = new MsqPoint(square.topRight.x, square.topRight.y, square.topRight.color);
                MsqPoint bottomLeft = new MsqPoint(square.bottomLeft.x, square.bottomLeft.y, square.bottomLeft.color);
                MsqPoint bottomRight = new MsqPoint(square.bottomRight.x, square.bottomRight.y, square.bottomRight.color);

                // Set the color and draw the corner points
                pen.Color = Color.FromArgb(topLeft.color, topLeft.color, topLeft.color);
                a_e.Graphics.DrawRectangle(pen, new Rectangle(topLeft.x, topLeft.y, 8, 8));

                pen.Color = Color.FromArgb(topRight.color, topRight.color, topRight.color);
                a_e.Graphics.DrawRectangle(pen, new Rectangle(topRight.x, topRight.y, 8, 8));

                pen.Color = Color.FromArgb(bottomLeft.color, bottomLeft.color, bottomLeft.color);
                a_e.Graphics.DrawRectangle(pen, new Rectangle(bottomLeft.x, bottomLeft.y, 8, 8));

                pen.Color = Color.FromArgb(bottomRight.color, bottomRight.color, bottomRight.color);
                a_e.Graphics.DrawRectangle(pen, new Rectangle(bottomRight.x, bottomRight.y, 8, 8));
            }
        }
    }
}
