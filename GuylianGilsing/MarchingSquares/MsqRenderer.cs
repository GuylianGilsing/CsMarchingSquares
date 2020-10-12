using System.Drawing;
using System.Windows.Forms;

namespace GuylianGilsing.MarchingSquares
{
    class MsqRenderer
    {
        private Graphics graphics = null;
        private Brush brush = new SolidBrush(Color.White);
        private Pen pen = null;

        public MsqRenderer(PaintEventArgs a_eventArgs)
        {
            this.graphics = a_eventArgs.Graphics;
            this.pen = new Pen(this.brush, 1);
        }

        public void Render(MsqAlgorithm a_algo)
        {
            if(a_algo.squaresToMarch.Count > 0)
            {
                foreach(MsqSquare square in a_algo.squaresToMarch)
                {
                    this.DrawState(square);
                }
            }
        }

        private void DrawState(MsqSquare a_square)
        {
            int halfHeight = a_square.height / 2;
            int halfWidth = a_square.width / 2;

            switch(a_square.state)
            {
                case 0:
                    // Draw nothing
                break;
                
                case 1:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 2:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topRight.x, a_square.topRight.y + halfHeight,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomRight.y
                    );
                break;

                case 3:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.topRight.x, a_square.topRight.y + halfHeight
                    );
                break;

                case 4:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 5:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight
                    );

                    this.graphics.DrawLine(
                        this.pen,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 6:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 7:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 8:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 9:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 10:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );

                    // Posible bug here...
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.bottomLeft.x  + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 11:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 12:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.topRight.x, a_square.topRight.y + halfHeight
                    );
                break;

                case 13:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 14:
                    this.graphics.DrawLine(
                        this.pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.bottomLeft.x  + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 15:
                    // Draw nothing
                break;
            }
        }
    }
}