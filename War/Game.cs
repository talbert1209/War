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





                //var player1Card = PlayCard(_player1);
                //var player2Card = PlayCard(_player2);
                //List<Card> bounty = new List<Card>(){player1Card, player2Card};

                //if (player1Card.Value > player2Card.Value)
                //{
                //    _label.Text += $"Battle Cards: {player1Card.Name} vs {player2Card.Name}</br>";
                //    _label.Text += $"{GetBounty(bounty)}";
                //    _label.Text += "<b>Player 1 Wins!</b></br>";
                //}
                //else if (player2Card.Value > player1Card.Value)
                //{
                //    _label.Text += $"Battle Cards: {player1Card.Name} vs {player2Card.Name}</br>";
                //    _label.Text += $"{GetBounty(bounty)}";
                //    _label.Text += "<b>Player 2 Wins</b></br>";
                //}
                //else
                //{
                //    _label.Text += $"Battle Cards: {player1Card.Name} vs {player2Card.Name}</br>";
                //    bounty.AddRange(GetWarBounty());
                //    War(player1Card, player2Card);
                    
                //    _label.Text += "<b>y'all tie</b></br>";
                //}
            }
        }

        private string GetBounty(List<Card> bountyCards)
        {
            var bountyString = "Bounty...</br>";
            foreach (var card in bountyCards)
            {
                bountyString += $"&nbsp;&nbsp;&nbsp;{card.Name}</br>";
            }

            return bountyString;
        }

        private void War(Card player1Card, Card player2Card)
        {
            List<Card> bountyCards = new List<Card>(){player1Card, player2Card};
            Card player1Burn1 = _player1.PlayCard();
            Card player2Burn1 = _player2.PlayCard();
            Card player1Burn2 = _player1.PlayCard();
            Card player2Burn2 = _player2.PlayCard();
            Card player1BattleCard = _player1.PlayCard();
            Card player2BattleCard = _player2.PlayCard();

            _label.Text += "********WAR********</br>";


        }

        private List<Card> GetWarBounty()
        {
            List<Card> warBounty = new List<Card>();
            warBounty.AddRange(PlayCards(_player1, 2));
            warBounty.AddRange(PlayCards(_player2, 2));
            return warBounty;
        }
       
    }
}