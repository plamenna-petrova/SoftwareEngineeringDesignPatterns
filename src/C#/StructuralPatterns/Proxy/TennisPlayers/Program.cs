using System;

namespace TennisPlayers
{
    public interface ITennisPlayer
    {
        string GetPlayerInfo();

        void SetPlayerInfo(string info);
    }

    public class ATPPlayer : ITennisPlayer
    {
        private string info;

        public string GetPlayerInfo() => info;

        public void SetPlayerInfo(string info)
        {
            this.info = info;
        }
    }

    public class ProxyPlayer : ITennisPlayer
    {
        private ATPPlayer atpPlayer = new ATPPlayer();

        public string GetPlayerInfo() => atpPlayer.GetPlayerInfo();

        public void SetPlayerInfo(string info) => atpPlayer.SetPlayerInfo(info);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ProxyPlayer proxyPlayer = new ProxyPlayer();
            proxyPlayer.SetPlayerInfo("Ranking up with 20 positions");

            Console.WriteLine(proxyPlayer.GetPlayerInfo());
        }
    }
}
