namespace myBrand.Manager.Spells
{
    using myCommon;
    using System.Linq;
    using System.Collections.Generic;
    using LeagueSharp;
    using LeagueSharp.Common;
    using SharpDX;

    internal class SpellManager : Logic
    {
        internal static void Init()
        {
            Q = new Spell(SpellSlot.Q, 1175f);
            W = new Spell(SpellSlot.W, 1075f);
            E = new Spell(SpellSlot.E, 1075f);
            R = new Spell(SpellSlot.R, 3340f);

            Ignite = Me.GetSpellSlot("SummonerDot");
        }
    }
}
