using Newtonsoft.Json;
using System.Xml.Serialization;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Visitors;
using Point = System.Drawing.Point;

namespace WinFormsLibrary1
{
    public class Triangle : IFigure
    { 
        public Triangle() { }

        public Triangle(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            OutlineColor = Color.Black;
            FigureColor = Color.Transparent;
            PenWidth = 2;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return $"Triangle ({StartPoint}, {EndPoint})";
        }       
    }
}