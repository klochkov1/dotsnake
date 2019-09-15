using System.Collections.Generic;
namespace snake
{
    public class Walls
    {
        private char smbl;
        private List<Point> wallPoints = new List<Point>();

        public Walls(int x, int y, char smbl)
        {
            this.smbl = smbl;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);
        }
        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = new Point(i, y, smbl);
                p.Draw();
                wallPoints.Add(p);
            }
        }
        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = new Point(x, i, smbl);
                p.Draw();
                wallPoints.Add(p);
            }
        }
        public bool IsHit(Point p) => wallPoints.Contains(p);
    }
}