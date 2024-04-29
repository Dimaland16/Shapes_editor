using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{

    public class Square : IFigure
    {
        public Square() { }

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement("FigureColor")]
        public int ColorArgb
        {
            get { return Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }
        public int Size { get; set; }
        public float PenWidth { get; set; }
        public override bool IsSelected { get; set; } = false;




        public Square(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Color = Color.Black;
            Size = Math.Abs(EndPoint.X - StartPoint.X);
            PenWidth = 1;

        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitSquare(this);
        }

        public override string ToString()
        {
            return $"Square ({StartPoint}, {EndPoint})";
        }

        public override string GetFigureType()
        {
            return "Square";
        }
    }

}
