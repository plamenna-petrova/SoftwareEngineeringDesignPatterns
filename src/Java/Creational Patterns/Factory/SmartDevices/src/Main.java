import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

abstract class SmartDevice {
    public abstract void setPrice(float price);
    public abstract float getPrice();
    public abstract void setCharacteristics(List<String> characteristics);
    public abstract List<String> getCharacteristics();

    @Override
    public String toString() {
        return String.format("%s's Details:\nPrice: %.2f\nCharacteristics: %s",
                getClass().getSimpleName(), getPrice(), String.join(", ", getCharacteristics()));
    }
}

class SamsungGalaxyS23Ultra extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public SamsungGalaxyS23Ultra() {
        this.price = (float) 1970.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class XiaomiRedmiNote12Pro extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public XiaomiRedmiNote12Pro() {
        this.price = (float) 630.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class IPhone12ProMax extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public IPhone12ProMax() {
        this.price = (float) 1470.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class GalaxyWatchClassic extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public GalaxyWatchClassic() {
        this.price = (float) 760.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class XiaomiWatch2Pro extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public XiaomiWatch2Pro() {
        this.price = (float) 620.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() { return price; }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class AppleWatchUltra2 extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public AppleWatchUltra2() {
        this.price = (float) 830.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class GalaxyBuds2Pro extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public GalaxyBuds2Pro() {
        this.price = (float) 470.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class RedmiAirdotsBasic2 extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public RedmiAirdotsBasic2() {
        this.price = (float) 267.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

class AirPods extends SmartDevice {
    private float price;
    private List<String> characteristics;

    public AirPods() {
        this.price = (float) 950.00;
    }

    @Override
    public void setPrice(float price) {
        this.price = price;
    }

    @Override
    public float getPrice() {
        return price;
    }

    @Override
    public void setCharacteristics(List<String> characteristics) {
        this.characteristics = characteristics;
    }

    @Override
    public List<String> getCharacteristics() {
        return characteristics;
    }
}

enum SmartDeviceBrand {
    Samsung,
    Xiaomi,
    Apple
}

interface ISmartDeviceCreator {
    SmartDevice createSmartDevice(SmartDeviceBrand smartDeviceBrand);
}

class SmartPhoneConcreteCreator implements ISmartDeviceCreator {
    @Override
    public SmartDevice createSmartDevice(SmartDeviceBrand smartDeviceBrand) {
        switch (smartDeviceBrand) {
            case Samsung:
                return new SamsungGalaxyS23Ultra();
            case Xiaomi:
                return new XiaomiRedmiNote12Pro();
            case Apple:
                return new IPhone12ProMax();
            default:
                throw new IllegalArgumentException("Invalid smart device brand");
        }
    }
}

class SmartWatchConcreteCreator implements ISmartDeviceCreator {
    @Override
    public SmartDevice createSmartDevice(SmartDeviceBrand smartDeviceBrand) {
        switch (smartDeviceBrand) {
            case Samsung:
                return new GalaxyWatchClassic();
            case Xiaomi:
                return new XiaomiWatch2Pro();
            case Apple:
                return new AppleWatchUltra2();
            default:
                throw new IllegalArgumentException("Invalid smart device brand");
        }
    }
}

class EarbudsConcreteCreator implements ISmartDeviceCreator {
    @Override
    public SmartDevice createSmartDevice(SmartDeviceBrand smartDeviceBrand) {
        switch (smartDeviceBrand) {
            case Samsung:
                return new GalaxyBuds2Pro();
            case Xiaomi:
                return new RedmiAirdotsBasic2();
            case Apple:
                return new AirPods();
            default:
                throw new IllegalArgumentException("Invalid smart device brand");
        }
    }
}

class Program {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<ISmartDeviceCreator> smartDeviceCreators = List.of(
                new SmartPhoneConcreteCreator(),
                new SmartWatchConcreteCreator(),
                new EarbudsConcreteCreator()
        );

        System.out.print("Enter Smart Device Type - Smart Phone, Smart Watch, or Earbuds: ");
        String smartDeviceType = scanner.nextLine();

        while (!smartDeviceType.equalsIgnoreCase("END")) {
            String initialSmartDeviceTypeInput = String.join("", smartDeviceType.split("\\s+"));

            ISmartDeviceCreator smartDeviceCreator = smartDeviceCreators.stream()
                    .filter(sdc -> sdc.getClass().getSimpleName().startsWith(initialSmartDeviceTypeInput))
                    .findFirst()
                    .orElse(null);

            while (smartDeviceCreator == null) {
                System.out.print("Enter valid smart device type: ");
                smartDeviceType = scanner.nextLine();

                String currentSmartDeviceTypeInput = String.join("", smartDeviceType.split("\\s+"));

                smartDeviceCreator = smartDeviceCreators.stream()
                        .filter(sdc -> sdc.getClass().getSimpleName().startsWith(currentSmartDeviceTypeInput))
                        .findFirst()
                        .orElse(null);
            }

            System.out.print("Enter Smart Device Brand - Samsung, Xiaomi, or Apple: ");
            String smartDeviceBrandInput = scanner.nextLine();

            SmartDeviceBrand smartDeviceBrand;

            try {
                smartDeviceBrand = SmartDeviceBrand.valueOf(smartDeviceBrandInput);
            } catch (IllegalArgumentException illegalArgumentException) {
                System.out.print("Enter valid smart device brand: ");
                smartDeviceBrandInput = scanner.nextLine();
                smartDeviceBrand = SmartDeviceBrand.valueOf(smartDeviceBrandInput);
            }

            SmartDevice smartDevice = smartDeviceCreator.createSmartDevice(smartDeviceBrand);

            System.out.printf("Enter device characteristics for %s separated by '|':%n",
                    smartDevice.getClass().getSimpleName());

            List<String> smartDeviceCharacteristics = Arrays.stream(scanner.nextLine().split("\\|"))
                    .map(String::trim)
                    .collect(Collectors.toList());

            smartDevice.setCharacteristics(smartDeviceCharacteristics);

            System.out.println(smartDevice);
            System.out.println("=".repeat(80));

            System.out.print("Enter Smart Device Type - Smart Phone, Smart Watch, or Earbuds: ");
            smartDeviceType = scanner.nextLine();
        }
    }
}