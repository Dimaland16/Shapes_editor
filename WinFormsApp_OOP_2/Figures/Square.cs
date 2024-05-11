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

        public int Size { get; set; }

        public Square(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Size = Math.Abs(EndPoint.X - StartPoint.X);
            OutlineColor = Color.Black;
            FigureColor = Color.Transparent;
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
