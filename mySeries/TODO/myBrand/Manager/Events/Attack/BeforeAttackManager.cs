namespace myBrand.Manager.Events
{
    using myCommon;
    using LeagueSharp;
    using Orbwalking = myCommon.Orbwalking;

    internal class BeforeAttackManager : Logic
    {
        internal static void Init(Orbwalking.BeforeAttackEventArgs Args)
        {
            if (Menu.GetBool("SupportMode"))
            {
                if (Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Mixed)
                {
                    if (Args.Target.Type == GameObjectType.obj_AI_Minion)
                    {
                        Args.Process = false;
                    }
                }
            }
        }
    }
}