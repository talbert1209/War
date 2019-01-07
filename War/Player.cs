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

        public int BountyCount { get; private set; }

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

        public List<Card> PlayCard(int cardsToGet)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < cardsToGet; i++)
            {
                cards.Add(_hand.Deal());
            }

            return cards;
        }

        public void AddToBountyCount(int bountiesToAdd)
        {
            BountyCount += bountiesToAdd;
        }
    }
}