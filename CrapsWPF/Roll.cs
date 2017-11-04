using System;
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
            return false;
        }

    }
}
