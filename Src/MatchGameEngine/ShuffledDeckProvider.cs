using MatchGameEngine.Models;
using System.Collections.Generic;

namespace MatchGameEngine
{
    public interface IDeckProvider
    {
        List<Card> GetDeck();
    }

    public class ShuffledDeckProvider: IDeckProvider
    {
        public List<Card> GetDeck()
        {
            return new List<Card>();
        }
    }
}
