using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsWPF
{
    class Dice
    {
        private Random rand;
        private int value;
        

        public Dice()
        {
            rand = new Random();
            Value = 0;
        }

        public int Value { get => value; set => this.value = value; }

        public void RollDice()
        {
            Value = rand.Next(1, 7);
        }
    }
}
