using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Rectangle : GraphElement
    {
        public Rectangle(int x0, int y0) : base(x0, y0) { }

        public override void ifcontainsPoint(Point p)
        {
            if (p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h) Selected = true;
            else Selected = false;
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            if (Selected == true) g.DrawRectangle(Pens.Gold, x, y, w, h);
            else g.DrawRectangle(Pens.Black, x, y, w, h);
        }
    }
}
