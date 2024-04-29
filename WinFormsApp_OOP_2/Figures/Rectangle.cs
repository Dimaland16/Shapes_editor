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

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement("FigureColor")]
        public int ColorArgb
        {
            get { return Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }
        public float PenWidth { get; set; }
        public override bool IsSelected { get; set; } = false;

        public Rectangle(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Color = Color.Black;
            Width = Math.Abs(EndPoint.X - StartPoint.X);
            Height = Math.Abs(EndPoint.Y - StartPoint.Y);
            PenWidth = 1;

        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitRectangle(this);
        }

        public override string ToString()
        {
            return $"Rectangle ({StartPoint}, {EndPoint})";
        }

        public override string GetFigureType()
        {
            return "Rectangle";
        }
    }
}
