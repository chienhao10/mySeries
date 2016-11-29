namespace myRyze.Manager.Spells
{
    using LeagueSharp;
    using LeagueSharp.Common;

    internal class SpellManager : Logic
    {
        internal static void Init()
        {
            Q = new Spell(SpellSlot.Q, 1000f);
            W = new Spell(SpellSlot.W, 600f);
            E = new Spell(SpellSlot.E, 600f);
            R = new Spell(SpellSlot.R, 1500f);

            Q.SetSkillshot(0.25f, 50f, 1700, true, SkillshotType.SkillshotLine);
            Q.DamageType = W.DamageType = E.DamageType = TargetSelector.DamageType.Magical;

            Ignite = Me.GetSpellSlot("SummonerDot");
        }

        internal static bool HaveShield => Me.HasBuff("ryzeqshield");

        internal static bool NoStack => Me.HasBuff("ryzeqiconnocharge");

        internal static bool HalfStack => Me.HasBuff("ryzeqiconhalfcharge");

        internal static bool FullStack => Me.HasBuff("ryzeqiconfullcharge");
    }
}
