using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{

    public class Ellipse : IFigure
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Ellipse() { }
        
        public Ellipse(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            OutlineColor = Color.Black;
            FigureColor = Color.Transparent;
            PenWidth = 2;
            Width = Math.Abs(StartPoint.X - EndPoint.X);
            Height = Math.Abs(StartPoint.Y - EndPoint.Y);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitEllipse(this);
        }

        public override string ToString()
        {
            return $"Ellipse ({StartPoint}, {EndPoint})";
        }
    }
}
