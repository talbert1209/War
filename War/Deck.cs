using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace War
{
    public class Deck
    {
        public List<Card> Cards { get; }

        public Deck()
        {
            Cards = new List<Card>();
            for (var suit = 1; suit <= 4; suit++)
            for (var value = 1; value <= 13; value++)
                Cards.Add(new Card(suit, value));
        }
    }
}