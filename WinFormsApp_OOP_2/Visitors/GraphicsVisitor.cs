using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Point = WinFormsApp_OOP_1.GraphicsFigures.Figures.Point;

namespace WinFormsApp_OOP_2.Visitors
{
    public class GraphicsVisitor : IVisitor
    {
        private Graphics graphics;

        private static readonly Dictionary<Type, Action<Graphics, object>> drawMethods = new Dictionary<Type, Action<Graphics, object>>();


        public GraphicsVisitor(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void RegisterDrawMethod(Type shapeType, Action<Graphics, object> drawMethod)
        {
            drawMethods[shapeType] = drawMethod;
        }

        public void Visit(dynamic shape)
        {
            var shapeType = shape.GetType();
            if (drawMethods.ContainsKey(shapeType))
            {
                drawMethods[shapeType].Invoke(graphics, shape);
            }
            else
            {
                throw new NotSupportedException($"Draw method for {shapeType.Name} is not registered.");
            }
        }

        public void VisitCircle(Circle circle)
        {
            int centerX = (circle.StartPoint.X + circle.EndPoint.X) / 2;
            int centerY = (circle.StartPoint.Y + circle.EndPoint.Y) / 2;

            int x = centerX - circle.Radius;
            int y = centerY - circle.Radius;
            int diameter = circle.Radius * 2;

            using (var brush = new SolidBrush(circle.FigureColor))
            {
                graphics.FillEllipse(brush, x, y, diameter, diameter);
            }

            using var pen = new Pen(circle.IsSelected ? Color.Red : circle.OutlineColor, circle.PenWidth);
            graphics.DrawEllipse(pen, x, y, diameter, diameter);

        }

        public void VisitQuadrilateral(Quadrilateral quadrilateral)
        {
            int x1 = quadrilateral.StartPoint.X;
            int y1 = quadrilateral.StartPoint.Y;
            int x2 = quadrilateral.EndPoint.X;
            int y2 = quadrilateral.EndPoint.Y;

            System.Drawing.Point[] vertices =
            [
                new System.Drawing.Point(x1, y1),
                new System.Drawing.Point(x2, y1),
                new System.Drawing.Point(x1, y2),
                new System.Drawing.Point(x2, y2)
            ];

            using (var brush = new SolidBrush(quadrilateral.FigureColor))
            {
                graphics.FillPolygon(brush, vertices);
            }

            using var pen = new Pen(quadrilateral.IsSelected ? Color.Red : quadrilateral.OutlineColor, quadrilateral.PenWidth);
            graphics.DrawPolygon(pen, vertices);
        }

        public void VisitRectangle(WinFormsApp_OOP_1.GraphicsFigures.Figures.Rectangle rectangle)
        {

            System.Drawing.Rectangle _rectangle = new System.Drawing.Rectangle(rectangle.StartPoint.X, rectangle.StartPoint.Y, rectangle.Width, rectangle.Height);

            using (var brush = new SolidBrush(rectangle.FigureColor))
            {
                graphics.FillRectangle(brush, _rectangle);
            }

            using var pen = new Pen(rectangle.IsSelected ? Color.Red : rectangle.OutlineColor, rectangle.PenWidth);

            graphics.DrawRectangle(pen, _rectangle);
        }

        public void VisitSquare(Square square)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(square.StartPoint.X, square.StartPoint.Y, square.Size, square.Size);

            using (var brush = new SolidBrush(square.FigureColor))
            {
                graphics.FillRectangle(brush, rectangle);
            }

            using var pen = new Pen(square.IsSelected ? Color.Red : square.OutlineColor, square.PenWidth);

            graphics.DrawRectangle(pen, rectangle);
        }

        public void VisitEllipse(Ellipse ellipse)
        {
            int centerX = (ellipse.StartPoint.X + ellipse.EndPoint.X) / 2;
            int centerY = (ellipse.StartPoint.Y + ellipse.EndPoint.Y) / 2;

            int x = centerX - Math.Abs(ellipse.StartPoint.X - ellipse.EndPoint.X) / 2;
            int y = centerY - Math.Abs(ellipse.StartPoint.Y - ellipse.EndPoint.Y) / 2;

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(x, y, ellipse.Width, ellipse.Height);

            using (var brush = new SolidBrush(ellipse.FigureColor))
            {
                graphics.FillEllipse(brush, rectangle);
            }

            using var pen = new Pen(ellipse.IsSelected ? Color.Red : ellipse.OutlineColor, ellipse.PenWidth);

            graphics.DrawEllipse(pen, rectangle);
        }

        public void VisitLine(Line line)
        {
            using var pen = new Pen(line.IsSelected ? Color.Red : line.OutlineColor, line.PenWidth);

            graphics.DrawLine(pen, line.StartPoint, line.EndPoint);
        }

        public void VisitPoint(Point point)
        {
            using var pen = new Pen(point.IsSelected ? Color.Red : point.OutlineColor, point.PenWidth);

            graphics.DrawRectangle(pen, point.StartPoint.X, point.StartPoint.Y, 1, 1);
        }
    }
}
