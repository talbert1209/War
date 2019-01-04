using System.Collections.Generic;

namespace War
{
    public class Player
    {
        private Deck _hand;

        public int CardCount
        {
            get { return _hand.Count; }
        }

        public Player()
        {
            _hand = new Deck(new List<Card>());
        }

        public Card TakeCard(Card card)
        {
            _hand.Add(card);
            return card;
        }

        public Card PlayCard()
        {
            return _hand.Deal();
        }
    }
}