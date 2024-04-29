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
        [Newtonsoft.Json.JsonIgnore]
        public Color OutlineColor { get; set; }

        [XmlElement("OutlineColor")]
        public string OutlineColorString
        {
            get { return OutlineColor.Name; }
            set { OutlineColor = Color.FromName(value); }
        }

        [XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Color FigureColor { get; set; }

        [XmlElement("FigureColor")]
        public string FigureColorArgb
        {
            get { return FigureColor.Name; }
            set { FigureColor = Color.FromName(value); }
        }

        public int Size { get; set; }
        public float PenWidth { get; set; }
        public override bool IsSelected { get; set; } = false;

        public Square(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Size = Math.Abs(EndPoint.X - StartPoint.X);
            OutlineColor = Color.Black;
            FigureColor = Color.White;
            PenWidth = 2;

        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitSquare(this);
        }

        public override string ToString()
        {
            return $"Square ({StartPoint}, {EndPoint})";
        }
    }

}
