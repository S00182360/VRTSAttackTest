﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VRTS_AttackTest2.Program;

namespace VRTS_AttackTest2
{
    public class Mech
    {
        public string Name { get; set; }
        public SIGN MySign { get; set; }
        public float HealthPoints { get; set; }
        public float AttackPower { get; set; }
        public float AttackModifier { get; set; }
        public bool IsEnemy { get; set; }
        public int Level { get; set; }

        public Mech(string name, SIGN mySign, int level)
        {
            Name = name;
            MySign = mySign;
            HealthPoints = 100;
            AttackPower = 1;
            IsEnemy = false;
            Level = level;
            AttackModifier = 1.0f;
        }


        public float GetSignModifier(int AttackIndex, int DefendIndex)
        {
            //return SignModifier[AttackIndex, DefendIndex];
            return SignModifier[DefendIndex, AttackIndex];

        }

        //BE AWARE: Level stores as non-zerio int 1-5
        //Index for array will be (Level - 1)
        public float GetLevelModifier(int AttackIndex, int DefendIndex)
        {
            //return LevelModifier[AttackIndex, DefendIndex];
            return LevelModifier[DefendIndex, AttackIndex];
        }


        public float Attack(Mech me, Mech enemy)
        {
            me.AttackModifier = GetLevelModifier(me.Level - 1, enemy.Level - 1) * GetSignModifier((int)me.MySign, (int)enemy.MySign);
            enemy.HealthPoints -= me.AttackPower * me.AttackModifier;
            return enemy.HealthPoints;

        }
    }
}
