using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class Player
    {
        private string _name;
        private Deck _deck;


        public string Name
        {
            get { return _name; }
        }

        public Deck Deck
        {
            get { return _deck; }
        }

        public Player(string name, Deck deck)
        {
            this._name = name;
            this._deck = deck;
        }

    }
}