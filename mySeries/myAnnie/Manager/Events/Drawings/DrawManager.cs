namespace myAnnie.Manager.Events.Drawings
{
    using System;
    using System.Drawing;
    using LeagueSharp;
    using LeagueSharp.Common;
    using myCommon;

    internal class DrawManager : Logic
    {
        internal static void Init(EventArgs args)
        {
            if (!Me.IsDead && !MenuGUI.IsShopOpen && !MenuGUI.IsChatOpen && !MenuGUI.IsScoreboardOpen)
            {
                if (Menu.GetBool("DrawQ") && Q.IsReady())
                {
                    Render.Circle.DrawCircle(Me.Position, Q.Range, Color.Green, 1);
                }

                if (Menu.GetBool("DrawW") && W.IsReady())
                {
                    Render.Circle.DrawCircle(Me.Position, W.Range, Color.FromArgb(9, 253, 242), 1);
                }

                if (Menu.GetBool("DrawR") && R.IsReady())
                {
                    Render.Circle.DrawCircle(Me.Position, R.Range, Color.FromArgb(19, 130, 234), 1);
                }

                if (Menu.GetBool("DrawFlashR"))
                {
                    Render.Circle.DrawCircle(Me.Position, R.Range + 425f, Color.FromArgb(14, 194, 255), 1);
                }
            }
        }
    }
}
