package Product;

import java.util.ArrayList;
import java.util.List;

public class Laptop {
    private String model;
    private String cpuSeries;
    private String gpuModel;
    private String ramType;
    private int ramSize;
    private String displayType;
    private String ssdType;
    private int ssdCapacity;
    private List<String> extras = new ArrayList<>();

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public String getCPUSeries() {
        return cpuSeries;
    }

    public void setCPUSeries(String cpuSeries) {
        this.cpuSeries = cpuSeries;
    }

    public String getGPUModel() {
        return gpuModel;
    }

    public void setGPUModel(String gpuModel) {
        this.gpuModel = gpuModel;
    }

    public String getRAMType() {
        return ramType;
    }

    public void setRAMType(String ramType) {
        this.ramType = ramType;
    }

    public int getRAMSize() {
        return ramSize;
    }

    public void setRAMSize(int ramSize) {
        this.ramSize = ramSize;
    }

    public String getDisplayType() {
        return displayType;
    }

    public void setDisplayType(String displayType) {
        this.displayType = displayType;
    }

    public String getSSDType() {
        return ssdType;
    }

    public void setSSDType(String ssdType) {
        this.ssdType = ssdType;
    }

    public int getSSDCapacity() {
        return ssdCapacity;
    }

    public void setSSDCapacity(int ssdCapacity) {
        this.ssdCapacity = ssdCapacity;
    }

    public List<String> getExtras() {
        return extras;
    }

    public void setExtras(List<String> extras) {
        this.extras = extras;
    }

    public void showDetails() {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append("-".repeat(40)).append("\n");
        stringBuilder.append("Model: ").append(model).append("\n");
        stringBuilder.append("CPU Model: ").append(cpuSeries).append("\n");
        stringBuilder.append("GPU Model: ").append(gpuModel).append("\n");
        stringBuilder.append("RAM Type: ").append(ramType).append("\n");
        stringBuilder.append("RAM Size: ").append(ramSize).append(" GB").append("\n");
        stringBuilder.append("Display Type: ").append(displayType).append("\n");
        stringBuilder.append("SSD Type: ").append(ssdType).append("\n");
        stringBuilder.append("SSD Capacity: ").append(ssdCapacity).append(" GB").append("\n");
        stringBuilder.append("Extras: \n");

        for (int i = 0; i < extras.size(); i++) {
            stringBuilder.append("Extra #").append(i + 1).append(": ").append(extras.get(i)).append("\n");
        }

        stringBuilder.append("-".repeat(40)).append("\n");
        System.out.println(stringBuilder.toString());
    }
}

