using System;


namespace VRTSAttackTest
{
    public class Program
    {
        public enum SIGN { Rock, Paper, Scissor, Lizard, Spock };

        static void Main(string[] args)
        {
            Mech[] Players = new Mech[5];
            Mech[] Enemies = new Mech[5];
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

        public static void SetupPlayer(Mech[] players, int level)
        {
            //Initialise Players
            players[0] = new Mech("Player1", new Element(SIGN.Rock), 100, 50, false, level);
            players[1] = new Mech("Player2", new Element(SIGN.Paper), 100, 50, false, level);
            players[2] = new Mech("Player3", new Element(SIGN.Scissor), 100, 50, false, level);
            players[3] = new Mech("Player4", new Element(SIGN.Lizard), 100, 50, false, level);
            players[4] = new Mech("Player5", new Element(SIGN.Spock), 100, 50, false, level);

        }

        public static void SetupEnemies(Mech[] enemies, int level)
        {
            enemies[0] = new Mech("Enemy1", new Element(SIGN.Rock), 100, 50, true, level);
            enemies[1] = new Mech("Enemy2", new Element(SIGN.Paper), 100, 50, true, level);
            enemies[2] = new Mech("Enemy3", new Element(SIGN.Scissor), 100, 50, true, level);
            enemies[3] = new Mech("Enemy4", new Element(SIGN.Lizard), 100, 50, true, level);
            enemies[4] = new Mech("Enemy5", new Element(SIGN.Spock), 100, 50, true, level);
        }

        public static void Attack(Mech player, Mech[] enemies)
        {
            foreach (var enemy in enemies)
            {
                player.AttackModifier = 1 * player.LevelModifier(enemy) * player.MyElement.SignModifier(enemy.MyElement.mySign);
                //Checking each enemy emelent against player's sign
                enemy.HealthPoints -= (player.AttackPower *
                                        player.AttackModifier);
                Console.WriteLine("{0} attacks {1} with modifier {2}", player.Name, enemy.Name, player.AttackModifier);
                player.AttackModifier = 1.0m;
            }
        }

        public static void AttackTest(Mech player, Mech[] enemies)
        {
            DisplayStatus(player, enemies);
            Attack(player, enemies);
            DisplayStatus(player, enemies);
        }

        public static void ResetEnemies(Mech[] enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.HealthPoints = 100;
            }
        }

        public static void DisplayStatus(Mech displayMe, Mech[] enemies)
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
    }
}
