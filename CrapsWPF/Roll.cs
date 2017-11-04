﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsWPF
{
    class Roll
    {
        private int rollPoint;
        private bool pointActive;

        public Roll()
        {
            RollPoint = 0;
            PointActive = false;
        }

        public int RollPoint { get => rollPoint; set => this.rollPoint = value; }
        public bool PointActive { get => pointActive; set => this.pointActive = value; }

        public bool CheckRoll(Game game)
        {
            if(!PointActive)
            {
                return RegularRoll(game);
            }
            else
                return PointRoll(game);
        }

        private bool RegularRoll(Game game)
        {
            if (game.DiceTotal != 2 || game.DiceTotal != 3 || game.DiceTotal != 7 || game.DiceTotal != 11 || game.DiceTotal != 12)
            {
                RollPoint = game.DiceTotal;
                return PointActive = true;
            }
            else if (game.DiceTotal == 7 || game.DiceTotal == 11)
            {
                return PlayerWin(game);
            }
            else
                return HouseWin(game);
        }

        private bool PointRoll(Game game)
        {
            if (game.DiceTotal != RollPoint && game.DiceTotal != 7)
            {
                return true;
            }
            else if (game.DiceTotal == RollPoint)
            {
                return PlayerWin(game);
            }
            else
                return HouseWin(game);
        }

        private bool PlayerWin(Game game)
        {
            game.SetPoints(0);
            game.SetBank(0, game.Bet);
            game.SetWin(true);
            return false;
        }

        private bool HouseWin(Game game)
        {
            game.SetPoints(1);
            game.SetBank(1, game.Bet);
            game.SetWin(false);
            return false;
        }


    }
}
