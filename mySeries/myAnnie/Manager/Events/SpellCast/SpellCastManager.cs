﻿namespace myAnnie.Manager.Events
{
    using myCommon;
    using LeagueSharp;
    using LeagueSharp.Common;
    using Orbwalking = myCommon.Orbwalking;

    internal class SpellCastManager : Logic
    {
        internal static void Init(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs Args)
        {
            if (sender == null || !sender.IsEnemy || Args.SData.IsAutoAttack() || !Args.Target.IsMe)
            {
                return;
            }

            if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo && Menu.GetBool("ComboE") && E.IsReady() &&
                sender is Obj_AI_Hero)
            {
                E.Cast();
            }

            if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.LaneClear &&
                ManaManager.HasEnoughMana(Menu.GetSlider("JungleClearMana")) && ManaManager.SpellFarm &&
                Menu.GetBool("JungleClearE") && E.IsReady() && sender is Obj_AI_Minion &&
                MinionManager.GetMinions(Me.Position, 650f, MinionTypes.All, MinionTeam.Neutral,
                    MinionOrderTypes.MaxHealth).Contains(sender) && Me.HealthPercent <= 70)
            {
                E.Cast();
            }
        }
    }
}