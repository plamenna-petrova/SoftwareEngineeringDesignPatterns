using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApplication.Component;

namespace WindowsFormsApplication.Composites.Abstraction
{
    public abstract class BaseControlComposite : Control
    {
        public BaseControlComposite(string name, int width, int height, Color foreColor, Color backColor)
           : base(name, width, height, foreColor, backColor)
        {

        }

        public override ICollection<Control> Controls { get; set; } = new HashSet<Control>();

        public override void Add(Control control)
        {
            Controls.Add(control);
        }

        public override void Remove(Control control)
        {
            Controls.Remove(control);
        }

        public override string GetHierarchicalLevel(int depthIndicator)
        {
            string groupBoxHierarchicalInfo = $"{new string('-', depthIndicator)}+ " +
                $"Name: {Name}, Width: {Width}, Fore Color: ({ForeColor.A}, {ForeColor.G}, {ForeColor.B}), " +
                $"Back Color: ({BackColor.A}, {BackColor.G}, {BackColor.B})\r\n";

            foreach (var control in Controls)
            {
                groupBoxHierarchicalInfo += control.GetHierarchicalLevel(depthIndicator + 2);
            }

            return groupBoxHierarchicalInfo;
        }
    }
}
