using System.Drawing;
using System.Windows.Forms;

namespace GuylianGilsing.MarchingSquares
{
    class MsqRenderer
    {
        private Graphics graphics = null;
        private Brush brush = new SolidBrush(Color.White);
        private Pen pen = null;

        public void Render(MsqAlgorithm a_algo, PaintEventArgs a_e)
        {
            if(a_algo.squaresToMarch.Count > 0)
            {
                foreach(MsqSquare square in a_algo.squaresToMarch)
                {
                    this.DrawState(square, a_e);
                }
            }
        }

        private void DrawState(MsqSquare a_square, PaintEventArgs a_e)
        {
            int halfHeight = a_square.height / 2;
            int halfWidth = a_square.width / 2;
            
            Pen pen = new Pen(this.brush);
            
            switch(a_square.state)
            {
                case 0:
                    // Draw nothing
                break;
                
                case 1:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 2:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topRight.x, a_square.topRight.y + halfHeight,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomRight.y
                    );
                break;

                case 3:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.topRight.x, a_square.topRight.y + halfHeight
                    );
                break;

                case 4:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 5:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight
                    );

                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 6:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 7:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 8:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 9:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.topLeft.x + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 10:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );

                    // Posible bug here...
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.bottomLeft.x  + halfWidth, a_square.bottomLeft.y
                    );
                break;

                case 11:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x + halfWidth, a_square.topLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 12:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.topLeft.x, a_square.topLeft.y + halfHeight,
                        a_square.topRight.x, a_square.topRight.y + halfHeight
                    );
                break;

                case 13:
                    a_e.Graphics.DrawLine(
                        pen,
                        a_square.bottomLeft.x + halfWidth, a_square.bottomLeft.y,
                        a_square.bottomRight.x, a_square.topLeft.y + halfHeight
                    );
                break;

                case 14:
                    a_e.Graphics.DrawLine(
                        pen,
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