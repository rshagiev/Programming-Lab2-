using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Ellipse : GraphElement
    {
        public Ellipse(int x0, int y0) : base(x0, y0) { }
        Pen p = new Pen(Color.Gold, 5);
        public override void draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            if (select == true) g.DrawEllipse(p, x, y, w, h);
            else g.DrawEllipse(Pens.Black, x, y, w, h);
        }

        public override bool ifcontainsPoint(Point p)
        {
            //if ((float)(p.X - x - w/2) * (float)(p.X - x - w/2) / (float)w * (float)w + (float)(p.Y - y - h/2) * (float)(p.Y - y - h/2) / (float)h * (float)h <= 1) Selected = true;
            if (p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h) return true;
            else return false;
        }
    }
}
