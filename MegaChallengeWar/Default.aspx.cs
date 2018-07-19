using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar.Classes
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Player playerOne = new Player("Sean", new Deck());
            Player playerTwo = new Player("Jessica", new Deck());
            Game game = new Game(playerOne, playerTwo);

            StringBuilder resultsSb = new StringBuilder();

            foreach(Card card in game.Deck.Cards)
            {
                resultsSb.Append($"{card.Value} - {card.Suit.ToString()} - {card.Face.ToString()}<br/>");
            }

            resultsLabel.Text = resultsSb.ToString();
        }
    }
}