using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Game
    {
        private IDeckCreator _deckCreator;
        public List<Player> Players;
        private List<Player> PlayersLost;

        public Game(int numberOfPlayer, int numberOfHandCards)
        {
            _deckCreator = new DeckCreator();
            _deckCreator.FillCards();
            NumberOfPlayer = numberOfPlayer;
            NumberOfHandCards = numberOfHandCards;
          
            Deal();
        }

        public int NumberOfHandCards { get; set; }
        public int NumberOfPlayer { get; set; }
        public IDeckCreator DeckCreator { get => _deckCreator; set => _deckCreator = value; }

        public void Deal()
        {
            GeneratePlayers();
            int i = 0;

            while (i < DeckCreator.Cards.Count)
            {
                if (Players.All(p => p.Cards.Count == NumberOfHandCards))
                {
                    break;
                }
                foreach (var player in Players)
                {
                    player.Cards.Add(DeckCreator.Cards[i++]);
                }
            }
        }

        public string FindWinnerGame()
        {
            return Players[0].Name;
        }

        public void GeneratePlayers()
        {
            Players = new List<Player>();
            PlayersLost = new List<Player>();
            int i = 0;
            while (i < NumberOfPlayer)
            {
                Players.Add(new Player($"Player-{i + 1}"));
                i++;
            }
        }

        public bool IsEndOfGame()
        {
            if (Players.Any(p => p.IsLoser))
            {
                foreach (var loser in Players.Where(p => p.IsLoser))
                {
                    Console.WriteLine(loser.Name + " is lose!");
                    PlayersLost.Add(loser);
                }
                Players = Players.Except(PlayersLost).ToList();
            }
            return Players.Count() == 1;
        }

        public void Play()
        {
            var pool = new List<Card>();
            var tempPool = new List<Card>();
            var winnerPlayer = -1;
            while (winnerPlayer == -1)
            {
                if (Players.Any(p => p.IsEmptyCards))
                {
                    foreach (var player in Players.Where(p => p.IsEmptyCards))
                    {
                        if (!player.DrowCards.Any())
                        {
                            Console.WriteLine(player.Name + " is lose!");
                            PlayersLost.Add(player);
                        }
                        else
                        {
                            player.Cards = player.DrowCards.Shuffle();
                            player.DrowCards = new List<Card>();
                        }
                        Players = Players.Except(PlayersLost).ToList();
                    }
                }
                foreach (var player in Players)
                {
                    player.PlayNextCard();
                    Console.WriteLine($"Player:{player.Name}({player.CardCount} cards):{player.CurrentCard.Value}");
                    pool.Add(player.CurrentCard);
                }
                if (pool.All(c => pool.All(p => c.Value == p.Value)))
                {
                    Console.WriteLine($"No winner in this round");
                }
                else
                {
                    winnerPlayer = pool.IndexOf(pool.First(c => c.Value == pool.Max(p => p.Value)));
                }
                tempPool.AddRange(pool);
                pool = new List<Card>();
            }

            var winnerRound = Players[winnerPlayer];
            winnerRound.DrowCards.AddRange(tempPool);

            Console.WriteLine($"Plpayer:{winnerRound.Name} win round");
        }
    }
}