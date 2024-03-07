
class IGamingConsole {
    connect() {
        throw new Error('Method not implemented');
    }

    powerOn() {
        throw new Error('Method not implemented');
    }

    powerOff() {
        throw new Error('Method not implemented');
    }
}

class Xbox extends IGamingConsole {
    connect() {
        console.log(`${this.constructor.name} connected`);
    }

    powerOn() {
        console.log(`${this.constructor.name} powered on`);
    }

    powerOff() {
        console.log(`${this.constructor.name} powered off`);
    }
}

class PlayStation extends IGamingConsole {
    connect() {
        console.log(`${this.constructor.name} connected`);
    }

    powerOn() {
        console.log(`${this.constructor.name} powered on`);
    }

    powerOff() {
        console.log(`${this.constructor.name} powered off`);
    }
}

class Game {
    constructor(name, studio) {
        this.name = name;
        this.studio = studio;
    }
}

class GameInstaller {
    constructor(gamingConsole) {
        this.gamingConsole = gamingConsole;
    }

    connectConsole() {
        this.gamingConsole.connect();
    }

    powerOnConsole() {
        this.gamingConsole.powerOn();
    }

    initInstallation() {
        console.log(`Initializing game installation for ${this.gamingConsole.constructor.name} console`);
    }

    installGame(game) {
        console.log(`Installing game ${game.name} by ${game.studio} on ${this.gamingConsole.constructor.name} console`);
    }

    powerOff() {
        this.gamingConsole.powerOff();
    }
}

class XboxGameInstaller extends GameInstaller {
    constructor(gamingConsole) {
        super(gamingConsole);
    }

    installGame(game) {
        console.log(`Installing game ${game.name} by ${game.studio} on ${this.gamingConsole.constructor.name} console`);
    }
}

class PlayStationGameInstaller extends GameInstaller {
    constructor(gamingConsole) {
        super(gamingConsole);
    }

    installGame(game) {
        console.log(`Installing game ${game.name} by ${game.studio} on ${this.gamingConsole.constructor.name} console`);
    }
}

let xboxGameInstaller = new XboxGameInstaller(new Xbox());
xboxGameInstaller.connectConsole();
xboxGameInstaller.powerOnConsole();
xboxGameInstaller.initInstallation();
xboxGameInstaller.installGame(new Game("Dark Souls III", "From Software"));
xboxGameInstaller.powerOff();

console.log();

let playStationGameInstaller = new PlayStationGameInstaller(new PlayStation());
playStationGameInstaller.connectConsole();
playStationGameInstaller.powerOnConsole();
playStationGameInstaller.initInstallation();
playStationGameInstaller.installGame(new Game("Call Of Duty", "Activision Blizzard"));
playStationGameInstaller.powerOff();