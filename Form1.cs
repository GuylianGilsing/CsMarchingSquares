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
        private MsqRenderer renderer = new MsqRenderer();

        private List<MsqPoint> debugPoints = new List<MsqPoint>();

        Timer tmrUpdateCanvas = new Timer();

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

            this.Update(null, null);

            this.tmrUpdateCanvas.Interval = 500;
            this.tmrUpdateCanvas.Tick += this.Update;
            this.tmrUpdateCanvas.Start();
        }

        private void Update(Object a_sender, EventArgs a_e)
        {
            // Generate and set the algorithm points
            List<MsqPoint> algoPoints = this.GeneratePoints(1, 0);
            this.marchingSquaresAlgorithm.SetPoints(algoPoints, 1, 0);
            this.marchingSquaresAlgorithm.RunOnce();
        
            this.pcbCanvas.Refresh();
        }

        /// <summary>
        /// Creates and returns a list of points that can be used by the algorithm.
        /// </summary>
        private List<MsqPoint> GeneratePoints(int a_padX = 0, int a_padY = 0)
        {
            // Create a point list to feed to the algorithm
            List<MsqPoint> algoPoints = new List<MsqPoint>();
            for(int y = 0; y < (this.Height / this.pointDistance) + a_padY; y += 1)
            {
                for(int x = 0; x < (this.Width / this.pointDistance) + a_padX; x += 1)
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
            this.renderer.Render(this.marchingSquaresAlgorithm, a_e);
        }
    }
}
