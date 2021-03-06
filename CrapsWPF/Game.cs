﻿using System;

namespace CrapsWPF
{
    class Game
    {
        private Dice dice1, dice2;
        private Player player, house;
        private Roll roll;
        private int bet, diceTotal;
        private bool wagerOn;

        public Game()
        {
            dice1 = new Dice((int)DateTime.Now.Ticks + 1002);
            dice2 = new Dice((int)DateTime.Now.Ticks - 77);
            player = new Player();
            house = new Player();
            roll = new Roll();
            Bet = 0;
            DiceTotal = 0;
            WagerOn = false;
        }

        public int Bet { get => this.bet; set => this.bet = value; }
        public int DiceTotal { get => this.diceTotal; set => this.diceTotal = value; }
        public bool WagerOn { get => this.wagerOn; set => this.wagerOn = value; }

        public void RollDice()
        {
            dice1.RollDice();
            dice2.RollDice();
            DiceTotal = dice1.Value + dice2.Value;
        }

        public bool CheckRoll()
        {
            return roll.CheckRoll(this);
        }

        public bool CheckWin()
        {
            return player.Win;
        }

        public String GetBank(int type)
        {
            if (type == 1)
                return player.Bank.ToString();
            else
                return house.Bank.ToString();
        }

        public String GetDiceValue(int type)
        {
            if (type == 1)
                return dice1.Value.ToString();
            else
                return dice2.Value.ToString();
        }

        public void SetPoints(int type)
        {
            if (type == 0)
                player.Points += 1;
            else
                house.Points += 1;
        }

        public void SetBank(int type, int value)
        {
            if(type == 0)
            {
                player.Bank += (value * 2);
                house.Bank -= value;
            }
            else
            {
                house.Bank += value;
                player.Bank -= value;
            }
        }

        public void InitBank(int value)
        {
            player.Bank = value;
            house.Bank += value * 5;
        }

        public void SetHouseBank()
        {
            house.Bank = player.Bank * 10;
        }

        public void SetWin(bool value)
        {
            player.Win = value;
            house.Win = !value;
        }

        public int RollPoint()
        {
            return roll.RollPoint;
        }

        public string GetPoints(int type)
        {
            if (type == 0)
            {
                return player.Points.ToString();
            }
            else
                return house.Points.ToString();
        }

        public void ResetRollPoint()
        {
            roll.RollPoint = 0;
            roll.PointActive = false;
        }

        public bool CheckBet()
        {
            return player.Bank - this.Bet >= 0;
        }
    }
}
