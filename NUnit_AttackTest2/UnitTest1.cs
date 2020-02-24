using NUnit.Framework;
using VRTS_AttackTest2;

namespace NUnit_AttackTest2
{
    public class Tests
    {
        Mech M1;
        [SetUp]
        public void Setup()
        {
            M1 = new Mech("Player", SIGN.Rock, 1);
        }


        /*
         Test cases:
         Attacking level 1, Defending 1, 3, 5
         Attacking level 3, Defending 1, 3, 5
         Attacking level 5, Defending 1, 3, 5
        */
        [TestCase(1f, 0, 0)]
        [TestCase(0.6f, 0, 2)]
        [TestCase(0.3f, 0, 4)]
        [TestCase(1.3f, 2, 0)]
        [TestCase(1f, 2, 2)]
        [TestCase(0.6f, 2, 4)]
        [TestCase(1.6f, 4, 0)]
        [TestCase(1.3f, 4, 2)]
        [TestCase(1f, 4, 4)]
        public void Test1(float LevelModifier, int AttackIndex, int DefendIndex)
        {
            Assert.AreEqual(LevelModifier, M1.GetLevelModifier(AttackIndex, DefendIndex));
        }


        public void TestSignModifier(float result, SIGN AttackSign, SIGN DefendSign)
        {
            Assert.AreEqual(result, M1.GetSignModifier((int)AttackSign, (int)DefendSign));
        }
    }
}