using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGameTest
{
    [TestClass]
    public class DockTest
    {

        [TestMethod]
        public void Test_FillCards()
        {  
            DeckCreator deckCreator = new DeckCreator();
            deckCreator.FillCards();
            var exCard = new Card
            {
                Value = 1,
                Suit = Suit.Clubs
            };
            Assert.AreEqual(40, deckCreator.Cards.Count);
            Assert.AreNotEqual(exCard.DisplayName, deckCreator.Cards[0].DisplayName);
        }
    }
}