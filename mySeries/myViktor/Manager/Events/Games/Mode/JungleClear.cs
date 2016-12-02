namespace myViktor.Manager.Events.Games.Mode
{
    using Spells;
    using myCommon;
    using System.Linq;
    using LeagueSharp.Common;

    internal class JungleClear : Logic
    {
        internal static void Init()
        {
            if (ManaManager.HasEnoughMana(Menu.GetSlider("JungleClearMana")) && ManaManager.SpellFarm)
            {
                if (Menu.GetBool("JungleClearQ") && Q.IsReady())
                {
                    var qMob =
                        MinionManager.GetMinions(Me.Position, Q.Range, MinionTypes.All, MinionTeam.Neutral,
                            MinionOrderTypes.MaxHealth).FirstOrDefault();

                    if (qMob != null && qMob.IsValidTarget(Q.Range))
                    {
                        Q.CastOnUnit(qMob, true);
                        Orbwalker.ForceTarget(qMob);
                    }
                }

                if (Menu.GetBool("JungleClearE") && E.IsReady())
                {
                    var eMobs = MinionManager.GetMinions(Me.Position, E.Range + EWidth, MinionTypes.All, MinionTeam.Neutral,
                        MinionOrderTypes.MaxHealth);

                    if (eMobs.Any())
                    {
                        var eMinion = eMobs.FirstOrDefault(x => x.IsValidTarget(E.Range + E.Width));

                        if (eMinion != null)
                        {
                            var exEMinions = MinionManager.GetMinions(eMinion.Position, E.Range);
                            var eFarm =
                                SpellManager.GetBestLineFarmLocation(
                                    exEMinions.Select(x => x.Position.To2D()).ToList(), eMinion.Position, E.Width, EWidth);

                            if (eFarm.MinionsHit >= 1)
                            {
                                E.Cast(eMinion.Position, eFarm.Position.To3D());
                            }
                        }
                    }
                }
            }
        }
    }
}
