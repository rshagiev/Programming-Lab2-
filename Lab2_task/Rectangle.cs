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

        public override bool ifcontainsPoint(Point p)
        {
            if (p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h) return true;
            else return false;
            
        }
        Pen d = new Pen(Color.Red, 5);
        public override void draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            if (select == true) g.DrawRectangle(d, x, y, w, h);
            else g.DrawRectangle(Pens.Black, x, y, w, h);
        }
    }
}
