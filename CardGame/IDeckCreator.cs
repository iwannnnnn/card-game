using System.Collections.Generic;

namespace CardGame
{
    public interface IDeckCreator
    {
        void FillCards();
        List<Card> Cards { get; set; }
        bool IsShuffle { get; set; }
    }
}
