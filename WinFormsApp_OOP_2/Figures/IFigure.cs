using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Ellipse))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Point))]
    [XmlInclude(typeof(Quadrilateral))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Square))]

    public abstract class IFigure
    {
        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }

        public bool IsSelected { get; set; } = false;
        public float PenWidth { get; set; }

        [XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Color OutlineColor { get; set; }

        [XmlElement("OutlineColor")]
        public string OutlineColorString
        {
            get { return OutlineColor.Name; }
            set { OutlineColor = Color.FromName(value); }
        }

        [XmlIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Color FigureColor { get; set; }

        [XmlElement("FigureColor")]
        public string FigureColorString
        {
            get { return FigureColor.Name; }
            set { FigureColor = Color.FromName(value); }
        }

        public abstract void Accept(IVisitor visitor);
    }
} 
