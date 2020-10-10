using System;
using System.Collections.Generic;

namespace CardGame
{
    public static class Extensions
    {
        public static List<Card> Shuffle(this List<Card> Cards)
        {
            var r = new Random();
            for (var i = Cards.Count - 1; i > 0; i--)
            {
                var j = r.Next(0, i + 1);
                SwitchCards(Cards, i, j);
            }
            return Cards;
        }

        private static void SwitchCards(List<Card> Cards, int i, int j)
        {
            var temp = Cards[i];
            Cards[i] = Cards[j];
            Cards[j] = temp;
        }
    }
}
