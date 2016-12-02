namespace myCommon
{
    using LeagueSharp;
    using LeagueSharp.Common;

    public static class DamageCalculate
    {
        public static float GetComboDamage(Obj_AI_Base target)
        {
            if (target == null || target.IsDead || target.IsZombie)
            {
                return 0;
            }

            var damage = 0d;

            damage += GetQDamage(target);
            damage += GetWDamage(target);
            damage += GetEDamage(target);
            damage += GetRDamage(target);

            if (ObjectManager.Player.HasBuff("SummonerExhaust"))
            {
                damage = damage * 0.6f;
            }

            if (target.CharData.BaseSkinName == "Moredkaiser")
            {
                damage -= target.Mana;
            }

            if (target.HasBuff("GarenW"))
            {
                damage = damage * 0.7f;
            }

            if (target.HasBuff("ferocioushowl"))
            {
                damage = damage * 0.7f;
            }

            if (target.HasBuff("BlitzcrankManaBarrierCD") && target.HasBuff("ManaBarrier"))
            {
                damage -= target.Mana / 2f;
            }

            return (float)damage;
        }

        public static float GetQDamage(Obj_AI_Base target, int stage = 0, bool newDamageLogic = false,
            float newDamage = 0f)
        {
            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level == 0 ||
                !ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).IsReady())
            {
                return 0f;
            }

            if (newDamageLogic)
            {
                return newDamage;
            }

            return (float)ObjectManager.Player.GetSpellDamage(target, SpellSlot.Q) + (float)GetQAttackDamage(target);
        }

        private static double GetQAttackDamage(Obj_AI_Base target)
        {
            double[] AttackDamage = { 20, 25, 30, 35, 40, 45, 50, 55, 60, 70, 80, 90, 110, 130, 150, 170, 190, 210 };

            var damage = 0d;

            if (Items.HasItem(3057) && Items.CanUseItem(3057)) //Sheen
            {
                damage += ObjectManager.Player.TotalAttackDamage + ObjectManager.Player.BaseAttackDamage;
            }

            if (Items.HasItem(3025) && Items.CanUseItem(3025)) //Iceborn Gauntlet
            {
                damage += ObjectManager.Player.TotalAttackDamage + ObjectManager.Player.BaseAttackDamage;
            }

            if (Items.HasItem(3100) && Items.CanUseItem(3100)) //Lich Bane
            {
                damage += ObjectManager.Player.TotalAttackDamage + 0.75*ObjectManager.Player.BaseAttackDamage +
                          0.5*ObjectManager.Player.FlatMagicDamageMod;
            }

            if (Items.HasItem(3078) && Items.CanUseItem(3078)) //Trinity Force
            {
                damage += ObjectManager.Player.TotalAttackDamage + 2*ObjectManager.Player.BaseAttackDamage;
            }

            return AttackDamage[ObjectManager.Player.Level - 1] + ObjectManager.Player.TotalMagicalDamage*0.5 +
                   damage;
        }


        public static float GetWDamage(Obj_AI_Base target, int stage = 0, bool newDamageLogic = false,
            float newDamage = 0f)
        {
            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level == 0 ||
                !ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).IsReady())
            {
                return 0f;
            }

            return 0f;
        }

        public static float GetEDamage(Obj_AI_Base target, int stage = 0, bool newDamageLogic = false,
            float newDamage = 0f)
        {
            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level == 0 ||
                !ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).IsReady())
            {
                return 0f;
            }

            if (newDamageLogic)
            {
                return newDamage;
            }

            return (float)ObjectManager.Player.GetSpellDamage(target, SpellSlot.E, stage);
        }

        public static float GetRDamage(Obj_AI_Base target, int stage = 0, bool newDamageLogic = false,
            float newDamage = 0f)
        {
            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level == 0 ||
                !ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).IsReady())
            {
                return 0f;
            }

            if (newDamageLogic)
            {
                return newDamage;
            }

            return (float) ObjectManager.Player.GetSpellDamage(target, SpellSlot.R) +
                (float) ObjectManager.Player.GetSpellDamage(target, SpellSlot.R, 1);
        }

        public static float GetIgniteDmage(Obj_AI_Base target)
        {
            if (ObjectManager.Player.GetSpellSlot("SummonerDot") == SpellSlot.Unknown ||
                !ObjectManager.Player.GetSpellSlot("SummonerDot").IsReady())
            {
                return 0f;
            }

            return 50 + 20*ObjectManager.Player.Level - target.HPRegenRate/5*3;
        }
    }
}
