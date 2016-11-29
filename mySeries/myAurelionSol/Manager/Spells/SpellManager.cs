namespace myAurelionSol.Manager.Spells
{
    using LeagueSharp;
    using LeagueSharp.Common;

    internal class SpellManager : Logic
    {
        internal static void Init()
        {
            Q = new Spell(SpellSlot.Q, 700f);
            W = new Spell(SpellSlot.W, 675f);
            E = new Spell(SpellSlot.E, 400f);
            R = new Spell(SpellSlot.R, 1550f);

            Q.SetSkillshot(0.40f, 180, 800, false, SkillshotType.SkillshotCircle);
            R.SetSkillshot(0.25f, 180, 1750, false, SkillshotType.SkillshotLine);
        }

        internal static bool IsWActive => Me.HasBuff("AurelionSolWActive");

        internal static bool HavePassive => Me.HasBuff("AurelionSolPassive");

        internal static bool SecondQ => Me.HasBuff("AurelionSolQHaste");
    }
}
