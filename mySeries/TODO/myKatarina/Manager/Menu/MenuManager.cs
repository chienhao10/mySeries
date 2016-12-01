namespace myKatarina.Manager.Menu
{
    using myCommon;
    using LeagueSharp.Common;
    using Orbwalking = myCommon.Orbwalking;

    internal class MenuManager : Logic
    {
        internal static void Init()
        {
            Menu = new Menu("mySeries: " + Me.ChampionName, "mySeries: " + Me.ChampionName, true);

            var targetSelectMenu = Menu.AddSubMenu(new Menu("Target Selector", "Target Selector"));
            {
                TargetSelector.AddToMenu(targetSelectMenu);
            }

            var orbMenu = Menu.AddSubMenu(new Menu("Orbwalking", "Orbwalking"));
            {
                Orbwalker = new Orbwalking.Orbwalker(orbMenu);
            }

            var comboMenu = Menu.AddSubMenu(new Menu("Combo", "Combo"));
            {
                comboMenu.AddItem(new MenuItem("ComboQ", "Use Q", true).SetValue(true));
                comboMenu.AddItem(new MenuItem("ComboW", "Use W", true).SetValue(true));
                comboMenu.AddItem(new MenuItem("ComboE", "Use E", true).SetValue(true));
                comboMenu.AddItem(new MenuItem("ComboR", "Use R", true).SetValue(true));
            }

            var miscMenu = Menu.AddSubMenu(new Menu("Misc", "Misc"));
            {
                var skinMenu = miscMenu.AddSubMenu(new Menu("SkinChange", "SkinChange"));
                {
                    SkinManager.AddToMenu(skinMenu, 9);
                }

                var autoLevelMenu = miscMenu.AddSubMenu(new Menu("Auto Levels", "Auto Levels"));
                {
                    LevelsManager.AddToMenu(autoLevelMenu);
                }
            }

            var drawMenu = Menu.AddSubMenu(new Menu("Drawings", "Drawings"));
            {
                drawMenu.AddItem(new MenuItem("DrawQ", "Draw Q Range", true).SetValue(false));
                drawMenu.AddItem(new MenuItem("DrawE", "Draw E Range", true).SetValue(false));
                drawMenu.AddItem(new MenuItem("DrawR", "Draw R Range", true).SetValue(false));
                ManaManager.AddDrawFarm(drawMenu);
                DamageIndicator.AddToMenu(drawMenu, DamageCalculate.GetComboDamage);
            }

            Menu.AddItem(new MenuItem("asd ad asd ", " ", true));
            Menu.AddItem(new MenuItem("Credit", "Credit: NightMoon", true));

            Menu.AddToMainMenu();
        }
    }
}
