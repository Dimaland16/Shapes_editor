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
        public new System.Drawing.Point StartPoint { get; set; }
        public new System.Drawing.Point EndPoint { get; set; }

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

        public Ellipse() { }
        

        public Ellipse(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Color = Color.Black;
            PenWidth = 1;


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

        public override string GetFigureType()
        {
            return "Ellipse";
        }
    }
}
