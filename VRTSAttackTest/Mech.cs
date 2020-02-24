using static VRTSAttackTest.Program;

namespace VRTSAttackTest
{
    public class Mech
    {
        public string Name { get; set; }
        public Element MyElement { get; set; }
        public SIGN MySign { get; set; }
        public decimal HealthPoints { get; set; }
        public decimal AttackPower { get; set; }
        public decimal AttackModifier { get; set; }
        public bool IsEnemy { get; set; }
        public int Level { get; set; }

        public Mech(string name, Element myElement, decimal healthPoints, decimal attackPoints, bool isEnemy, int level)
        {
            Name = name;
            MyElement = myElement;
            MySign = myElement.mySign;
            HealthPoints = healthPoints;
            AttackPower = attackPoints;
            IsEnemy = isEnemy;
            Level = level;
            AttackModifier = 1.0m;
        }

        public decimal LevelModifier(Mech enemy)
        {
            switch (Level)
            {
                case 1:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 0.85m;
                        case 3:
                            return 0.6m;
                        case 4:
                            return 0.5m;
                        default:
                            return 0.3m;
                    }
                case 2:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.15m;
                        case 2:
                            return 1m;
                        case 3:
                            return 0.85m;
                        case 4:
                            return 0.6m;
                        default:
                            return 0.5m;
                    }
                case 3:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.3m;
                        case 2:
                            return 1.15m;
                        case 3:
                            return 1m;
                        case 4:
                            return 0.85m;
                        default:
                            return 0.6m;
                    }
                case 4:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.5m;
                        case 2:
                            return 1.3m;
                        case 3:
                            return 1.15m;
                        case 4:
                            return 1m;
                        default:
                            return 0.85m;
                    }
                case 5:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.6m;
                        case 2:
                            return 1.5m;
                        case 3:
                            return 1.3m;
                        case 4:
                            return 1.15m;
                        default:
                            return 1m;
                    }
                default:
                    return 1;
            }
        }

        //ToString override to display needed info
        public override string ToString()
        {
            return string.Format("{0}\t|\t{1}\t|\t{2}\t|\t{3}", Name, MyElement.ToString(), HealthPoints, Level);
        }

        #region Refactored Code
        /*
        public decimal LevelModifier(Mech enemy)
        {

            switch (Level)
            {
                case 1:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1m;
                        case 2:
                            return 0.85m;
                        case 3:
                            return 0.6m;
                        case 4:
                            return 0.5m;
                        case 5:
                            return 0.3m;
                        default:
                            return 1;
                    }
                case 2:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.15m;
                        case 2:
                            return 1m;
                        case 3:
                            return 0.85m;
                        case 4:
                            return 0.6m;
                        case 5:
                            return 0.5m;
                        default:
                            return 1;
                    }
                case 3:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.3m;
                        case 2:
                            return 1.15m;
                        case 3:
                            return 1m;
                        case 4:
                            return 0.85m;
                        case 5:
                            return 0.6m;
                        default:
                            return 1;

                    }
                case 4:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.5m;
                        case 2:
                            return 1.3m;
                        case 3:
                            return 1.15m;
                        case 4:
                            return 1m;
                        case 5:
                            return 0.85m;
                        default:
                            return 1;

                    }
                case 5:
                    switch (enemy.Level)
                    {
                        case 1:
                            return 1.6m;
                        case 2:
                            return 1.5m;
                        case 3:
                            return 1.3m;
                        case 4:
                            return 1.15m;
                        case 5:
                            return 1m;
                        default:
                            return 1;
                    }
                default:
                    return 1;
            }
        }*/

        #endregion
    }
}
