﻿namespace myBrand
{
    using Manager.Events;
    using Manager.Menu;
    using Manager.Spells;
    using LeagueSharp;
    using LeagueSharp.Common;
    using Orbwalking = myCommon.Orbwalking;

    internal class Logic
    {
        internal static Spell Q;
        internal static Spell W;
        internal static Spell E;
        internal static Spell R;
        internal static SpellSlot Ignite = SpellSlot.Unknown;
        internal static Menu Menu;
        internal static Obj_AI_Hero Me;
        internal static Orbwalking.Orbwalker Orbwalker;

        internal static void LoadAssembly()
        {
            Me = ObjectManager.Player;

            SpellManager.Init();
            MenuManager.Init();
            EventManager.Init();
        }
    }
}