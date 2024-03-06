using System;

namespace GamingConsoles
{
    public interface IGamingConsole
    {
        void Connect();

        void PowerOn();

        void PowerOff();
    }

    public class Xbox : IGamingConsole
    {
        public void Connect() => Console.WriteLine($"{GetType().Name} connected");

        public void PowerOn() => Console.WriteLine($"{GetType().Name} powered on");

        public void PowerOff() => Console.WriteLine($"{GetType().Name} powered off");
    }

    public class PlayStation : IGamingConsole
    {
        public void Connect() => Console.WriteLine($"{GetType().Name} connected");

        public void PowerOn() => Console.WriteLine($"{GetType().Name} powered on");

        public void PowerOff() => Console.WriteLine($"{GetType().Name} powered off");
    }

    public class Game
    {
        public Game(string name, string studio)
        {
            Name = name;
            Studio = studio;
        }

        public string Name { get; set; }

        public string Studio { get; set; }
    }

    public abstract class GameInstaller
    {
        protected IGamingConsole gamingConsole;

        public GameInstaller(IGamingConsole gamingConsole)
        {
            this.gamingConsole = gamingConsole;
        }

        public void ConnectConsole() => gamingConsole.Connect();

        public void PowerOnConsole() => gamingConsole.PowerOn();

        public void InitInstallation()
        {
            Console.WriteLine($"Initializing game installation for {gamingConsole.GetType().Name} console");
        }

        public abstract void InstallGame(Game game);

        public void PowerOff() => gamingConsole.PowerOff();
    }

    public class XboxGameInstaller : GameInstaller
    {
        public XboxGameInstaller(IGamingConsole gamingConsole) : base(gamingConsole)
        {

        }

        public override void InstallGame(Game game)
        {
            Console.WriteLine($"Installing game {game.Name} by {game.Studio} on {gamingConsole.GetType().Name} console");
        }
    }

    public class PlayStationGameInstaller : GameInstaller
    {
        public PlayStationGameInstaller(IGamingConsole gamingConsole) : base(gamingConsole)
        {

        }

        public override void InstallGame(Game game)
        {
            Console.WriteLine($"Installing game {game.Name} by {game.Studio} on {gamingConsole.GetType().Name} console");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            GameInstaller xboxGameInstaller = new XboxGameInstaller(new Xbox());
            xboxGameInstaller.ConnectConsole();
            xboxGameInstaller.PowerOnConsole();
            xboxGameInstaller.InitInstallation();
            xboxGameInstaller.InstallGame(new Game("Dark Souls III", "From Software"));
            xboxGameInstaller.PowerOff();

            Console.WriteLine();

            GameInstaller playStationGameInstaller = new PlayStationGameInstaller(new PlayStation());
            playStationGameInstaller.ConnectConsole();
            playStationGameInstaller.PowerOnConsole();
            playStationGameInstaller.InitInstallation();
            playStationGameInstaller.InstallGame(new Game("Call Of Duty", "Activision Blizzard"));
            playStationGameInstaller.PowerOff();
        }
    }
}