using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Component
{
    public abstract class Control
    {
        public Control(string name, int width, int height, Color foreColor, Color backColor)
        {
            Name = name;
            Width = width;
            Height = height;
            ForeColor = foreColor;
            BackColor = backColor;
        }

        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Color ForeColor { get; set; }

        public Color BackColor { get; set; }

        public abstract ICollection<Control> Controls { get; set; }

        public abstract void Add(Control control);

        public abstract void Remove(Control control);

        public abstract string GetHierarchicalLevel(int depthIndicator);
    }
}
