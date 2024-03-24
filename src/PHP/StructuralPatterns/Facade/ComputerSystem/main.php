<?php

interface IComputerFacade {
    public function start();
}

class CPU {
    public function freeze(): string
    {
        return "CPU is freezing";
    }

    public function jump($address): string
    {
        return "CPU is jumping to $address";
    }

    public function execute(): string
    {
        return "CPU is executing commands";
    }
}

class Memory {
    public function load($address, $data): string
    {
        return "Memory is loading data at $address with data $data";
    }
}

class HardDrive {
    public function read($lba, $size): string
    {
        return "HardDrive is reading data at LBA $lba with size $size";
    }
}

class GPU {
    public function render($graphics): string
    {
        return "GPU is rendering graphics: $graphics";
    }
}

class ComputerFacade implements IComputerFacade {
    private CPU $cpu;
    private Memory $memory;
    private HardDrive $hardDrive;
    private GPU $gpu;

    public function __construct() {
        $this->cpu = new CPU();
        $this->memory = new Memory();
        $this->hardDrive = new HardDrive();
        $this->gpu = new GPU();
    }

    public function start(): void
    {
        echo $this->cpu->freeze() . "\n";
        echo $this->memory->load("0x0", "BOOT SECTOR") . "\n";
        echo $this->cpu->jump("0x0") . "\n";
        echo $this->cpu->execute() . "\n";
        echo $this->hardDrive->read("BOOT_SECTOR", "BOOT_SECTOR_SIZE") . "\n";
        echo $this->gpu->render("BOOT_SCREEN") . "\n";
    }
}

$computerFacade = new ComputerFacade();
$computerFacade->start();