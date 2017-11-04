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
            dice1 = new Dice();
            dice2 = new Dice();
            player = new Player();
            house = new Player();
            roll = new Roll();
            Bet = 0;
            DiceTotal = 0;
            GameOver = false;
        }

        public Game(int bank)
        {
            dice1 = new Dice();
            dice2 = new Dice();
            try
            {
                player = new Player(bank);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(Application.Current.MainWindow, "Player Bank", "Player Bank can not be negative.\nStarting Player Bank at $10000.\n('cause I'm a nice guy)");
            }
            
            house = new Player();
            roll = new Roll();
            Bet = 0;
            DiceTotal = 0;
            GameOver = false;
        }

        public int Bet { get => this.bet; set => this.bet = value; }
        public int DiceTotal { get => this.diceTotal; set => this.diceTotal = value; }
        public bool GameOver { get => this.gameOver; set => this.gameOver = value; }



    }
}
