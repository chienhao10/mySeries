namespace myViktor.Manager.Events
{
    using myCommon;
    using LeagueSharp.Common;
    using Orbwalking = myCommon.Orbwalking;

    internal class BeforeAttackManager : Logic
    {
        internal static void Init(Orbwalking.BeforeAttackEventArgs Args)
        {
            if (Menu.GetBool("DisableAA"))
            {
                if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
                {
                    if (Menu.GetBool("DisableAAALL"))
                    {
                        Args.Process = Me.HasBuff("ViktorPowerTransferReturn") || Me.Mana < Q.Instance.ManaCost;
                    }
                    else if (Me.Level >= Menu.GetSlider("DisableAALevel"))
                    {
                        Args.Process = Me.HasBuff("ViktorPowerTransferReturn") || Me.Mana < Q.Instance.ManaCost;
                    }
                    else
                    {
                        Args.Process = true;
                    }
                }
            }
            else
            {
                Args.Process = true;
            }
        }
    }
}