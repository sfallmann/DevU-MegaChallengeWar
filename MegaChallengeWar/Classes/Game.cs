using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class Game
    {
        private Player _playerOne;
        private Player _playerTwo;
        private Deck _deck;
        private Deck _pool = new Deck();
        private bool _isWar = false;
        private bool _gameOver = false;
        private int _winThreshold;

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

        public Deck Pool
        {
            get { return _pool; }
        }

        public bool IsWar
        {
            get { return _isWar; }
        }

        public bool Over
        {
            get { return _gameOver; }
        }

        public int WinThreshold
        {
            get { return _winThreshold; }
        }

        public Game(Player playerOne, Player playerTwo, int winThreshold = 20)
        {
            this._playerOne = playerOne;
            this._playerTwo = playerTwo;
            this._deck = new Deck();
            this.initializeDeck();
            this._winThreshold = winThreshold < 0 ? 0 : winThreshold;
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

        public string DealCards()
        {
            StringBuilder sb = new StringBuilder();

            while (this._deck.Cards.Count > 0)
            {
                
                Card playerOneCard = this.Deck.NextCard();
                sb.Append($"{this.PlayerOne.Name} dealt {TextHelper.DisplayCard(playerOneCard)}");

                Card playerTwoCard = this.Deck.NextCard();
                sb.Append($"{this.PlayerTwo.Name} dealt {TextHelper.DisplayCard(playerTwoCard)}");

                this.PlayerOne.Deck.AddCard(playerOneCard);
                this.PlayerTwo.Deck.AddCard(playerTwoCard);
            }

            return sb.ToString();
        }

        public void AwardCards(Player player)
        {
            while(this.Pool.Cards.Count > 0)
            {
                player.Deck.AddCard(this.Pool.NextCard());
            }
        }

        public Player Turn()
        {
            if (this.Over) return null;

            Card playerOneCard = this.PlayerOne.Deck.NextCard();
            Card playerTwoCard = this.PlayerTwo.Deck.NextCard();
            Player turnWinner;

            this.Pool.AddCard(playerOneCard);
            this.Pool.AddCard(playerTwoCard);

            if (playerOneCard.Value == playerTwoCard.Value)
            {
                this._isWar = true;
                return null;
            }
            else if (playerOneCard.Value > playerTwoCard.Value)
            {
                turnWinner = this.PlayerOne;
            }
            else
            {
                turnWinner = this.PlayerTwo;
            }

            this.AwardCards(turnWinner);
            this._isWar = false;

            if (this.GetWinner() != null) this._gameOver = true;

            return turnWinner;
        }

        public Player GetWinner()
        {
            int playerOneCardCount = this._playerOne.Deck.Cards.Count;
            int playerTwoCardCount = this._playerTwo.Deck.Cards.Count;

            if (playerOneCardCount == this.WinThreshold)
            {
                return this.PlayerTwo;
            }

            if (playerTwoCardCount == this.WinThreshold)
            {
                return this.PlayerOne;
            }

            return null;
        }

    }
}