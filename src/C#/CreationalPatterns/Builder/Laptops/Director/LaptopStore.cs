using Laptops.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laptops.Director
{
    public class LaptopStore
    {
        public void BuildLaptopConfiguration(LaptopBuilder laptopBuilder)
        {
            laptopBuilder.SetModel();
            laptopBuilder.SetCPUSeries();
            laptopBuilder.SetGPUModel();
            laptopBuilder.SetRAMType();
            laptopBuilder.SetRAMSize();
            laptopBuilder.SetDisplayType();
            laptopBuilder.SetSSDType();
            laptopBuilder.SetSSDCapacity();
            laptopBuilder.SetExtras();
        }
    }
}
