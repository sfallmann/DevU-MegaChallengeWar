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
        private bool _gameOver = false;

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
                for (var value = 2; value < 15; value++)
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

        public void DealCards()
        {
            while (this._deck.Cards.Count > 0)
            {
                this.PlayerOne.Deck.AddCard(this._deck.NextCard());
                this.PlayerTwo.Deck.AddCard(this._deck.NextCard());
            }
        }

        private void checkGameStatus()
        {

        }

        private bool isOver()
        {
            if (this._gameOver) return true;

            if (this.GetWinner() != null)
            {
                this._gameOver = true;
                return true;
            }

            return false;
        }

        public void Turn()
        {
            if (this.isOver()) return;

            Card playerOneCard = this.PlayerOne.Deck.NextCard();
            Card playerTwoCard = this.PlayerTwo.Deck.NextCard();

            if (playerOneCard.Value == playerTwoCard.Value)
            {
                // this.war();

            }
            else if (playerOneCard.Value > playerTwoCard.Value)
            {
                this.PlayerOne.Deck.AddCard(playerOneCard);
                this.PlayerOne.Deck.AddCard(playerTwoCard);
            }
            else
            {

                this.PlayerTwo.Deck.AddCard(playerOneCard);
                this.PlayerTwo.Deck.AddCard(playerTwoCard);
            }

        }

        public Player GetWinner()
        {
            if (!this._gameOver) return null;

            int playerOneCardCount = this._playerOne.Deck.Cards.Count;
            int playerTwoCardCount = this._playerTwo.Deck.Cards.Count;

            return playerOneCardCount == 0 ? this.PlayerOne : this.PlayerTwo;
        }

    }
}