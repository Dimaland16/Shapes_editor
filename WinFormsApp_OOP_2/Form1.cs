using System.Drawing;
using System.Windows.Forms;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Drawers;
using WinFormsApp_OOP_2.Visitors;
using Point = WinFormsApp_OOP_1.GraphicsFigures.Figures.Point;

namespace WinFormsApp_OOP_2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private List<IFigure> figuresList = new List<IFigure>();
        private Pen pen;
        private Brush penColor;
        private Brush shapeColor;

        private System.Drawing.Point startPoint;
        private System.Drawing.Point endPoint;

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox.Items.Add(new ComboboxItem() { Text = "Circle", Value = new CircleFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Ellipse", Value = new EllipseFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Line", Value = new LineFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Point", Value = new PointFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Quadrilateral", Value = new QuadrilateralFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Rectangle", Value = new RectangleFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Square", Value = new SquareFactory() });
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;

                IFactory? facroty = (listBox.SelectedItem as ComboboxItem)?.Value as IFactory;
                IFigure figure = facroty.Create(startPoint, endPoint);
                figuresList.Add(figure);

                pictureBox1.Invalidate();

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            IVisitor visitor = new GraphicsVisitor(e.Graphics);
            foreach (IFigure figure in figuresList)
            {
                figure.Accept(visitor);
            }
        }
    }
}
