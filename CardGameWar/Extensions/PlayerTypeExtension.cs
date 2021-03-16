using CardGameWar.Models;

namespace CardGameWar.Extensions
{
    public static class PlayerTypeExtension
    {
        public static int Value(this Face type)
             => (int)type;
    }
}
