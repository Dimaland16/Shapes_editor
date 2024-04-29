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

        public float PenWidth { get; set; }
        public override bool IsSelected { get; set; } = false;

        public Ellipse() { }
        

        public Ellipse(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            OutlineColor = Color.Black;
            FigureColor = Color.White;
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
