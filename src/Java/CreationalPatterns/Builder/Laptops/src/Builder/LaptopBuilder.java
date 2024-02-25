package Builder;

import Product.Laptop;

public abstract class LaptopBuilder {
    protected Laptop laptop;

    public Laptop getLaptop() {
        return laptop;
    }

    public abstract void setModel();

    public abstract void setCPUSeries();

    public abstract void setGPUModel();

    public abstract void setRAMType();

    public abstract void setRAMSize();

    public abstract void setDisplayType();

    public abstract void setSSDType();

    public abstract void setSSDCapacity();

    public abstract void setExtras();
}
