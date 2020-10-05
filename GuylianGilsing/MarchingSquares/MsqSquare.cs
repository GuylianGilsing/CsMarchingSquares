namespace GuylianGilsing.MarchingSquares
{
    class MsqSquare
    {
        public byte state = 0;
        public MsqPoint topLeft = null;
        public MsqPoint topRight = null;
        public MsqPoint bottomLeft = null;
        public MsqPoint bottomRight = null;

        public int width = 0;
        public int height = 0;

        public MsqSquare(MsqPoint a_topLeft, MsqPoint a_topRight, MsqPoint a_bottomLeft, MsqPoint a_bottomRight, byte a_state = 0)
        {
            this.topLeft = a_topLeft;
            this.topRight = a_topRight;
            this.bottomLeft = a_bottomLeft;
            this.bottomRight = a_bottomRight;

            this.state = a_state;

            this.width = this.topLeft.x - this.bottomRight.x;
            this.height = this.bottomRight.y - this.topLeft.y;
        }

        public void Update()
        {
            this.width = topLeft.x - topRight.x;
            this.height = bottomLeft.y - topLeft.y;

            this.state = this.GetIsoLineState();
        }

        /// <summary>
        /// Checks the state acording to the
        /// <a href="https://en.wikipedia.org/wiki/Marching_squares#/media/File:Marching_squares_algorithm.svg">pre-defined ISO lines</a>
        /// .
        /// </summary>
        private byte GetIsoLineState()
        {
            byte state = 0;
            
            if(this.topLeft.color == 0 &&
               this.topRight.color == 0 &&
               this.bottomLeft.color == 0 &&
               this.bottomRight.color == 0
            )
            {
                state = 0;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 255 &&
                    this.bottomRight.color == 0
            )
            {
                state = 1;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 255
            )
            {
                state = 2;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 255 &&
                    this.bottomRight.color == 255
            )
            {
                state = 3;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 255 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 0
            )
            {
                state = 4;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 255 &&
                    this.bottomLeft.color == 255 &&
                    this.bottomRight.color == 0
            )
            {
                state = 5;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 255 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 255
            )
            {
                state = 6;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 255 &&
                    this.bottomLeft.color == 255 &&
                    this.bottomRight.color == 255
            )
            {
                state = 7;
            }
            else if(this.topLeft.color == 255 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 0
            )
            {
                state = 8;
            }
            else if(this.topLeft.color == 255 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 255 &&
                    this.bottomRight.color == 0
            )
            {
                state = 9;
            }
            else if(this.topLeft.color == 255 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 255
            )
            {
                state = 10;
            }
            else if(this.topLeft.color == 255 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 255 &&
                    this.bottomRight.color == 255
            )
            {
                state = 11;
            }
            else if(this.topLeft.color == 255 &&
                    this.topRight.color == 255 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 0
            )
            {
                state = 12;
            }
            else if(this.topLeft.color == 255 &&
                    this.topRight.color == 255 &&
                    this.bottomLeft.color == 255 &&
                    this.bottomRight.color == 0
            )
            {
                state = 13;
            }
            else if(this.topLeft.color == 255 &&
                    this.topRight.color == 255 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 255
            )
            {
                state = 14;
            }
            else if(this.topLeft.color == 0 &&
                    this.topRight.color == 0 &&
                    this.bottomLeft.color == 0 &&
                    this.bottomRight.color == 0
            )
            {
                state = 15;
            }

            return state;
        }
    }
}