interface IGamingConsole {
    void connect();

    void powerOn();

    void powerOff();
}

class Xbox implements IGamingConsole {
    @Override
    public void connect() {
        System.out.println(getClass().getSimpleName() + " connected");
    }

    @Override
    public void powerOn() {
        System.out.println(getClass().getSimpleName() + " powered on");
    }

    @Override
    public void powerOff() {
        System.out.println(getClass().getSimpleName() + " powered off");
    }
}

class PlayStation implements IGamingConsole {
    @Override
    public void connect() {
        System.out.println(getClass().getSimpleName() + " connected");
    }

    @Override
    public void powerOn() {
        System.out.println(getClass().getSimpleName() + " powered on");
    }

    @Override
    public void powerOff() {
        System.out.println(getClass().getSimpleName() + " powered off");
    }
}

class Game {
    private String name;
    private String studio;

    public Game(String name, String studio) {
        this.name = name;
        this.studio = studio;
    }

    public String getName() {
        return name;
    }

    public String getStudio() {
        return studio;
    }
}

abstract class GameInstaller {
    protected IGamingConsole gamingConsole;

    public GameInstaller(IGamingConsole gamingConsole) {
        this.gamingConsole = gamingConsole;
    }

    public void connectConsole() {
        gamingConsole.connect();
    }

    public void powerOnConsole() {
        gamingConsole.powerOn();
    }

    public void initInstallation() {
        System.out.println("Initializing game installation for " + gamingConsole.getClass().getSimpleName() + " console");
    }

    public abstract void installGame(Game game);

    public void powerOff() {
        gamingConsole.powerOff();
    }
}

class XboxGameInstaller extends GameInstaller {
    public XboxGameInstaller(IGamingConsole gamingConsole) {
        super(gamingConsole);
    }

    @Override
    public void installGame(Game game) {
        System.out.println("Installing game " + game.getName() + " by " + game.getStudio() +
                " on " + gamingConsole.getClass().getSimpleName() + " console");
    }
}

class PlayStationGameInstaller extends GameInstaller {
    public PlayStationGameInstaller(IGamingConsole gamingConsole) {
        super(gamingConsole);
    }

    @Override
    public void installGame(Game game) {
        System.out.println("Installing game " + game.getName() + " by " + game.getStudio() +
                " on " + gamingConsole.getClass().getSimpleName() + " console");
    }
}

public class Main {
    public static void main(String[] args) {
        GameInstaller xboxGameInstaller = new XboxGameInstaller(new Xbox());
        xboxGameInstaller.connectConsole();
        xboxGameInstaller.powerOnConsole();
        xboxGameInstaller.initInstallation();
        xboxGameInstaller.installGame(new Game("Dark Souls III", "From Software"));
        xboxGameInstaller.powerOff();

        System.out.println();

        GameInstaller playStationGameInstaller = new PlayStationGameInstaller(new PlayStation());
        playStationGameInstaller.connectConsole();
        playStationGameInstaller.powerOnConsole();
        playStationGameInstaller.initInstallation();
        playStationGameInstaller.installGame(new Game("Call Of Duty", "Activision Blizzard"));
        playStationGameInstaller.powerOff();
    }
}