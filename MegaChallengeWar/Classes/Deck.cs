using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class Deck
    {
        private Queue<Card> _cards;

        public Queue<Card> Cards
        {
            get { return _cards; }
        }

        public void AddCard(Card card)
        {
            this._cards.Enqueue(card);
        }

        public Card NextCard()
        {
            return this._cards.Dequeue();
        }

        public Deck()
        {
            this._cards = new Queue<Card>();
        }
    }
}