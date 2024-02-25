using EraStyles.Abstraction;
using EraStyles.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Products
{
    public class VictorianClothing : EraObject
    {
        public override void ShowDetails()
        {
            Console.WriteLine(string.Format(GlobalConstants.ClothingMessage, "Victorian Era"));
        }
    }
}
