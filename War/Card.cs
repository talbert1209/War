using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace War
{
    public class Card
    {
        public string Name { get; }
        public int Value { get; private set; }
        private readonly Dictionary<int, string> _cardValueDictionary = new Dictionary<int, string>()
        {
            {1, "ace"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "jack"},
            {12, "queen"},
            {13, "king"},
        };
        private readonly Dictionary<int, string> _suitDictionary = new Dictionary<int, string>()
        {
            {1, "clubs"},
            {2, "hearts"},
            {3, "spades"},
            {4, "diamonds"},
        };
        public Card(int suit, int value)
        {
            Name = $"{_cardValueDictionary[value]} of {_suitDictionary[suit]}";
            Value = value;
        }
    }
}