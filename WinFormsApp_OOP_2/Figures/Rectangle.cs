using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{


    public class Rectangle : IFigure
    {
        public Rectangle() { }

        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Width = Math.Abs(EndPoint.X - StartPoint.X);
            Height = Math.Abs(EndPoint.Y - StartPoint.Y);
            OutlineColor = Color.Black;
            FigureColor = Color.Transparent;
            PenWidth = 2;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitRectangle(this);
        }

        public override string ToString()
        {
            return $"Rectangle ({StartPoint}, {EndPoint})";
        }
    }
}
