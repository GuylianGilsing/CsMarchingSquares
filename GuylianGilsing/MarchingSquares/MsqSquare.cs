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
            this.Update();
        }

        public void Update()
        {
            this.width =  topRight.x - topLeft.x;
            this.height = bottomLeft.y - topLeft.y;
        }
    }
}