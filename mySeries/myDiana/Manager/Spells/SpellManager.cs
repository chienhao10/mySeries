namespace myDiana.Manager.Spells
{
    using LeagueSharp;
    using LeagueSharp.Common;

    internal class SpellManager : Logic
    {
        internal static void Init()
        {
            Q = new Spell(SpellSlot.Q, 900f);
            W = new Spell(SpellSlot.W, 250f);
            E = new Spell(SpellSlot.E, 450f);
            R = new Spell(SpellSlot.R, 825f);

            Q.SetSkillshot(0.25f, 150f, 1400f, false, SkillshotType.SkillshotCircle);

            Ignite = Me.GetSpellSlot("SummonerDot");
            Flash = Me.GetSpellSlot("SummonerFlash");
        }

        internal static bool HaveQPassive(Obj_AI_Base target)
        {
            return target.HasBuff("dianamoonlight");
        }
    }
}
