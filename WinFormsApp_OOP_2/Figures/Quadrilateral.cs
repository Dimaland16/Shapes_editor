using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{

    public class Quadrilateral : IFigure
    {
        public Quadrilateral() { }

        public Quadrilateral(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            OutlineColor = Color.Black;
            FigureColor = Color.Transparent;
            PenWidth = 2;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitQuadrilateral(this);
        }

        public override string ToString()
        {
            return $"Quadrilateral ({StartPoint}, {EndPoint})";
        }
    }
}
