using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_2.Visitors;


namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{

    public class Circle : IFigure
    {

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }
        public int Radius { get; set; }

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


        [Browsable(false)]
        //[field: JsonSerializable(Circle)]
        public new int Width { get; set; }
        [Browsable(false)]
        public new int Height { get; set; }

        public Circle() { }

        public Circle(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Radius = Math.Abs(StartPoint.X - EndPoint.X) / 2;
            Color = Color.Black;
            PenWidth = 1;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCircle(this);
        }

        public override string ToString()
        {
            return $"Circle ({StartPoint}, {EndPoint})";
        }

        public override string GetFigureType()
        {
            return "Circle";
        }

    }
}
