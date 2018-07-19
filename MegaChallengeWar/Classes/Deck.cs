using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class Deck
    {
        private List<Card> _cards;

        public List<Card> Cards
        {
            get { return _cards; }
        }

        public void AddCard(Card card)
        {
            this._cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            this._cards.Remove(card);
        }

        public List<Card> GetCards()
        {
            return this._cards;
        }

    }
}