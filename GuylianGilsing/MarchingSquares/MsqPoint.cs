namespace GuylianGilsing.MarchingSquares
{
    class MsqPoint
    {
        public int x = 0;
        public int y = 0;

        public byte color = 0;

        public MsqPoint(int a_x, int a_y, byte a_color)
        {
            this.x = a_x;
            this.y = a_y;

            this.color = a_color;
        }
    }
}