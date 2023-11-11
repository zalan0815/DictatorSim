using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Game
{
    class FightSystem
    {
        private Player player;
        private Enemy enemy;
        private int round;
        private int subRound;
        private Character[] fightOrder = new Character[2];

        private Random random = new Random();

        private int x;
        private int y;
        private int xMax;
        private int yMax;


        private int spawnedEnemyId;
        private bool lostDeffence;

        public FightSystem(Player player, Enemy enemy, out bool Victory)
        {
            this.player = player;
            this.enemy = enemy;
            int r = random.Next(0, 2);
            int r2 = r == 0 ? 1 : 0; 

            fightOrder[r] = player;
            fightOrder[r2] = enemy;

            Console.Clear();
            Victory = Fight();
        }

        struct EnemyAttack
        {
            public int X { get; set; }
            public int Y { get; set; }
            public char Char { get; set; }
            public int Round { get; set; }
            public bool Defeated { get; set; }
        }

        private bool Fight()
        {
            round = 0;
            subRound = 0;

            while (enemy.Health > 0 && player.Health > 0)
            {
                writeFight();

                attackOf(fightOrder[subRound]);
                if (subRound > 0)
                {
                    subRound = 0;
                    round++;
                }
                else { subRound++; }

                //Console.ReadKey(true);
                Thread.Sleep(800);
                Console.Clear();
            }
            return enemy.Health == 0;
        }

        private void attackOf(Character c)
        {
            if (c == player)
            {
                #region WRITE
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TE TÁMADSZ");
                Console.ForegroundColor = ConsoleColor.White;

                #endregion
                playerAttack();
            }
            else
            {
                #region WRITE
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{enemy.Name} TÁMAD");
                Console.ForegroundColor = ConsoleColor.White;

                #endregion
                enemyAttack();
                if (lostDeffence)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = 0;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");
                    Console.WriteLine("ELVESZTETTED A KÖRT");

                }
                

            }
        }

        private void playerAttack()
        {

        }

        private void enemyAttack()
        {
            int enemyAttacks = 2 + round / 2;
            int maxEnemyAttacks = 15;

            spawnedEnemyId = 0;
            lostDeffence = false;

            int waitMin = 300;
            int waitMax = 700;

            EnemyAttack[] spawnList = new EnemyAttack[enemyAttacks];

            #region GENERATE LOCATIONS FOR A ROUND
            for (int i = 0; i < enemyAttacks; i++)
            {
                if (i >= maxEnemyAttacks)
                {
                    break;
                }

                int rX, rY;
                do
                {
                    rX = random.Next(0, xMax);
                    rY = random.Next(y, yMax);
                }
                while (isEnemyCloseToSpawn(spawnList, rX, rY));

                spawnList[i] = new EnemyAttack() { X = rX, Y = rY, Char = 'a', Round = round };
                
            }
            #endregion

            spawnEnemyAttacks(spawnList, waitMin, waitMax);

            while (spawnedEnemyId < spawnList.Length)
            {
                char input = Console.ReadKey(true).KeyChar;
                bool foundChar = false;
                for(int i = 0; i < spawnedEnemyId; i++)
                {
                    if (spawnList[i].Char == input)
                    {
                        foundChar = true;
                        spawnList[i].Defeated = true;
                        break;
                    }
                }
                if (!foundChar)
                {
                    lostDeffence = true;
                    return; //vesztett: rosszat nyomott le
                }
                
            }
        }

        private bool isEnemyCloseToSpawn(EnemyAttack[] spawnLocations, int rX, int rY)
        {
            foreach (EnemyAttack spawnLocation in spawnLocations)
            {
                if (Math.Abs(spawnLocation.X - rX) < 4 && Math.Abs(spawnLocation.Y - rY) < 4)
                {
                    return true;
                }
            }
            return false;
        }

        private async Task spawnEnemyAttacks(EnemyAttack[] enemyAttacks, int waitMin, int waitMax)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < enemyAttacks.Length;i++)
                {
                    if (lostDeffence)
                    {
                        break;
                    }

                    if (round == enemyAttacks[i].Round)
                    {
                        Console.CursorLeft = enemyAttacks[i].X;
                        Console.CursorTop = enemyAttacks[i].Y;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("X");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    
                    if (i < enemyAttacks.Length - 1)
                    {
                        Task.Delay(random.Next(waitMin,waitMax)).Wait();
                        if (lostDeffence)
                        {
                            break;
                        }
                    }
                    spawnedEnemyId = i;
                }
                spawnedEnemyId = enemyAttacks.Length;
            });
        }

        public void writeFight()
        {
            #region TOP-LEFT REGION
            Console.Write($"Ellenfeled: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{enemy.Name}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{round+1}. kör ({subRound+1}. fele): ");


            x = Console.CursorLeft;
            y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 2;
            Console.CursorLeft = 0;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{enemy.Name} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("életereje:");
            #endregion

            #region ENEMY'S HEALTH
            string enemyHealthText = $"{enemy.Health} / {enemy.MaxHealth}";
            int enemyHealthSize = (int)(Console.WindowWidth * ((float)enemy.Health / enemy.MaxHealth));
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            while (count < enemyHealthText.Length)
            {
                if (count > enemyHealthSize)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write(enemyHealthText[count]);

                count++;
            }
            if (count < enemyHealthSize)
            {
                Console.Write(new string(' ', enemyHealthSize - count));
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            #endregion

            #region YOUR STATS
            int longest = "életerőd".Length;
            foreach (Item item in player.Items)
            {
                if(longest < item.WriteItemStat(true, false))
                {
                    longest = item.WriteItemStat(true, false);
                }
            }
            longest = longest >= $"{player.Health} / {player.MaxHealth}".Length ? longest : $"{player.Health} / {player.MaxHealth}".Length;

            Console.CursorLeft = Console.WindowWidth - longest - 1;
            Console.CursorTop = 0;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Életerőd");
            Console.CursorLeft = Console.WindowWidth - longest - 1;
            Console.CursorTop += 1;
            Console.Write($"{player.Health} / {player.MaxHealth}");
            Console.CursorTop += 1;
            foreach (Item item in player.Items)
            {
                Console.CursorLeft = Console.WindowWidth - longest - 1;
                Console.CursorTop += 1;
                item.WriteItemStat(true);
            }
            #endregion

            enemy.Health -= 1;

            xMax = Console.WindowWidth - longest - 2;
            yMax = Console.WindowHeight - 3;

            Console.CursorLeft = x;
            Console.CursorTop = y;
            y += 1;
        }
    }
}
