using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class DeckCreator : IDeckCreator
    {
        public List<Card> Cards { get; set; }
        public bool IsShuffle { get; set; } = true;

        public void FillCards()
        {
            if (Cards==null || !Cards.Any())
            {
                Cards = new List<Card>();
                for (var i = 1; i <= 10; i++)
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        Cards.Add(new Card
                        {
                            Suit = suit,
                            Value = i
                        });
                    }
                }
                if (IsShuffle)
                {
                    Cards = Cards.Shuffle();
                }
            }
        }
    }
}
