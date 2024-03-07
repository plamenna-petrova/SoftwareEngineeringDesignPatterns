using System.Drawing;
using WindowsFormsApplication.Leaves.Abstraction;

namespace WindowsFormsApplication.Leaves
{
    public class Button : BaseControlLeaf
    {
        public Button(string name, int width, int height, Color foreColor, Color backColor) 
            : base(name, width, height, foreColor, backColor)
        {

        }
    }
}
