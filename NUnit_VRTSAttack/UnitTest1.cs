using NUnit.Framework;
using VRTSAttackTest;

namespace NUnit_VRTSAttack
{
    public class Tests
    {
        Mech m1;
        [SetUp]
        public void Setup()
        {
            m1 = new Mech("Mech1", new Element(Program.SIGN.Rock), 100, 100, false, 1);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public void TestLevelModifier(int AttackIndex, int DefendIndex)
        {
            
        }
    }
}