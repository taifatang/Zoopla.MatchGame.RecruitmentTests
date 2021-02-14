using MatchGameEngine.Models;
using System;
using System.Collections.Generic;
namespace MatchGameEngine
{
    public interface IDeckProvider
    {
        List<Card> GetCards(int deckCount);
    }

    public class ShuffledDeckProvider : IDeckProvider
    {
        public List<Card> GetCards(int deckCount)
        {
            var deck = new List<Card>();

            for (int i = 0; i < deckCount; i++)
            {
                deck.AddRange(Deck.Standard);
            }

            Shuffle(deck);

            return deck;
        }

        //Fisher-Yates shuffle:
        //https://stackoverflow.com/questions/273313/randomize-a-listt
        public void Shuffle(List<Card> cards)
        {
            var random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
