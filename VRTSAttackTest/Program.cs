using System;


namespace VRTSAttackTest
{
    class Program
    {
        public enum SIGN { Rock, Paper, Scissor, Lizard, Spock };

        static void Main(string[] args)
        {
            Mech[] Players = new Mech[5];
            Mech[] Enemies = new Mech[5];

            float[,] SignModifier = new float[5, 5]
            {
                { 1.0f,     1.25f,  0.85f,  1.25f,  0.85f },
                { 0.85f,    1.0f,   1.25f,  1.25f,  0.85f },
                { 1.25f,    0.85f,  1.0f,   0.85f,  1.25f },
                { 1.25f,    0.85f,  1.25f,  1.0f,   0.85f },
                { 0.85f,    1.25f,  1.25f,  0.85f,  1.0f    }
            };

            float[,] LevelModifier = new float[5, 5]
            {
                { 1.0f,     1.15f,  1.3f,   1.5f,   1.6f  },
                { 0.85f,    1.0f,   1.15f,  1.3f,   1.5f  },
                { 0.6f,     0.85f,  1.0f,   1.15f,  1.3f  },
                { 0.5f,     0.6f,   0.85f,  1.0f,   1.15f },
                { 0.3f,     0.5f,   0.6f,   0.85f,  1.0f  }
            };

            //0.3f, 0.5f, 0.6f, 0.85f, 1.0f, 1.15f, 1.3f, 1.5f

            #region Refactor code
            //DisplayStatus(Players[0], Enemies);
            //Console.WriteLine("");
            //Attack(Players[0], Enemies);
            //Console.WriteLine();
            //DisplayStatus(Players[0], Enemies);

            /*
            foreach (var player in Players)
            {
                //Confrim initialisation
                DisplayStatus(player, Enemies);
                Console.WriteLine();
                //Attack each enemy
                Attack(player, Enemies);
                Console.WriteLine();
                //Review Changes
                DisplayStatus(player, Enemies);
                Console.WriteLine("\n\n");
                Console.WriteLine("Next Player");
                ResetEnemies(Enemies);
            }
            */
            #endregion

            float GetSignModifier(int AttackIndex, int DefendIndex)
            {
                return SignModifier[AttackIndex, DefendIndex];
            }

            float GetLevelModifier(int AttackIndex, int DefendIndex)
            {
                return LevelModifier[AttackIndex, DefendIndex];
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    SetupPlayer(Players, i + 1);
                    //Initialise Enemies
                    SetupEnemies(Enemies, j + 1);
                    foreach (Mech player in Players)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Next Player");
                        DisplayStatus(player, Enemies);
                        Attack(player, Enemies);
                        DisplayStatus(player, Enemies);
                        ResetEnemies(Enemies);
                    }
                }
            }

            Console.ReadKey();
        }

        static void SetupPlayer(Mech[] players, int level)
        {
            //Initialise Players
            players[0] = new Mech("Player1", new Element(SIGN.Rock), 100, 50, false, level);
            players[1] = new Mech("Player2", new Element(SIGN.Paper), 100, 50, false, level);
            players[2] = new Mech("Player3", new Element(SIGN.Scissor), 100, 50, false, level);
            players[3] = new Mech("Player4", new Element(SIGN.Lizard), 100, 50, false, level);
            players[4] = new Mech("Player5", new Element(SIGN.Spock), 100, 50, false, level);

        }

        static void SetupEnemies(Mech[] enemies, int level)
        {
            enemies[0] = new Mech("Enemy1", new Element(SIGN.Rock), 100, 50, true, level);
            enemies[1] = new Mech("Enemy2", new Element(SIGN.Paper), 100, 50, true, level);
            enemies[2] = new Mech("Enemy3", new Element(SIGN.Scissor), 100, 50, true, level);
            enemies[3] = new Mech("Enemy4", new Element(SIGN.Lizard), 100, 50, true, level);
            enemies[4] = new Mech("Enemy5", new Element(SIGN.Spock), 100, 50, true, level);
        }

        static void Attack(Mech player, Mech[] enemies)
        {
            foreach (var enemy in enemies)
            {
                player.AttackModifier = 1  * player.LevelModifier(enemy) * player.MyElement.SignModifier(enemy.MyElement.mySign);
                //Checking each enemy emelent against player's sign
                enemy.HealthPoints -= (player.AttackPower *
                                        player.AttackModifier);
                Console.WriteLine("{0} attacks {1} with modifier {2}", player.Name, enemy.Name, player.AttackModifier);
                player.AttackModifier = 1.0m;
            }
        }

        static void AttackTest(Mech player, Mech[] enemies)
        {
            DisplayStatus(player, enemies);
            Attack(player, enemies);
            DisplayStatus(player, enemies);
        }

        static void ResetEnemies(Mech[] enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.HealthPoints = 100;
            }
        }

        static void DisplayStatus(Mech displayMe, Mech[] enemies)
        {
            Console.WriteLine("Name\t|\tSign\t|\tHP\t| Level\t|\tPlyr AP");
            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine(displayMe.ToString());
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (var enemy in enemies)
            {
                Console.WriteLine(enemy.ToString());
                //Console.WriteLine("|\t{0}", displayMe.AttackModifier);
            }
        }


        //element may be thought of as 'type' of mech.
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

        public class Mech
        {
            public string Name { get; set; }
            public Element MyElement { get; set; }
            public decimal HealthPoints { get; set; }
            public decimal AttackPower { get; set; }
            public decimal AttackModifier { get; set; }
            public bool IsEnemy { get; set; }
            public int Level { get; set; }

            public Mech(string name, Element myElement, decimal healthPoints, decimal attackPoints, bool isEnemy, int level)
            {
                Name = name;
                MyElement = myElement;
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
}
