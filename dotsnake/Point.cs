using System;
namespace snake
{
    public struct Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public Point(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }
        public override bool Equals(object obj)
        {
            if (obj is Point)
                return Equals((Point)obj);
            return false;
        }
        public bool Equals(Point p)
        {
            return (X == p.X) && (Y == p.Y);
        }
        public override int GetHashCode()
        {
            return X * 10 + Y;
        }
        public static bool operator ==(Point a, Point b)
        {
                return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        public void Draw()
        {
            DrawPoint(Symbol);
        }
        public void Clear()
        {
            DrawPoint(' ');
        }
        private void DrawPoint(char smbl)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(smbl);
        }

    }
}