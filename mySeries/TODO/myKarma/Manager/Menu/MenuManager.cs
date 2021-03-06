﻿namespace myKarma.Manager.Menu
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
                comboMenu.AddItem(
                    new MenuItem("ComboE", "Use E Mode: ", true).SetValue(new StringList(new[] {"Low Hp", "Gank", "Off"})));
                comboMenu.AddItem(
                        new MenuItem("ComboESwitch", "Switch E Mode Key", true).SetValue(new KeyBind('G',
                            KeyBindType.Press)))
                    .ValueChanged += SwitchEChanged;
                comboMenu.AddItem(
                    new MenuItem("ComboR", "Use R Mode: ", true).SetValue(new StringList(new[] { "All", "Q", "W", "E", "Off" })));
                comboMenu.AddItem(
                        new MenuItem("ComboRSwitch", "Switch R Mode Key", true).SetValue(new KeyBind('H',
                            KeyBindType.Press)))
                    .ValueChanged += SwitchRChanged;
                comboMenu.AddItem(new MenuItem("ComboIgnite", "Use Ignite", true).SetValue(true));
            }

            var harassMenu = Menu.AddSubMenu(new Menu("Harass", "Harass"));
            {
                harassMenu.AddItem(new MenuItem("HarassQ", "Use Q", true).SetValue(true));
                harassMenu.AddItem(new MenuItem("HarassQLH", "Use Q|Last Hit", true).SetValue(true));
                harassMenu.AddItem(new MenuItem("HarassW", "Use W", true).SetValue(false));
                harassMenu.AddItem(
                    new MenuItem("HarassMana", "When Player ManaPercent >= x%", true).SetValue(new Slider(60)));
            }

            var clearMenu = Menu.AddSubMenu(new Menu("Clear", "Clear"));
            {
                var laneClearMenu = clearMenu.AddSubMenu(new Menu("LaneClear", "LaneClear"));
                {
                    laneClearMenu.AddItem(new MenuItem("LaneClearQ", "Use Q", true).SetValue(true));
                    laneClearMenu.AddItem(new MenuItem("LaneClearQLH", "Use Q|Only Last Hit", true).SetValue(true));
                    laneClearMenu.AddItem(new MenuItem("LaneClearW", "Use W", true).SetValue(true));
                    laneClearMenu.AddItem(
                        new MenuItem("LaneClearWCount", "Use W| Hit Count >= x", true).SetValue(new Slider(3, 1, 10)));
                    laneClearMenu.AddItem(
                        new MenuItem("LaneClearMana", "When Player ManaPercent >= x%", true).SetValue(new Slider(60)));
                }

                var jungleClearMenu = clearMenu.AddSubMenu(new Menu("JungleClear", "JungleClear"));
                {
                    jungleClearMenu.AddItem(new MenuItem("JungleClearQ", "Use Q", true).SetValue(true));
                    jungleClearMenu.AddItem(new MenuItem("JungleClearW", "Use W", true).SetValue(true));
                    jungleClearMenu.AddItem(new MenuItem("JungleClearE", "Use E", true).SetValue(true));
                    jungleClearMenu.AddItem(
                        new MenuItem("JungleClearMana", "When Player ManaPercent >= x%", true).SetValue(new Slider(60)));
                }

                clearMenu.AddItem(new MenuItem("asdqweqwe", " ", true));
                ManaManager.AddSpellFarm(clearMenu);
            }

            var killStealMenu = Menu.AddSubMenu(new Menu("KillSteal", "KillSteal"));
            {
                killStealMenu.AddItem(new MenuItem("KillStealQ", "Use Q", true).SetValue(true));
                killStealMenu.AddItem(new MenuItem("KillStealW", "Use W", true).SetValue(true));
            }


            var miscMenu = Menu.AddSubMenu(new Menu("Misc", "Misc"));
            {
                var skinMenu = miscMenu.AddSubMenu(new Menu("SkinChange", "SkinChange"));
                {
                    SkinManager.AddToMenu(skinMenu, 18);
                }

                var autoLevelMenu = miscMenu.AddSubMenu(new Menu("Auto Levels", "Auto Levels"));
                {
                    LevelsManager.AddToMenu(autoLevelMenu);
                }
            }

            Menu.AddItem(new MenuItem("asd ad asd ", " ", true));
            Menu.AddItem(new MenuItem("Credit", "Credit: NightMoon", true));

            Menu.AddToMainMenu();
        }

        private static void SwitchRChanged(object obj, OnValueChangeEventArgs Args)
        {
            if (Args.GetNewValue<KeyBind>().Active)
            {
                switch (Menu.Item("ComboR", true).GetValue<StringList>().SelectedIndex)
                {
                    case 0:
                        Menu.Item("ComboR", true).SetValue(new StringList(new[] { "All", "Q", "W", "E", "Off" }, 1));
                        break;
                    case 1:
                        Menu.Item("ComboR", true).SetValue(new StringList(new[] { "All", "Q", "W", "E", "Off" }, 2));
                        break;
                    case 2:
                        Menu.Item("ComboR", true).SetValue(new StringList(new[] { "All", "Q", "W", "E", "Off" }, 3));
                        break;
                    case 3:
                        Menu.Item("ComboR", true).SetValue(new StringList(new[] { "All", "Q", "W", "E", "Off" }, 4));
                        break;
                    case 4:
                        Menu.Item("ComboR", true).SetValue(new StringList(new[] { "All", "Q", "W", "E", "Off" }));
                        break;
                }
            }
        }

        private static void SwitchEChanged(object obj, OnValueChangeEventArgs Args)
        {
            if (Args.GetNewValue<KeyBind>().Active)
            {
                switch (Menu.Item("ComboE", true).GetValue<StringList>().SelectedIndex)
                {
                    case 0:
                        Menu.Item("ComboE", true).SetValue(new StringList(new[] { "Low Hp", "Gank", "Off" }, 1));
                        break;
                    case 1:
                        Menu.Item("ComboE", true).SetValue(new StringList(new[] { "Low Hp", "Gank", "Off" }, 2));
                        break;
                    case 2:
                        Menu.Item("ComboE", true).SetValue(new StringList(new[] { "Low Hp", "Gank", "Off" }));
                        break;
                }
            }
        }
    }
}
