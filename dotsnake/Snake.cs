using System;
using System.Collections.Generic;

namespace snake
{
    class Snake
    {
        public string bodyStr;
        public int counter = 0;
        private List<Point> body;
        private Direction direction;
        private int step = 1;
        private Point Tail => body[0];
        public Point Head { get => body[body.Count - 1]; set { body[body.Count - 1] = value; } }
        bool rotate = true;
        public Snake(int x, int y, int length, string bodyStr)
        {
            direction = Direction.RIGHT;
            body = new List<Point>();
            this.bodyStr = ' ' + bodyStr;
            for (int i = x - length; i < x; i++)
            {
                Point p = new Point(x, y, NextSymbol);
                body.Add(p);
                p.Draw();
            }
        }
        public char NextSymbol => bodyStr[counter++];
        public void Move()
        {
            body.Add(GetNextPoint());
            if (!FoodFactory.IsEaten(Head))
            {
                body.RemoveAt(0);
                for (int i = body.Count - 2; i > 0; i--)
                {
                    Point p = body[i];
                    body[i] = new Point(p.X, p.Y, body[i - 1].Symbol);
                    body[i].Draw();
                }
            }
            else
            {
                Point p = Head;
                Head = new Point(p.X, p.Y, NextSymbol);
            }
            Tail.Clear();
            Head.Draw();

            rotate = true;
        }
        public Point GetNextPoint()
        {
            Point p = Head;
            switch (direction)
            {
                case Direction.RIGHT:
                    p.X += step;
                    break;
                case Direction.LEFT:
                    p.X -= step;
                    break;
                case Direction.DOWN:
                    p.Y += step;
                    break;
                case Direction.UP:
                    p.Y -= step;
                    break;
            }
            return p;
        }
        public void Rotation(ConsoleKey key)
        {
            if (rotate)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                    case Direction.RIGHT:
                        if (key == ConsoleKey.DownArrow)
                            direction = Direction.DOWN;
                        else if (key == ConsoleKey.UpArrow)
                            direction = Direction.UP;
                        break;
                    case Direction.DOWN:
                    case Direction.UP:
                        if (key == ConsoleKey.RightArrow)
                            direction = Direction.RIGHT;
                        else if (key == ConsoleKey.LeftArrow)
                            direction = Direction.LEFT;
                        break;
                }
                rotate = false;
            }
        }
        public bool IsHitItself => body.IndexOf(Head) != body.Count - 1 && body.Count != 4;

        public void Dispose()
        {
            foreach(var p in body)
            {
                p.Clear();
            }
        }
    }
}