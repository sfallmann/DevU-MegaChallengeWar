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

            game.Deck.Shuffle();
            
            resultsLabel.Text += "<hr/>";
            
            resultsLabel.Text += game.DealCards();

            Player turnWinner;
            Player gameWinner;
            
            while (!game.Over)
            {
                resultsSb.Append(TextHelper.DisplayPlayerCards(playerOne, playerTwo));

                if ((turnWinner = game.Turn()) == null)
                {
                    resultsSb.Append("<br>====================<br/>WAR!</br>====================<br/>");
                    resultsSb.Append(TextHelper.DisplayDeck(game.Pool));
                }
                else
                {
                    resultsSb.Append($"{turnWinner.Name} won the turn!<br/><hr/><br/>");
                }
                resultsLabel.Text = resultsSb.ToString();
            }

            gameWinner = game.GetWinner();
            resultsSb.Append($"{gameWinner.Name} won the game!<br/><hr/><br/>");
            resultsLabel.Text = resultsSb.ToString();

        }


    }

}