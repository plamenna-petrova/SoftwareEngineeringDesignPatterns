using Laptops.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laptops.Builder
{
    public abstract class LaptopBuilder
    {
        public Laptop Laptop { get; set; }

        public abstract void SetModel();

        public abstract void SetCPUSeries();

        public abstract void SetGPUModel();

        public abstract void SetRAMType();

        public abstract void SetRAMSize();

        public abstract void SetDisplayType();

        public abstract void SetSSDType();

        public abstract void SetSSDCapacity();

        public abstract void SetExtras();
    }
}
