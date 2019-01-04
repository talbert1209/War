using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace War
{
    public class Deck
    {
        private List<Card> _cards;
        private readonly Random _random = new Random();

        public int Count
        {
            get { return _cards.Count; }
        }

        public Deck()
        {
            _cards = new List<Card>();
            for (var suit = 1; suit <= 4; suit++)
            for (var value = 1; value <= 13; value++)
                _cards.Add(new Card(suit, value));
        }

        public Deck(List<Card> listOfCards)
        {
            _cards = listOfCards;
        }

        public void Shuffle()
        {
            var shuffledDeck = new List<Card>();
            while (_cards.Count > 0)
            {
                var randomCardIndex = _random.Next(_cards.Count);
                shuffledDeck.Add(_cards[randomCardIndex]);
                _cards.RemoveAt(randomCardIndex);
            }

            _cards = shuffledDeck;
        }

        public string DisplayCard(int index)
        {
            return _cards[index].Name;
        }

        public Card Deal()
        {
            var cardToDeal = _cards[0];
            _cards.RemoveAt(0);
            return cardToDeal;
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }
    }
}