
class CPU {
    freeze() {
        return "CPU is freezing";
    }

    jump(address) {
        return `CPU is jumping to ${address}`;
    }

    execute() {
        return "CPU is executing commands";
    }
}

class Memory {
    load(address, data) {
        return `Memory is loading data at ${address} with data ${data}`;
    }
}

class HardDrive {
    read(lba, size) {
        return `HardDrive is reading data at LBA ${lba} with size ${size}`;
    }
}

class GPU {
    render(graphics) {
        return `GPU is rendering graphics: ${graphics}`;
    }
}

class ComputerFacade {
    constructor() {
        this.cpu = new CPU();
        this.memory = new Memory();
        this.hardDrive = new HardDrive();
        this.gpu = new GPU();
    }

    start() {
        console.log(this.cpu.freeze());
        console.log(this.memory.load("0x0", "BOOT SECTOR"));
        console.log(this.cpu.jump("0x0"));
        console.log(this.cpu.execute());
        console.log(this.hardDrive.read("BOOT_SECTOR", "BOOT_SECTOR_SIZE"));
        console.log(this.gpu.render("BOOT_SCREEN"));
    }
}

const computerFacade = new ComputerFacade();
computerFacade.start();