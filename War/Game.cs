using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace War
{
    public class Game
    {
        private Player _player1;
        private Player _player2;

        private Deck _deck;

        private Label _label;

        public Game(Label label)
        {
            _label = label;
            _deck = new Deck();
            _player1 = new Player();
            _player2 = new Player();
            DealCards();
        }

        private void DealCards()
        {
            var count = 1;
            _deck.Shuffle();
            _label.Text += "<h3>Dealing Cards...</h3>";
            while (_deck.Count > 0)
            {
                _label.Text += $"{count}. Player 1 is dealt the {_player1.TakeCard(_deck.Deal()).Name}</br>";
                count++;
                _label.Text += $"{count}. Player 2 is dealt the {_player2.TakeCard(_deck.Deal()).Name}</br>";
                count++;
            }

        }

        public Card PlayCard(Player player)
        {
            return player.PlayCard();
        }

        public List<Card> PlayCards(Player player, int amountOfCards)
        {
            return player.PlayCard(amountOfCards);
        }

        public void Play()
        {
            _label.Text += "<h3>Begin Battle...</h3>";

            for (int i = 0; i < 20; i++)
            {
                Battle battle = new Battle(_player1, _player2, _label);
            }
            GetWinner();
        }

        private void GetWinner()
        {
            _label.Text += "<b>Battle Stats...</b></br>";
            _label.Text += $"Player 1: {_player1.BountyCount} Bounties</br>";
            _label.Text += $"Player 2: {_player2.BountyCount} Bounties</br></br>";

            if (_player1.BountyCount > _player2.BountyCount)
                _label.Text += "<b>Player 1 Wins!</b>";
            else if (_player1.BountyCount < _player2.BountyCount)
                _label.Text += "<b>Player 2 Wins!</b>";
            else
                _label.Text += "<b>Tie Game!</b>";
        }
    }
}