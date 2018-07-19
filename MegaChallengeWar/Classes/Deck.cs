using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class Deck
    {
        private List<Card> _cards;
        private Random _random = new Random();

        public List<Card> Cards
        {
            get { return _cards; }
        }

        public Deck()
        {
            this._cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            this._cards.Insert(0, card);
        }

        public Card NextCard()
        {
            int lastIndex = this._cards.Count - 1;
            Card card = this._cards.ElementAt(lastIndex);

            this._cards.RemoveAt(lastIndex);

            return card;
        }

        public void Shuffle()
        {
            int totalCards = this._cards.Count;

            Deck shuffledDeck = new Deck();

            while (shuffledDeck.Cards.Count < totalCards)
            {
                int index = _random.Next(this._cards.Count - 1);

                shuffledDeck.AddCard(this._cards.ElementAt(index));
                this._cards.RemoveAt(index);
            }

            this._cards = null;
            this._cards = shuffledDeck._cards;

        }

    }
}