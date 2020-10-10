using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Player
    {
        public Player(string player1name = "Player")
        {
            Name = player1name;
            Cards = new List<Card>();
            DrowCards = new List<Card>();
        }

        public string Name { get; set; }

        public List<Card> Cards { get; set; }

        public List<Card> DrowCards { get; set; }

        public bool IsEmptyCards => !Cards.Any();

        public int CardCount => Cards.Count + DrowCards.Count;

        public bool IsLoser => !Cards.Any() && !DrowCards.Any();
        public Card CurrentCard { get; set; }
        public void PlayNextCard()
        {
            CurrentCard = Cards[0];
            Cards.Remove(CurrentCard);
        }
    }
}
