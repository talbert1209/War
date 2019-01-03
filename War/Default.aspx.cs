using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace War
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void drawButton_Click(object sender, EventArgs e)
        {
            var cardCount = 1;
            Deck fullDeck = new Deck();
            foreach (var card in fullDeck.Cards)
            {
                resultLabel.Text += $"{cardCount}. {card.Name.ToUpper()}</br>";
                cardCount++;
            } 
        }
    }
}