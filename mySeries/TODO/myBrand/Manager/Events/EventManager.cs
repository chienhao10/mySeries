namespace myBrand.Manager.Events
{
    using Games;
    using Drawings;
    using LeagueSharp;
    using LeagueSharp.Common;
    using Orbwalking = myCommon.Orbwalking;

    internal class EventManager
    {
        internal static void Init()
        {
            Game.OnUpdate += LoopManager.Init;
            Orbwalking.BeforeAttack += BeforeAttackManager.Init;
            Drawing.OnDraw += DrawManager.Init;
        }
    }
}
