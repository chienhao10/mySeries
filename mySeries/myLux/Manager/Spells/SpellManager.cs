namespace myLux.Manager.Spells
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

            Q.SetSkillshot(0.25f, 70f, 1200f, false, SkillshotType.SkillshotLine);
            W.SetSkillshot(0.25f, 110f, 1200f, false, SkillshotType.SkillshotLine);
            E.SetSkillshot(0.3f, 250f, 1050f, false, SkillshotType.SkillshotCircle);
            R.SetSkillshot(1.0f, 110f, float.MaxValue, false, SkillshotType.SkillshotLine);

            Ignite = Me.GetSpellSlot("SummonerDot");
        }

        internal static void CastQ(Obj_AI_Hero target)
        {
            if (target == null || !target.IsValidTarget(Q.Range))
            {
                return;
            }

            var qPredInput = new PredictionInput
            {
                Delay = Q.Delay,
                Radius = Q.Width,
                Range = Q.Range,
                Speed = Q.Speed,
                Type = SkillshotType.SkillshotLine,
                Unit = Me,
                Aoe = false,
                Collision = true,
                CollisionObjects = new[] {CollisionableObjects.YasuoWall}
            };

            if (LeagueSharp.Common.Collision.GetCollision(new List<Vector3> {target.ServerPosition}, qPredInput).Any())
            {
                return;
            }

            var qPred = Q.GetPrediction(target);

            if (qPred.Hitchance >= HitChance.VeryHigh || qPred.Hitchance == HitChance.Immobile)
            {
                var qCol = Q.GetCollision(Me.Position.To2D(), new List<Vector2>
                {
                    qPred.CastPosition.To2D()
                });

                if (qCol.Count <= 1)
                {
                    Q.Cast(qPred.CastPosition, true);
                }
                else if (qCol.Count(x => x.IsMinion) <= 1)
                {
                    Q.Cast(qPred.CastPosition, true);
                }
            }
        }

        internal static void CastE(Obj_AI_Hero target)
        {
            if (target == null || !target.IsValidTarget(E.Range))
            {
                return;
            }
        }
    }
}
