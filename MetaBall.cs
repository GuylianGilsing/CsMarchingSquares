namespace CsMarchingSquares
{
    class MetaBall
    {
        public int x = 0;
        public int y = 0;
        public int radius = 0;
        public int speedX = 2;
        public int speedY = 2;

        public MetaBall(int a_x, int a_y, int a_radius, int a_speedX, int a_speedY)
        {
            this.x = a_x;
            this.y = a_y;
            
            this.speedX = a_speedX;
            this.speedY = a_speedY;

            this.radius = a_radius;
        }
    }
}