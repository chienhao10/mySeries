namespace myCommon
{
    using LeagueSharp;

    public static class ManaManager
    {
        public static bool HasMana(int manaPercent)
        {
            return ObjectManager.Player.ManaPercent >= manaPercent;
        }
    }
}
