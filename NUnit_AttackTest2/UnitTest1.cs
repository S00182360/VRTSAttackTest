using NUnit.Framework;
using VRTS_AttackTest2;

namespace NUnit_AttackTest2
{
    public class Tests
    {
        public Mech P1;
        Mech P2;
        Mech P3;

        Mech E1;
        Mech E2;
        Mech E3;

        [SetUp]
        public void Setup()
        {
            P1 = new Mech("Player_1", SIGN.Rock, 1);
            P2 = new Mech("Player_2", SIGN.Paper, 3);
            P3 = new Mech("Player_3", SIGN.Spock, 5);

            E1 = new Mech("Enemy_1", SIGN.Scissor, 2);
            E2 = new Mech("Enemy_2", SIGN.Lizard, 4);
            E3 = new Mech("Enemy_3", SIGN.Rock, 1);
        }


        /*****************************************
             Test cases:
             Attacking level 1, Defending 1, 3, 5
             Attacking level 3, Defending 1, 3, 5
             Attacking level 5, Defending 1, 3, 5
        ******************************************/
        [TestCase(1f, 0, 0)]
        [TestCase(0.6f, 0, 2)]
        [TestCase(0.3f, 0, 4)]
        [TestCase(1.3f, 2, 0)]
        [TestCase(1f, 2, 2)]
        [TestCase(0.6f, 2, 4)]
        [TestCase(1.6f, 4, 0)]
        [TestCase(1.3f, 4, 2)]
        [TestCase(1f, 4, 4)]
        public void TestLevelModifier(float LevelModifier, int AttackIndex, int DefendIndex)
        {
            Assert.AreEqual(LevelModifier, P1.GetLevelModifier(AttackIndex, DefendIndex));
        }


        /*******************************************************
             Test cases:
             Attacking: Rock,       Defending: Win, Loose, Draw
             Attacking: Paper,      Defending: Win, Loose, Draw
             Attacking: Scissor,   Defending: Win, Loose, Draw
             Attacking: Lizard,     Defending: Win, Loose, Draw
             Attacking: Spock,      Defending: Win, Loose, Draw
         ********************************************************/
        [TestCase(1f, SIGN.Rock, SIGN.Rock)]
        [TestCase(0.85f, SIGN.Rock, SIGN.Paper)]
        [TestCase(1.25f, SIGN.Rock, SIGN.Lizard)]
        [TestCase(1f, SIGN.Paper, SIGN.Paper)]
        [TestCase(1.25f, SIGN.Paper, SIGN.Rock)]
        [TestCase(0.85f, SIGN.Paper, SIGN.Scissor)]
        [TestCase(1f, SIGN.Scissor, SIGN.Scissor)]
        [TestCase(1.25f, SIGN.Scissor, SIGN.Lizard)]
        [TestCase(0.85f, SIGN.Scissor, SIGN.Spock)]
        [TestCase(1f, SIGN.Lizard, SIGN.Lizard)]
        [TestCase(1.25f, SIGN.Lizard, SIGN.Paper)]
        [TestCase(0.85f, SIGN.Lizard, SIGN.Scissor)]
        [TestCase(1f, SIGN.Spock, SIGN.Spock)]
        [TestCase(1.25f, SIGN.Spock, SIGN.Rock)]
        [TestCase(0.85f, SIGN.Spock, SIGN.Paper)]
        public void TestSignModifier(float result, SIGN AttackSign, SIGN DefendSign)
        {
            Assert.AreEqual(result, P1.GetSignModifier((int)AttackSign, (int)DefendSign));
        }
    }
}