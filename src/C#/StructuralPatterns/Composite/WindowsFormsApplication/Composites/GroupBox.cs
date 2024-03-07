using System.Drawing;
using WindowsFormsApplication.Composites.Abstraction;

namespace WindowsFormsApplication.Composites
{
    public class GroupBox : BaseControlComposite
    {
        public GroupBox(string name, int width, int height, Color foreColor, Color backColor) 
            : base(name, width, height, foreColor, backColor)
        {

        }
    }
}
