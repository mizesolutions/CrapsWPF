using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrapsWPF
{
    class Game
    {
        private Dice dice1, dice2;
        private Player player, house;
        private Roll roll;
        private int bet, diceTotal;
        private bool gameOver;

        public Game()
        {
            dice1 = new Dice((int)DateTime.Now.Ticks + 1002);
            dice2 = new Dice((int)DateTime.Now.Ticks - 77);
            player = new Player();
            house = new Player();
            roll = new Roll();
            Bet = 0;
            DiceTotal = 0;
            GameOver = false;
        }

        public Game(int bank)
        {
            dice1 = new Dice((int)DateTime.Now.Ticks -3301);
            dice2 = new Dice((int)DateTime.Now.Ticks + 42);
            try
            {
                player = new Player(bank);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(Application.Current.MainWindow, "Player Bank", e + "\nStarting Player Bank at $10000.\n('cause I'm a nice guy)");
            }
            house = new Player(bank*10);
            roll = new Roll();
            Bet = 0;
            DiceTotal = 0;
            GameOver = false;
        }

        public int Bet { get => this.bet; set => this.bet = value; }
        public int DiceTotal { get => this.diceTotal; set => this.diceTotal = value; }
        public bool GameOver { get => this.gameOver; set => this.gameOver = value; }

        public void RollDice()
        {
            dice1.RollDice();
            dice2.RollDice();
            DiceTotal = dice1.Value + dice2.Value;
        }

        public bool CheckRoll()
        {
            if (roll.CheckRoll(this))
            {
                return true;
            }
            else
            {
                GameOver = true;
                return false;
            }
                
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
            {
                return dice1.Value.ToString();
            }
            else
                return dice2.Value.ToString();
        }

        public void SetPoints(int type)
        {
            if (type == 0)
            {
                player.Points += 1;
            }
            else
                house.Points += 1;
        }

        public void SetBank(int type, int value)
        {
            if(type == 0)
            {
                player.Bank += value;
                house.Bank -= value;
            }
            else
            {
                house.Bank += value;
                player.Bank -= value;
            }
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
