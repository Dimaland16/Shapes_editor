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
        public int Radius { get; set; }

        public Circle() { }

        public Circle(System.Drawing.Point startPoint, System.Drawing.Point endPoint) 
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Radius = Math.Abs(StartPoint.X - EndPoint.X) / 2;
            OutlineColor = Color.Black;
            FigureColor = Color.Transparent;
            PenWidth = 2;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCircle(this);
        }

        public override string ToString()
        {
            return $"Circle ({StartPoint}, {EndPoint})";
        }

    }
}
