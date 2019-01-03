using System;
using System.Collections.Generic;
using System.Linq;
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
            Random random = new Random();
            Card card = new Card(random.Next(1,5), random.Next(1,14));

            resultLabel.Text = card.Name;
        }
    }
}