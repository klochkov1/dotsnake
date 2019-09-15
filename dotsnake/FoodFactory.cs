using System;

namespace snake
{
    class FoodFactory
    {
        int x;
        int y;
        char smbl;
        public static Point Food { get; private set; }

        Random random = new Random();

        public FoodFactory(int x, int y, char smbl)
        {
            this.x = x;
            this.y = y;
            this.smbl = smbl;
        }

        public void CreateFood()
        {
            Food = new Point(random.Next(2, x - 2), random.Next(2, y - 2), smbl);
            Food.Draw();
        }

        public static bool IsEaten(Point p) => Food.Equals(p);
    }
}