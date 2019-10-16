using System;
using System.Collections.Generic;
using System.Text;

namespace VRTSAttackTest
{
    class Unit
    {
        public double HP { get; set; }
        public double Attack { get; set; }
        public double AttackModifier { get; set; }

        public enum UnitType
        {
            Rock,
            Paper,
            Scissors,
            Lizard,
            Spock
        }


    }
}
