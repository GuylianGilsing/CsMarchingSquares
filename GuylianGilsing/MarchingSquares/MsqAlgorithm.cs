using System;
using System.Collections.Generic;

namespace GuylianGilsing.MarchingSquares
{
    class MsqAlgorithm
    {
        public int canvasWidth = 0;
        public int canvasHeight = 0;
        public int pointInterval = 0;

        public List<MsqSquare> squaresToMarch {get; private set;} = new List<MsqSquare>();

        public MsqAlgorithm(int a_canvasWidth, int a_canvasHeight, int a_pointerInterval)
        {
            this.canvasWidth = a_canvasWidth;
            this.canvasHeight = a_canvasHeight;

            this.pointInterval = a_pointerInterval;
        }

        public void SetPoints(List<MsqPoint> a_points, int a_padX = 0, int a_padY = 0)
        {
            // Make sure that a list with actual points in it is given
            if(a_points.Count > 0)
            {
                List<MsqSquare> squares = new List<MsqSquare>();

                int maxCellsX = (this.canvasWidth / this.pointInterval) + a_padX;
                int maxCellsY = (this.canvasHeight / this.pointInterval) + a_padY;

                // Find all the points and form a square with them
                for(int y = 0; y < maxCellsY; y += 1)
                {
                    for(int x = 0; x < maxCellsX; x += 1)
                    {
                        if((y + 1) < maxCellsY && (x + 1) < maxCellsX)
                        {
                            // Retrieve all of the points of the square out of a 2d list
                            int topLeftIndex = x + (y * maxCellsX);
                            int topRightIndex = (x + 1) + (y * maxCellsX);
                            int bottomLeftIndex = x + ((y + 1) * maxCellsX);
                            int bottomRightIndex = (x + 1) + ((y + 1) * maxCellsX);

                            // Retrieve the points
                            MsqPoint topLeft = a_points[topLeftIndex];
                            MsqPoint topRight = a_points[topRightIndex];
                            MsqPoint bottomLeft = a_points[bottomLeftIndex];
                            MsqPoint bottomRight = a_points[bottomRightIndex];

                            // Create and add the square
                            MsqSquare square = new MsqSquare(topLeft, topRight, bottomLeft, bottomRight);
                            squares.Add(square);
                        }
                    }
                }

                this.squaresToMarch = squares;
            }
        }

        public void RunOnce()
        {
            foreach(MsqSquare square in this.squaresToMarch)
            {
                square.state = this.GetIsoLineState(square);
            }
        }

        /// <summary>
        /// Checks the state acording to the
        /// <a href="https://en.wikipedia.org/wiki/Marching_squares#/media/File:Marching_squares_algorithm.svg">pre-defined ISO lines</a>
        /// .
        /// </summary>
        private byte GetIsoLineState(MsqSquare a_square)
        {
            byte state = 0;
            
            if(a_square.topLeft.color == 0 &&
               a_square.topRight.color == 0 &&
               a_square.bottomLeft.color == 0 &&
               a_square.bottomRight.color == 0
            )
            {
                state = 0;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 255 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 1;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 255
            )
            {
                state = 2;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 255 &&
                    a_square.bottomRight.color == 255
            )
            {
                state = 3;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 255 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 4;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 255 &&
                    a_square.bottomLeft.color == 255 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 5;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 255 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 255
            )
            {
                state = 6;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 255 &&
                    a_square.bottomLeft.color == 255 &&
                    a_square.bottomRight.color == 255
            )
            {
                state = 7;
            }
            else if(a_square.topLeft.color == 255 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 8;
            }
            else if(a_square.topLeft.color == 255 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 255 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 9;
            }
            else if(a_square.topLeft.color == 255 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 255
            )
            {
                state = 10;
            }
            else if(a_square.topLeft.color == 255 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 255 &&
                    a_square.bottomRight.color == 255
            )
            {
                state = 11;
            }
            else if(a_square.topLeft.color == 255 &&
                    a_square.topRight.color == 255 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 12;
            }
            else if(a_square.topLeft.color == 255 &&
                    a_square.topRight.color == 255 &&
                    a_square.bottomLeft.color == 255 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 13;
            }
            else if(a_square.topLeft.color == 255 &&
                    a_square.topRight.color == 255 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 255
            )
            {
                state = 14;
            }
            else if(a_square.topLeft.color == 0 &&
                    a_square.topRight.color == 0 &&
                    a_square.bottomLeft.color == 0 &&
                    a_square.bottomRight.color == 0
            )
            {
                state = 15;
            }

            return state;
        }
    }
}