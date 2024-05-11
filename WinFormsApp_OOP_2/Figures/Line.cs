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

        public Line(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            OutlineColor = Color.Black;
            PenWidth = 2;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLine(this);
        }

        public override string ToString()
        {
            return $"Line ({StartPoint}, {EndPoint})";
        }
    }
}
