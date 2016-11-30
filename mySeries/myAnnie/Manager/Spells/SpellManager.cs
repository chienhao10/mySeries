namespace myAnnie.Manager.Spells
{
    using LeagueSharp;
    using LeagueSharp.Common;

    internal class SpellManager : Logic
    {
        internal static void Init()
        {
            Q = new Spell(SpellSlot.Q);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R);

            Ignite = Me.GetSpellSlot("SummonerDot");
            Flash = Me.GetSpellSlot("SummonerFlash");
        }

        internal static bool HaveBear => Me.HasBuff("InfernalGuardianTimer");

        internal static bool HaveStun => Me.HasBuff("Energized");

        internal static int BuffCounts
        {
            get
            {
                var count = 0;
                if (Me.HasBuff("Pyromania"))
                {
                    count = Me.GetBuffCount("Pyromania");
                }
                else if (!Me.HasBuff("Pyromania") || HaveStun)
                {
                    count = 0;
                }
                return count;
            }
        }
    }
}
