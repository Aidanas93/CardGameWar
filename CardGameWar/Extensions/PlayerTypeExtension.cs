using CardGameWar.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameWar.Extensions
{
    public static class PlayerTypeExtension
    {
        public static int Value(this PlayerTurn type)
            => (int)type;
    }
}
