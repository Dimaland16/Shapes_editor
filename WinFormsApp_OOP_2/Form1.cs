using Newtonsoft.Json;
using System.Xml.Serialization;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Drawers;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private List<IFigure> figuresList = new List<IFigure>();

        XmlSerializer serializer;


        IFigure selectedShape;

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
                listBox1.Items.Add(figure);

                listBox1.SelectedItem = figure;

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

        private void button1_Click(object sender, EventArgs e)
        {
            selectedShape.IsSelected = false;
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented

            };

            var json = JsonConvert.SerializeObject(figuresList, settings);
            File.WriteAllText("C:\\Users\\Dimaland\\Documents\\1\\figures.json", json);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText("C:\\Users\\Dimaland\\Documents\\1\\figures.json");

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented

            };

            figuresList = JsonConvert.DeserializeObject<List<IFigure>>(json, settings);

            foreach (IFigure figure in figuresList)
            {
                listBox1.Items.Add(figure);
            }

            pictureBox1.Invalidate();
        }

        private void propertyGrid1_SelectedObjectsChanged(object sender, EventArgs e)
        {
            if (selectedShape != null)
            {
                selectedShape.IsSelected = false;
            }

            selectedShape = propertyGrid1.SelectedObject as IFigure;

            if (selectedShape != null)
            {
                selectedShape.IsSelected = true;
            }

            pictureBox1.Invalidate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = listBox1.SelectedItem;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBox1.SelectedItem is IFigure selected)
                {
                    figuresList.Remove(selected);
                    listBox1.Items.Remove(selected);

                    pictureBox1.Invalidate();
                }

            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.Name == "Color")
            {
                selectedShape.IsSelected = false;
            }

            pictureBox1.Invalidate();

        }

        // �����, �������������� ��������� ��� ������������
        [XmlRoot("Figures")]
        public class FigureContainer
        {
            [XmlElement("Figure")]
            public List<IFigure>? FiguresList { get; set; }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            selectedShape.IsSelected = false;

            FigureContainer container = new FigureContainer { FiguresList = figuresList };

            // ����������� � ��������� � XML ����
            serializer = new XmlSerializer(typeof(FigureContainer));
            using (TextWriter writer = new StreamWriter("C:\\Users\\Dimaland\\Documents\\1\\figures.xml"))
            {
                serializer.Serialize(writer, container);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ������������� �� XML �����
            serializer = new XmlSerializer(typeof(FigureContainer));

            FigureContainer deserializedContainer;
            using (TextReader reader = new StreamReader("C:\\Users\\Dimaland\\Documents\\1\\figures.xml"))
            {
                deserializedContainer = (FigureContainer)serializer.Deserialize(reader);
            }

            figuresList = deserializedContainer.FiguresList;

            foreach (IFigure figure in figuresList)
            {
                listBox1.Items.Add(figure);
            }

            pictureBox1.Invalidate();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            figuresList.Clear();
            listBox1.Items.Clear();
            propertyGrid1.SelectedObject = null;
            pictureBox1.Invalidate();

        }
    }
}
