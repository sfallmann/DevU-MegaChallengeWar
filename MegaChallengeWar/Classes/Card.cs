using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class Card
    {
        public enum Suits
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public enum Faces
        {
            None,
            Jack,
            Queen,
            King,
            Ace
        }

        private int _value;
        private Suits _suit;
        private Faces _face;

        public int Value
        {
            get { return _value; }
        }

        public Suits Suit
        {
            get { return _suit; }
        }

        public Faces Face
        {
            get { return _face; }
        }

        public Card(int value, Suits suit, Faces face)
        {
            this._value = value;
            this._suit = suit;
            this._face = face;
        }

        
    }
}