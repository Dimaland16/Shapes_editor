namespace WinFormsLibrary1
{
    public static class TriangleDrawMethod
    {
        public static void Draw(Graphics graphics, object shape)
        {
            var triangle = (Triangle)shape;

            Point point1 = triangle.StartPoint;
            Point point2 = new Point(triangle.EndPoint.X, triangle.StartPoint.Y);
            Point point3 = new Point((triangle.StartPoint.X + triangle.EndPoint.X) / 2, triangle.EndPoint.Y);

            Point[] points = { point1, point2, point3 };

            using (var brush = new SolidBrush(triangle.FigureColor))
            {
                graphics.FillPolygon(brush, points);
            }

            using var pen = new Pen(triangle.IsSelected ? Color.Red : triangle.OutlineColor, triangle.PenWidth);
            graphics.DrawPolygon(pen, points);
        }
    }
}