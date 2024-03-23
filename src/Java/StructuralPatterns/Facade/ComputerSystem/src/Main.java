class CPU {
    public String freeze() {
        return "CPU is freezing";
    }

    public String jump(String address) {
        return "CPU is jumping to " + address;
    }

    public String execute() {
        return "CPU is executing commands";
    }
}

class Memory {
    public String load(String address, String data) {
        return "Memory is loading data at " + address + " with data " + data;
    }
}

class HardDrive {
    public String read(String lba, String size) {
        return "HardDrive is reading data at LBA " + lba + " with size " + size;
    }
}

class GPU {
    public String render(String graphics) {
        return "GPU is rendering graphics: " + graphics;
    }
}

interface IComputerFacade {
    void start();
}

class ComputerFacade implements IComputerFacade {
    private CPU cpu;
    private Memory memory;
    private HardDrive hardDrive;
    private GPU gpu;

    public ComputerFacade() {
        cpu = new CPU();
        memory = new Memory();
        hardDrive = new HardDrive();
        gpu = new GPU();
    }

    public void start() {
        System.out.println(cpu.freeze());
        System.out.println(memory.load("0x0", "BOOT SECTOR"));
        System.out.println(cpu.jump("0x0"));
        System.out.println(cpu.execute());
        System.out.println(hardDrive.read("BOOT_SECTOR", "BOOT_SECTOR_SIZE"));
        System.out.println(gpu.render("BOOT_SCREEN"));
    }
}

public class Main {
    public static void main(String[] args) {
        IComputerFacade computerFacade = new ComputerFacade();
        computerFacade.start();
    }
}