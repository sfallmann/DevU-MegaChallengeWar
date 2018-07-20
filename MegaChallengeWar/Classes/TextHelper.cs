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
                sb.Append("<br/>");
            }

            return sb.ToString();
        }

        public static string GetSuit(Card.Suits suit)
        {
            switch (suit)
            {
                case Card.Suits.Clubs:
                    return "<span style=\"color: black;\">&clubs;</span>";
                case Card.Suits.Diamonds:
                    return "<span style=\"color: red;\">&diams;</span>";
                case Card.Suits.Hearts:
                    return "<span style=\"color: red;\">&hearts;</span>";
                default:
                    return "<span style=\"color: black;\">&spades;</span>";
            }


        }

        public static string DisplayCard(Card card)
        {
            string value = card.Face == Card.Faces.None ? card.Value.ToString() : card.Face.ToString();
            string suit = TextHelper.GetSuit(card.Suit);

            return $"{value} {suit}";
        }

        public static string DisplayPlayerCards(Player playerOne, Player playerTwo)
        {
            string playerOneCard = TextHelper.DisplayCard(playerOne.Deck.Cards.Last());
            string playerTwoCard = TextHelper.DisplayCard(playerTwo.Deck.Cards.Last());

            string results = $"{playerOne.Name}: {playerOneCard}<br/>";
            results += $"{playerTwo.Name}: {playerTwoCard}";
            return results;
        }
    }
}