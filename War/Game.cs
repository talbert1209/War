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

        }
    }
}