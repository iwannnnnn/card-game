using System;

namespace CardGame
{
    public class Card
    {
        public string DisplayName => $"{Value}{Enum.GetName(typeof(Suit), Suit)[0]}";
        public Suit Suit { get; set; }
        public int Value { get; set; }
    }
}
