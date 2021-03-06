﻿namespace myBrand.Manager.Events.Games
{
    using Mode;
    using System;
    using LeagueSharp.Common;
    using Orbwalking = myCommon.Orbwalking;

    internal class LoopManager : Logic
    {
        internal static void Init(EventArgs args)
        {
            if (Me.IsDead || Me.IsRecalling())
            {
                return;
            }

            KillSteal.Init();
            Auto.Init();
 
            switch (Orbwalker.ActiveMode)
            {
                case Orbwalking.OrbwalkingMode.Combo:
                    Combo.Init();
                    break;
                case Orbwalking.OrbwalkingMode.Mixed:
                    Harass.Init();
                    break;
                case Orbwalking.OrbwalkingMode.LaneClear:
                    LaneClear.Init();
                    JungleClear.Init();
                    break;
                case Orbwalking.OrbwalkingMode.LastHit:
                    LastHit.Init();
                    break;
            }
        }
    }
}
