using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApplication.Component;

namespace WindowsFormsApplication.Leaves.Abstraction
{
    public abstract class BaseControlLeaf : Control
    {
        public BaseControlLeaf(string name, int width, int height, Color foreColor, Color backColor)
            : base(name, width, height, foreColor, backColor)
        {

        }

        public override ICollection<Control> Controls { get; set; } = null;

        public override void Add(Control control)
        {
            Console.WriteLine($"Cannot add control to {GetType().Name}");
        }

        public override void Remove(Control control)
        {
            Console.WriteLine($"Cannot remove control from {GetType().Name}");
        }

        public override string GetHierarchicalLevel(int depthIndicator)
        {
           return $"{new string('-', depthIndicator)}+ " +
                $"Name: {Name}, Width: {Width}, Fore Color: ({ForeColor.A}, {ForeColor.G}, {ForeColor.B}), " +
                $"Back Color: ({BackColor.A}, {BackColor.G}, {BackColor.B})\r\n";
        }
    }
}
