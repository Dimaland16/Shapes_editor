using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Drawers;
using Point = System.Drawing.Point;

namespace WinFormsLibrary1
{
    public class TriangleFactory : IFactory
    {
        public IFigure Create(Point startPoint, Point endPoint)
        {
            return new Triangle(startPoint, endPoint);
        }
    }
}
