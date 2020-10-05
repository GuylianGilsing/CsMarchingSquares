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

        public void SetPoints(List<MsqPoint> a_points)
        {
            // Make sure that a list with actual points in it is given
            if(a_points.Count > 0)
            {
                List<MsqSquare> squares = new List<MsqSquare>();

                int maxCellsY = (this.canvasHeight / this.pointInterval);
                int maxCellsX = (this.canvasWidth / this.pointInterval);

                // Find all the points and form a square with them
                for(int y = 0; y < maxCellsY; y += 1)
                {
                    for(int x = 0; x < maxCellsX; x += 1)
                    {
                        if((y + 1) <= maxCellsY && (x + 1) <= maxCellsX)
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
    }
}