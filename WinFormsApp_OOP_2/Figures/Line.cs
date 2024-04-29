using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{

    public class Line : IFigure
    {
        public Line() { }

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }
        public override bool IsSelected { get; set; } = false;
        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement("FigureColor")]
        public int ColorArgb
        {
            get { return Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }
        public float PenWidth { get; set; }


        public Line(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Color = Color.Black;
            PenWidth = 1;

        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLine(this);
        }

        public override string ToString()
        {
            return $"Line ({StartPoint}, {EndPoint})";
        }

        public override string GetFigureType()
        {
            return "Line";
        }

    }
}
