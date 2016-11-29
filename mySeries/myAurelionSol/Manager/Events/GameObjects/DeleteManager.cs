﻿namespace myAurelionSol.Manager.Events
{
    using System;
    using LeagueSharp;

    internal class DeleteManager : Logic
    {
        internal static void Init(GameObject sender, EventArgs args)
        {
            var SpellQ = sender as MissileClient;

            if (SpellQ != null)
            {
                if (SpellQ.IsValid && SpellQ.SpellCaster is Obj_AI_Hero)
                {
                    if (SpellQ.SpellCaster.IsMe && SpellQ.SpellCaster.IsValid &&
                        SpellQ.SData.Name.Contains("AurelionSolQMissile"))
                    {
                        qMillile = null;
                    }
                }
            }
        }
    }
}