using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class TextLine
    {
        private List<Point> text;
        public TextLine(string text, int x, int y)
        {
            this.text = new List<Point>();
            int i = x;
            foreach(char c in text)
            {
                this.text.Add(new Point(i,y,c));
                i++;
            }
        }
        public void WriteTextLine()
        {
            foreach (Point p in text)
                p.Draw();
        }
        public void Clear()
        {
            foreach (Point p in text)
                p.Clear();
        }
    }
}
