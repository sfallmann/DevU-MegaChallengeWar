using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class Game
    {
        private Player _playerOne;
        private Player _playerTwo;
        private Deck _deck;

        public Player PlayerOne
        {
            get { return _playerOne; }
        }

        public Player PlayerTwo
        {
            get { return _playerTwo; }
        }

        public Deck Deck
        {
            get { return _deck; }
        }

        public Game(Player playerOne, Player playerTwo)
        {
            this._playerOne = playerOne;
            this._playerTwo = playerTwo;
            this._deck = new Deck();
            this.initializeDeck();
        }

        private void initializeDeck()
        {
            foreach (Card.Suits suit in Enum.GetValues(typeof (Card.Suits)))
            {
                for (var value = 1; value < 15; value++)
                {
                    switch (value)
                    {
                        case 14:
                            this._deck.AddCard(new Card(value, suit, Card.Faces.Ace));
                            break;
                        case 13:
                            this._deck.AddCard(new Card(value, suit, Card.Faces.King));
                            break;
                        case 12:
                            this._deck.AddCard(new Card(value, suit, Card.Faces.Queen));
                            break;
                        case 11:
                            this._deck.AddCard(new Card(value, suit, Card.Faces.Jack));
                            break;
                        default:
                            this._deck.AddCard(new Card(value, suit, Card.Faces.None));
                            break;
                    }
                }
            }
        }

    }
}