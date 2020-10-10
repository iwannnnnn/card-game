using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardGameTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void PlayTest()
        {
            DeckCreator deckCreator = new DeckCreator
            {
                Cards = new List<Card>
                {
                    new Card
                    {
                        Value = 10,
                        Suit = Suit.Clubs
                    },
                    new Card
                    {
                        Value = 1,
                        Suit = Suit.Diamonds
                    },
                    new Card
                    {
                        Value = 9,
                        Suit = Suit.Clubs
                    },
                    new Card
                    {
                        Value = 2,
                        Suit = Suit.Diamonds
                    }
                }
            };
            Game game = new Game(2, 2)
            {
                DeckCreator = deckCreator
            };
            game.Deal();

            Assert.AreEqual(2, game.Players.Count);
            Assert.AreEqual(2, game.Players[0].Cards.Count);
            Assert.AreEqual(2, game.Players[1].Cards.Count);

            while (!game.IsEndOfGame())
            {
                game.Play();
            }
            Assert.AreEqual(4, game.Players[0].DrowCards.Count);
        }

        [TestMethod]
        public void PlayEquelsCardsTest()
        {
            DeckCreator deckCreator = new DeckCreator
            {
                Cards = new List<Card>
                {
                    new Card
                    {
                        Value = 1,
                        Suit = Suit.Clubs
                    },
                    new Card
                    {
                        Value = 1,
                        Suit = Suit.Diamonds
                    },
                    new Card
                    {
                        Value = 10,
                        Suit = Suit.Clubs
                    },
                    new Card
                    {
                        Value = 2,
                        Suit = Suit.Diamonds
                    }
                }
            };
            Game game = new Game(2, 2)
            {
                DeckCreator = deckCreator
            };
            game.Deal();

            Assert.AreEqual(2, game.Players.Count);
            Assert.AreEqual(2, game.Players[0].Cards.Count);
            Assert.AreEqual(game.Players[0].Cards[0].Value, game.Players[1].Cards[0].Value);

            while (!game.IsEndOfGame())
            {
                game.Play();
                Assert.AreEqual(4, game.Players[0].CardCount);
                Assert.AreEqual(0, game.Players[1].CardCount);
            }
        }
    }
}