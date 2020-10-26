using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using GuylianGilsing.MarchingSquares;
using SimplexNoise;

namespace CsMarchingSquares
{
    public partial class Form1 : Form
    {
        private PictureBox pcbCanvas = null;
        private int pointDistance = 4;
        private int simSpeed = 50;
        private MsqAlgorithm marchingSquaresAlgorithm = null;
        private MsqRenderer renderer = new MsqRenderer();
        private Timer tmrUpdateCanvas = new Timer();
        private float noiseIncrement = 100;
        private List<MetaBall> metaBalls = new List<MetaBall>();

        public Form1()
        {
            InitializeComponent();
            this.CreateExtraComponents();

            this.Width = 640;
            this.Height = 480;

            this.metaBalls.Add(new MetaBall(100, 100, 50, 5, 1));
            this.metaBalls.Add(new MetaBall(500, 80, 30, 1, 3));
            this.metaBalls.Add(new MetaBall(480, 320, 25, -2, 5));
            this.metaBalls.Add(new MetaBall(200, 200, 50, 5, 4));
            this.metaBalls.Add(new MetaBall(400, 320, 80, 1, -1));
            this.metaBalls.Add(new MetaBall(250, 65, 65, -3, -2));

            this.Load += this.Form1_Load;
            this.Text = "Marching Squares Metaballs";
        }

        private void CreateExtraComponents()
        {
            // Create the canvas
            this.pcbCanvas = new PictureBox();
            this.pcbCanvas.Top = 0;
            this.pcbCanvas.Left = 0;
            this.pcbCanvas.Width = this.Width;
            this.pcbCanvas.Height = this.Height;
            this.pcbCanvas.BackColor = Color.Black;
            this.pcbCanvas.BringToFront();

            this.pcbCanvas.Paint += this.Draw;
            // this.pcbCanvas.MouseMove += this.MouseMoved;

            this.Controls.Add(this.pcbCanvas);
            this.Update();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            this.marchingSquaresAlgorithm = new MsqAlgorithm(this.Width, this.Height, this.pointDistance);

            this.Update(null, null);

            this.tmrUpdateCanvas.Interval = this.simSpeed;
            this.tmrUpdateCanvas.Tick += this.Update;
            this.tmrUpdateCanvas.Start();
        }

        private void MouseMoved(Object a_sender, MouseEventArgs a_e)
        {
            this.metaBalls[0].x = a_e.X;
            this.metaBalls[0].y = a_e.Y;
        }

        private void Update(Object a_sender, EventArgs a_e)
        {
            this.MoveMetaBalls();

            // Generate and set the algorithm points
            List<MsqPoint> points = this.GenerateBlackPoints(1, 0);
            points = this.AddMetaBallColors(points);
            this.marchingSquaresAlgorithm.SetPoints(points, 1, 0);
            this.marchingSquaresAlgorithm.RunOnce();
        
            this.pcbCanvas.Refresh();
        }

        /// <summary>
        /// Creates and returns a list of points that can be used by the algorithm.
        /// </summary>
        private List<MsqPoint> GenerateNoisePoints(int a_padX = 0, int a_padY = 0)
        {
            // Create a point list to feed to the algorithm
            List<MsqPoint> algoPoints = new List<MsqPoint>();
            for(int y = 0; y < (this.Height / this.pointDistance) + a_padY; y += 1)
            {
                for(int x = 0; x < (this.Width / this.pointDistance) + a_padX; x += 1)
                {
                    // Randomize point colors by using simplex noise
                    float noiseValue = SimplexNoise.Noise.CalcPixel2D(x, y, this.noiseIncrement);
                    // Console.WriteLine(noiseValue);

                    // Set the point to either black or white based on the middle value:
                    // * 128 - 255 = black
                    // * 0 - 127 = white
                    byte color = (byte)((noiseValue >= 128) ? 255 : 0);

                    // Create and register the point
                    MsqPoint point = new MsqPoint(x * this.pointDistance, y * this.pointDistance, color);
                    algoPoints.Add(point);
                }
            }

            this.noiseIncrement += 0.01f;

            return algoPoints;
        }

        private List<MsqPoint> GenerateBlackPoints(int a_padX = 0, int a_padY = 0)
        {
            // Create a point list to feed to the algorithm
            List<MsqPoint> algoPoints = new List<MsqPoint>();
            for(int y = 0; y < (this.Height / this.pointDistance) + a_padY; y += 1)
            {
                for(int x = 0; x < (this.Width / this.pointDistance) + a_padX; x += 1)
                {
                    // Create and register the point
                    MsqPoint point = new MsqPoint(x * this.pointDistance, y * this.pointDistance, 0);
                    algoPoints.Add(point);
                }
            }

            return algoPoints;
        }

        private void MoveMetaBalls()
        {
            foreach(MetaBall metaBall in this.metaBalls)
            {
                if(metaBall.x + metaBall.radius >= this.Width || metaBall.x - metaBall.radius <= 0)
                    metaBall.speedX *= -1;

                if(metaBall.y + metaBall.radius >= this.Height || metaBall.y - metaBall.radius <= 0)
                    metaBall.speedY *= -1;

                metaBall.x += metaBall.speedX;
                metaBall.y += metaBall.speedY;
            }
        }

        private List<MsqPoint> AddMetaBallColors(List<MsqPoint> a_points)
        {
            foreach(MsqPoint point in a_points)
            {
                foreach(MetaBall metaBall in this.metaBalls)
                {
                    if(this.PointsIsInsideMetaBallRadius(point, metaBall))
                        point.color = 255;
                }
            }

            return a_points;
        }

        private bool PointsIsInsideMetaBallRadius(MsqPoint a_point, MetaBall a_ball)
        {
            bool inCircle = false;

            // Get the distance between the point and the meta ball
            double distanceX = Math.Pow(a_point.x - a_ball.x, 2);
            double distanceY = Math.Pow(a_point.y - a_ball.y, 2);
            double distance = Math.Sqrt(distanceX + distanceY);

            // If the distance is lower then the ball' radius, then it is inside of the radius
            if(distance <= a_ball.radius)
                inCircle = true;

            return inCircle;
        }

        private void Draw(Object a_sender, PaintEventArgs a_e)
        {
            this.renderer.Render(this.marchingSquaresAlgorithm, a_e);
        }
    }
}
