namespace myAnnie
{
    using System;
    using LeagueSharp;
    using LeagueSharp.Common;

    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            if (ObjectManager.Player.ChampionName != "Annie")
            {
                return;
            }

            Logic.LoadAssembly();

            Game.PrintChat("my Series: " + ObjectManager.Player.ChampionName + " Load! Credit By NightMoon!");
        }
    }
}
