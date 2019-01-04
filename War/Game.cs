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

        public void Play()
        {
            _label.Text += "<h3>Begin Battle...</h3>";

            for (int i = 0; i < 6; i++)
            {
                var player1Card = PlayCard(_player1);
                var player2Card = PlayCard(_player2);

                _label.Text += $"Player 1 card:{player1Card.Name} vs Player 2 card: {player2Card.Name}</br>";

                if (player1Card.Value > player2Card.Value)
                    _label.Text += $"&nbsp;&nbsp;&nbsp;{player1Card.Name} is greater than {player2Card.Name} player 1 wins</br>";
                else if (player2Card.Value > player1Card.Value)
                    _label.Text += $"&nbsp;&nbsp;&nbsp;{player2Card.Name} is greater than {player1Card.Name} player 2 wins</br>";
                else
                    _label.Text += $"&nbsp;&nbsp;&nbsp;{player1Card.Name} and {player2Card.Name} are equal y'all tie.</br>";
            }
        }
    }
}