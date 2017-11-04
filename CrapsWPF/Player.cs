using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsWPF
{
    class Player
    {
        private int points;
        private int bank;
        private bool win;

        public Player()
        {
            Points = 0;
            Bank = 0;
            Win = false;
        }

        public Player(int bank)
        {
            Points = 0;
            Win = false;
            if (bank >= 0)
                Bank = bank;
            else
                throw new ArgumentException("Bank value can not be negative");
        }

        public int Points { get => points; set => points = value; }
        public int Bank { get => bank; set => bank = value; }
        public bool Win { get => win; set => win = value; }

    }
}
