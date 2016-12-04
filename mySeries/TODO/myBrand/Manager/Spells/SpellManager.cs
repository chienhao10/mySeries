namespace myBrand.Manager.Spells
{
    using LeagueSharp;
    using LeagueSharp.Common;

    internal class SpellManager : Logic
    {
        internal static void Init()
        {
            Q = new Spell(SpellSlot.Q, 1050, TargetSelector.DamageType.Magical);
            W = new Spell(SpellSlot.W, 900, TargetSelector.DamageType.Magical);
            E = new Spell(SpellSlot.E, 625, TargetSelector.DamageType.Magical);
            R = new Spell(SpellSlot.R, 750, TargetSelector.DamageType.Magical);

            Q.SetSkillshot(0.25f, 50f, 1600f, true, SkillshotType.SkillshotLine);
            W.SetSkillshot(1.15f, 230f, float.MaxValue, false, SkillshotType.SkillshotCircle);
            R.SetTargetted(0.25f, 2000f);

            Ignite = Me.GetSpellSlot("SummonerDot");
        }
    }
}
