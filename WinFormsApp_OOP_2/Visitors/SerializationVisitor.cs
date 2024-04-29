using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Point = WinFormsApp_OOP_1.GraphicsFigures.Figures.Point;


namespace WinFormsApp_OOP_2.Visitors
{
    internal class SerializationVisitor : IVisitor
    {
        public SerializationVisitor()
        {
        }

        public void VisitCircle(Circle circle)
        {
            MessageBox.Show(JsonSerializer.Serialize(circle));
        }

        public void VisitQuadrilateral(Quadrilateral quadrilateral)
        {

        }

        public void VisitRectangle(WinFormsApp_OOP_1.GraphicsFigures.Figures.Rectangle rectangle)
        {

        }

        public void VisitSquare(Square square)
        {

        }

        public void VisitEllipse(Ellipse ellipse)
        {

        }

        public void VisitLine(Line line)
        {
        }

        public void VisitPoint(Point point)
        {

        }
    }
}
