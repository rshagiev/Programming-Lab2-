using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Lab_2
{
    abstract class GraphElement
    {
        protected Color c;
        protected int w, h, x, y;

        protected Brush brush;
        protected Random r = new Random();

        public int X { get { return x; } set { x = value; } }

        public Point Location { get { return new Point(x, y); } set { x = value.X; y = value.Y; } }

        public bool Selected { get; set; }

        abstract public void ifcontainsPoint(Point p);

        public GraphElement(int x0, int y0)
        {
            Color[] cols = { Color.Red, Color.Green, Color.Yellow, Color.Cyan, Color.Azure, Color.WhiteSmoke };
            c = cols[r.Next(cols.Length)];
            x = x0;
            y = y0;
            w = r.Next(20, 81);
            h = r.Next(20, 81);
            brush = new SolidBrush(c);
        }

        abstract public void draw(Graphics g);
    }
}
