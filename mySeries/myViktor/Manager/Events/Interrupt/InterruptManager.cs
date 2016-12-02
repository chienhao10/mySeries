namespace myViktor.Manager.Events
{
    using LeagueSharp;
    using LeagueSharp.Common;
    using myCommon;

    internal class InterruptManager : Logic
    {
        internal static void Init(Obj_AI_Hero sender, Interrupter2.InterruptableTargetEventArgs Args)
        {
            if (Menu.GetBool("IntW") && W.IsReady() && sender.IsEnemy &&
                Args.DangerLevel >= Interrupter2.DangerLevel.High)
            {
                W.Cast(sender.Position, true);
            }
        }
    }
}