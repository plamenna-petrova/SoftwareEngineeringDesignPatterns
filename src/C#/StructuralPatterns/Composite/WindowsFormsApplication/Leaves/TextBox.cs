using System.Drawing;
using WindowsFormsApplication.Leaves.Abstraction;

namespace WindowsFormsApplication.Leaves
{
    public class TextBox : BaseControlLeaf
    {
        public TextBox(string name, int width, int height, Color foreColor, Color backColor)
            : base(name, width, height, foreColor, backColor)
        {

        }
    }
}
