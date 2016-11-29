namespace myDiana.Manager.Events.Games
{
    using myCommon;
    using LeagueSharp;
    using LeagueSharp.Common;
    using Orbwalking = myCommon.Orbwalking;

    internal class EFlash : Logic
    {
        internal static void Init()
        {
            Orbwalking.MoveTo(Game.CursorPos);

            if (Flash != SpellSlot.Unknown && Flash.IsReady() && E.IsReady())
            {
                Obj_AI_Hero target = null;

                target = TargetSelector.GetSelectedTarget() ??
                         TargetSelector.GetTarget(700f, TargetSelector.DamageType.Magical);

                if (target.Check(700f) && target.DistanceToPlayer() > E.Range)
                {
                    var pos = Me.Position.Extend(target.Position, 425f);

                    if (target.Position.Distance(pos) < 350f && target.DistanceToPlayer() > E.Range)
                    {
                        E.Cast();
                        Utility.DelayAction.Add(100 + Game.Ping * 2, () =>
                        {
                            Me.Spellbook.CastSpell(Flash, target.Position);
                        });
                    }
                }
            }
        }
    }
}