using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Visitors;
using Point = System.Drawing.Point;

namespace WinFormsApp_OOP_2.Figures
{
    public class Triangle : IFigure
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public Color OutlineColor { get; set; }

        [XmlElement("OutlineColor")]
        public string OutlineColorString
        {
            get { return OutlineColor.Name; }
            set { OutlineColor = Color.FromName(value); }
        }

        [XmlIgnore]
        [JsonIgnore]
        public Color FigureColor { get; set; }

        [XmlElement("FigureColor")]
        public string FigureColorString
        {
            get { return FigureColor.Name; }
            set { FigureColor = Color.FromName(value); }
        }

        public float PenWidth { get; set; }
        public override bool IsSelected { get; set; } = false;

        public Triangle() { }

        public Triangle(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            OutlineColor = Color.Black;
            FigureColor = Color.White;
            PenWidth = 2;
        }

        public override void Accept(IVisitor visitor)
        {
            //visitor.VisitTriangle(this);
        }

        public override string ToString()
        {
            return $"Triangle ({StartPoint}, {EndPoint})";
        }
    }
}
