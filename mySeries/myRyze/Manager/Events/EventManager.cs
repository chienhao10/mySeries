namespace myRyze.Manager.Events
{
    using Games;
    using Drawings;
    using LeagueSharp;
    using Orbwalking = myCommon.Orbwalking;

    internal class EventManager
    {
        internal static void Init()
        {
            Game.OnUpdate += LoopManager.Init;
            Spellbook.OnCastSpell += CastSpellManager.Init;
            Orbwalking.BeforeAttack += BeforeAttackManager.Init;
            Drawing.OnDraw += DrawManager.Init;
            Drawing.OnEndScene += DrawManager.InitMinMap;
        }
    }
}
