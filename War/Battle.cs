using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace War
{
    public class Battle
    {
        private readonly Label _label;
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly Card _player1BattleCard;
        private readonly Card _player2BattleCard;

        public List<Card> Bounty { get; set; }

        public Battle(Player player1, Player player2, Label label)
        {
            Bounty = new List<Card>();
            _label = label;
            _player1 = player1;
            _player2 = player2;
            _player1BattleCard = _player1.PlayCard();
            _player2BattleCard = _player2.PlayCard();
            Bounty.Add(_player1BattleCard);
            Bounty.Add(_player2BattleCard);

            _label.Text += $"Battle Cards: {_player1BattleCard.Name} vs {_player2BattleCard.Name}</br>";

            if (GetBattleWinner() == "player1")
            {
                _player1.AddToBountyCount(2);
                DisplayBounty();
                _label.Text += "<b>Player 1 Wins!</b></br></br>";
            }
            else if (GetBattleWinner() == "player2")
            {
                _player2.AddToBountyCount(2);
                DisplayBounty();
                _label.Text += "<b>Player 2 Wins!</b></br></br>";
            }
            else if (GetBattleWinner() == "war")
            {
                War();
            }
        }

        private void War()
        {
            var winner = false;
            List<Card> warBounty = new List<Card>();
            while (!winner)
            {
                _label.Text += "******** WAR ********</br></br>";
                warBounty.AddRange(_player1.PlayCard(2));
                warBounty.AddRange(_player2.PlayCard(2));

                var player1WarBattleCard = _player1.PlayCard();
                var player2WarBattleCard = _player2.PlayCard();

                warBounty.Add(player1WarBattleCard);
                warBounty.Add(player2WarBattleCard);

                Bounty.AddRange(warBounty);


                DisplayBounty();

                if (player1WarBattleCard.Value > player2WarBattleCard.Value)
                {
                    _player1.AddToBountyCount(warBounty.Count + 2);
                    _label.Text += "<b>Player 1 Wins!</b></br></br>";
                    winner = true;
                }

                if (player1WarBattleCard.Value < player2WarBattleCard.Value)
                {
                    _player2.AddToBountyCount(warBounty.Count + 2);
                    _label.Text += "<b>Player 2 Wins!</b></br></br>";
                    winner = true;
                }
            }
        }

        private string GetBattleWinner()
        {
            if (_player1BattleCard.Value > _player2BattleCard.Value)
                return "player1";
            if (_player1BattleCard.Value < _player2BattleCard.Value)
                return "player2";
            return "war";
        }

        private void DisplayBounty()
        {
            _label.Text += $"Bounty...</br>";
            foreach (var card in Bounty)
            {
                _label.Text += $"&nbsp;&nbsp;&nbsp;{card.Name}</br>";
            }
        }
    }
}