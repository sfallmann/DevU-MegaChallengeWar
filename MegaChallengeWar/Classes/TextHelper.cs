using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaChallengeWar.Classes
{
    public class TextHelper
    {
        public static string DisplayDeck(Deck deck)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var card in deck.Cards)
            {
                sb.Append(DisplayCard(card));
            }

            return sb.ToString();
        }

        public static string DisplayCard(Card card)
        {
            string value = card.Face == Card.Faces.None ? card.Value.ToString() : card.Face.ToString();
            string suit = card.Suit.ToString();

            return $"{value} of {suit}<br/>";
        }

        public static string DisplayPlayerCards(Player playerOne, Player playerTwo)
        {
            Card playerOneCard = playerOne.Deck.Cards.Last();
            Card playerTwoCard = playerTwo.Deck.Cards.Last();

            string results = $"Player One: {playerOneCard.Value}<br/>";
            results += $"Player Two: {playerTwoCard.Value}<br/>";

            return results;
        }
    }
}