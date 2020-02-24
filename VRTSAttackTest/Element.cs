using System;
using static VRTSAttackTest.Program;

namespace VRTSAttackTest
{
    public class Element
    {
        Random rand = new Random();
        public SIGN mySign;

        //Ctor for assigning a random SIGN
        public Element()
        {
            mySign = RandomSign();
        }

        //Ctor for assigning specific SIGN
        public Element(SIGN thisSign)
        {
            mySign = thisSign;
        }

        //Method to return random SIGN
        public SIGN RandomSign()
        {
            int signAssign = rand.Next(0, 5);

            switch (signAssign)
            {
                case 0:
                    return SIGN.Rock;
                case 1:
                    return SIGN.Paper;
                case 2:
                    return SIGN.Scissor;
                case 3:
                    return SIGN.Lizard;
                default:
                    return SIGN.Spock;
            }
        }

        /// <summary>
        ///  //Damage based on Sign
        ///  Main method that returns a damage modifier 
        ///     based on each sign as in 
        ///     Rock, Paper, Scissor, Lizard, Spock
        ///     See emthod spec for full ruleset
        /// </summary>
        public decimal SignModifier(SIGN enemySign)
        {
            return mySign switch
            {
                SIGN.Rock => enemySign switch
                {
                    SIGN.Rock => 1.0m,//Draw
                    SIGN.Paper => 0.75m,//Loose
                    SIGN.Scissor => 1.25m,//Win
                    SIGN.Lizard => 1.25m,//Win
                    SIGN.Spock => 0.75m,//Loose
                    _ => 0,
                },
                SIGN.Paper => enemySign switch
                {
                    SIGN.Rock => 1.25m,//Win
                    SIGN.Paper => 1.0m,//Draw
                    SIGN.Scissor => 0.75m,//Loose
                    SIGN.Lizard => 0.75m,//Loose
                    SIGN.Spock => 1.25m,//Draw
                    _ => 0,
                },
                SIGN.Scissor => enemySign switch
                {
                    SIGN.Rock => 0.75m,//Loose
                    SIGN.Paper => 1.25m,//Win
                    SIGN.Scissor => 1.0m,//Draw
                    SIGN.Lizard => 1.25m,//Win
                    SIGN.Spock => 0.75m,//Loose
                    _ => 0,
                },
                SIGN.Lizard => enemySign switch
                {
                    SIGN.Rock => 0.75m,//Loose
                    SIGN.Paper => 1.25m,//Win
                    SIGN.Scissor => 0.75m,//Loose
                    SIGN.Lizard => 1.0m,//Draw
                    SIGN.Spock => 1.25m,//Win
                    _ => 0,
                },
                SIGN.Spock => enemySign switch
                {
                    SIGN.Rock => 1.25m,//Win 
                    SIGN.Paper => 0.75m,//Loose
                    SIGN.Scissor => 1.25m,//Win
                    SIGN.Lizard => 0.75m,//Loose
                    SIGN.Spock => 1.0m,//Draw
                    _ => 0,
                },
                _ => 0,
            };
        }

        public override string ToString()
        {
            return mySign.ToString();
        }
    }
}
