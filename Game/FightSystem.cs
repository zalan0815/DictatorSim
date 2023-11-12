using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

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

        private char[] charsToSpawn =         { 'A', 'Q', 'W', 'E' };
        private string[] charsToSpawnSring =  { "A", "Q", "W", "E" };

        private Stopwatch stopwatch;

        private int sliderPostion;
        private int yTop = 5;

        public FightSystem(Player player, Enemy enemy, out bool Victory)
        {
            this.player = player;
            this.enemy = enemy;
            int r = random.Next(0, 2);
            int r2 = r == 0 ? 1 : 0; 

            fightOrder[r] = player;
            fightOrder[r2] = enemy;

            Console.Clear();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            Victory = Fight();
        }

        struct EnemyAttack
        {
            public int ID { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public char Char { get; set; }
            public int Round { get; set; }
            public bool Defeated { get; set; }
            public long spawnTime { get; set; }
            public int howLongTillSpawn { get; set; }
            
            public List<Coordinate> coordinates { get; set; } //Mellette lévő színezett mezők coordinátái, színei
        }

        EnemyAttack[] spawnList;

        struct Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
            public ConsoleColor Color { get; set; }
        }

        struct Attack
        {
            public int X { set; get; }
            public ConsoleColor Color { get; set; }
            public double DamageMarkiplier { get; set; }
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
                enemyAttack(out int EnemyAttacks, out int defated);
                string textToWrite;
                string statToWrite = $"{defated} / {EnemyAttacks}";
                if (lostDeffence)
                {
                    textToWrite = "SIKERTELEN VÉDEKEZÉS";
                    for (int i = 0; i < EnemyAttacks - defated; i++)
                    {
                        player.Health -= enemy.Damage;
                        writeEndOfSubRound(textToWrite, statToWrite);

                        writeFight(yellowHealth: i % 2 == 0);
                        Thread.Sleep(random.Next(100,200));
                    }
                    
                    
                }
                else
                {
                    textToWrite = "SIKERES VÉDEKEZÉS";
                    writeEndOfSubRound(textToWrite, statToWrite);
                }

            }
        }
        #region PLAYER_ATTACK
        private void playerAttack()
        {
            printAttackMapBase();
            Attack[] attackMap = generateMap();
            printAttackMap(attackMap);
        }

        private void printAttackMapBase()
        {

            Console.BackgroundColor = ConsoleColor.White;

            Console.CursorLeft = 0;
            Console.CursorTop = yTop;
            Console.Write(new string(' ', xMax) );

            Console.CursorLeft = 0;
            Console.CursorTop = yMax;
            Console.Write(new string(' ', xMax) );

            for (int i = 0; i < yMax - yTop + 1; i++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = yTop + i;
                Console.Write(" ");
                Console.CursorLeft = xMax;
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;

        }

        private Attack[] generateMap()
        {
            int mapSize = xMax - 1;
            int xGreenSpot = random.Next(mapSize + 2 - player.SliderSpeed); //+1, mert excludive, +1, mert 1 az alap player stat, ez a pont a bal oldali GreenSpot helye, ehhez hozzáadva jön a (játékos statja - 1) jobb oldali
            int xGreenSpotRight = xGreenSpot + player.SliderSpeed - 1;
            /* MapSize (exc. GreenSpots):
             * 25% - 0%      dmg    - DarkRed
             * 45% - 10%-25% dmg    - Red
             * 30% - 50%-90% dmg    - Yellow
             
             */
            Attack[] attackMap = new Attack[mapSize];
            int count = 0;


            while (count < mapSize)
            {
                attackMap[count] = new Attack() { X = count };
                if(count >= xGreenSpot && count <= xGreenSpot + player.SliderSpeed - 1)
                {
                    attackMap[count].Color = ConsoleColor.Green;
                    attackMap[count].DamageMarkiplier = 1.2;
                }
                else
                {
                    double ratio = 0;

                    if (count < xGreenSpot)
                    {
                        ratio = (double)count / xGreenSpot;

                    }
                    else
                    {
                        ratio = 1 - ((double)count - xGreenSpotRight) / (mapSize - 1 - xGreenSpotRight);

                    }

                    if (ratio < .25)
                    {
                        attackMap[count].Color = ConsoleColor.DarkRed;
                        attackMap[count].DamageMarkiplier = .0;
                    }
                    else if (ratio < .70)
                    {
                        double maxDamageClosenessMarkiplier = (ratio - .25) / (.70 - .25);       //.70 => 1, .50 => 0.555, .25 => 0
                        double minDamageClosenessMarkiplier = 1 - maxDamageClosenessMarkiplier;  //.70 => 0, .50 => 0.445, .25 => 1

                        attackMap[count].Color = ConsoleColor.Red;
                        attackMap[count].DamageMarkiplier = maxDamageClosenessMarkiplier * .25 + minDamageClosenessMarkiplier * .10; //.70 => .25, .50 => (0.555 * .25) + (0.445 * .10) = 0.138 + 0.0445 = 0.1825, .25 => .10
                    }
                    else
                    {
                        double maxDamageClosenessMarkiplier = (ratio - .70) / (1 - .70);         //1 => 1, .85 => 0.5, .70 => 0
                        double minDamageClosenessMarkiplier = 1 - maxDamageClosenessMarkiplier;  //1 => 0, .85 => 0.5, .70 => 1
                        attackMap[count].Color = ConsoleColor.Yellow;
                        attackMap[count].DamageMarkiplier = maxDamageClosenessMarkiplier * .90 + minDamageClosenessMarkiplier * .50; //1 => .90, .85 => (0.5 * .90) + (0.5 * .50) = .45 + .25 = .70, .70 => .50
                    }
                }
                

                count++;
            }
            return attackMap;
        }
        private void printAttackMap(Attack[] attackMap)
        {
            for (int j = 0; j < yMax - yTop - 1; j++)
            {
                for (int i = 0; i < attackMap.Length; i++)
                {
                    Console.CursorLeft = i + 1;
                    Console.CursorTop = yTop + j + 1;
                    Console.BackgroundColor = attackMap[i].Color;

                    Console.Write(" ");
                }
            }
            Console.BackgroundColor= ConsoleColor.Black;
        }

        #endregion

        #region ENEMY_ATTACK
        private void enemyAttack(out int enemyAttacks, out int defeated)
        {
            int maxEnemyAttacks = 15;
            enemyAttacks = 2 + round / 2;

            spawnedEnemyId = 0;
            lostDeffence = false;

            int waitMin = 450;
            int waitMax = 650;

            spawnList = new EnemyAttack[enemyAttacks];

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
                    rX = random.Next(4, xMax - 4);
                    rY = random.Next(9, yMax - 4);
                }
                while (isEnemyCloseToSpawn(spawnList, rX, rY));
                
                spawnList[i] = new EnemyAttack() { X = rX, Y = rY, Char = charsToSpawn[random.Next(0,charsToSpawn.Length)], Round = round, Defeated = false, ID=i};
                
            }
            int howLongTillSpawn = 0;
            for (int i = 0; i < spawnList.Length; i++)
            {
                spawnList[i].howLongTillSpawn = howLongTillSpawn;
                spawnList[i].coordinates = generatePatternForEnemyAttack(spawnList[i].X, spawnList[i].Y);
                spawnEnemyAttacks(i, waitMin, waitMax);


                howLongTillSpawn += random.Next(waitMin, waitMax);
            }
            #endregion

            defeated = 0;
            while (spawnedEnemyId < spawnList.Length || defeated < spawnList.Length)
            {
                while (!Console.KeyAvailable)
                {
                    Task.Delay(300);
                    if (lostDeffence)
                    {
                        return;
                    }
                }
                string input = Console.ReadKey(true).KeyChar.ToString().ToUpper();
                
                bool foundChar = true; // (1)
                for(int i = 0; i < spawnedEnemyId; i++)
                {
                    foundChar = false; // (1) => amikor nem volt még spawnolt elem, de lefutott, elvesztette az ember egyből a kört
                    if (!charsToSpawnSring.Contains(input))
                    {
                        foundChar = true;
                        break;
                    }
                    if (!spawnList[i].Defeated && spawnList[i].Char.ToString() == input)
                    {
                        foundChar = true;
                        spawnList[i].Defeated = true;
                        reColorEnemyAttacks(spawnList[i], ConsoleColor.Green, ConsoleColor.DarkGray);
                        defeated++;
                        break;
                    }
                }
                if (!foundChar)
                {
                    lostDeffence = true;
                    return; //vesztett: rosszat nyomott le
                }
                if (lostDeffence)
                {
                    return;
                }
                
            }
            lostDeffence = false;
            return;
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

        private async Task spawnEnemyAttacks(int id, int waitMin, int waitMax)
        {
            await Task.Run(() =>
            {
                Task.Delay(spawnList[id].howLongTillSpawn).Wait();
                if (lostDeffence || spawnList[id].Round != round)
                {
                    return;
                }

                reColorEnemyAttacks(spawnList[id], ConsoleColor.Black);

                //enemyAttack.spawnTime = stopwatch.ElapsedMilliseconds;
                spawnedEnemyId = spawnList[id].ID+1;

                int maxParts = 3;
                for (int i = 1; i < maxParts + 1; i++)
                {
                    Task.Delay(enemy.Speed / maxParts).Wait();
                    if (lostDeffence || spawnList[id].Round != round || spawnList[id].Defeated)
                    {
                        return;
                    }
                    if (i < 3)
                    {
                        reColorEnemyAttacks(spawnList[id], i % 2 == 1 ? ConsoleColor.Yellow : ConsoleColor.Red, ConsoleColor.DarkGray);
                    }
                    

                }
                if(spawnList[id].Round == round && spawnList[id].Defeated == false)
                {
                    lostDeffence = true;
                }

            });
        }

        private void reColorEnemyAttacks(EnemyAttack enemyAttack, ConsoleColor fgcolor, ConsoleColor bgcolor)
        {
            foreach (Coordinate cord in enemyAttack.coordinates)
            {
                Console.CursorLeft = cord.X;
                Console.CursorTop = cord.Y;
                Console.BackgroundColor = bgcolor;
                Console.ForegroundColor = fgcolor;

                if (cord.X == enemyAttack.X && cord.Y == enemyAttack.Y)
                {
                    Console.Write(enemyAttack.Char.ToString());
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }

        private void reColorEnemyAttacks(EnemyAttack enemyAttack, ConsoleColor fgcolor)
        {
            foreach (Coordinate cord in enemyAttack.coordinates)
            {
                Console.CursorLeft = cord.X;
                Console.CursorTop = cord.Y;
                Console.BackgroundColor = cord.Color;
                Console.ForegroundColor = fgcolor;

                if (cord.X == enemyAttack.X && cord.Y == enemyAttack.Y)
                {
                    Console.Write(enemyAttack.Char.ToString());
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }

        private List<Coordinate> generatePatternForEnemyAttack(int x, int y)
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            for (int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if ((i >= -1) && (i <= 1) && (j >= -1) && (j <= 1))
                    {
                        if (i == 0 && j == 0)
                        {
                            coordinates.Add(new Coordinate { X = x + i, Y = y + j, Color = ConsoleColor.Gray});
                        }
                        else if(random.Next(0,100) < 70)
                        {
                            coordinates.Add(new Coordinate { X = x+i, Y = y+j, Color=ConsoleColor.Gray});
                        }
                    }
                    else
                    {
                        if (random.Next(0, 100) < 0)
                        {
                            coordinates.Add(new Coordinate { X = x+i, Y = y+j, Color=ConsoleColor.Gray});
                        }
                    }
                }
            }
            return coordinates;
        }

        public void writeFight(bool yellowHealth = false)
        {
            x = Console.CursorLeft;
            y = Console.CursorTop;
            Console.CursorLeft = 0;
            Console.CursorTop = 1;

            #region TOP-LEFT REGION
            Console.Write($"Ellenfeled: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{enemy.Name}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{round+1}. kör ({subRound+1}. fele): ");
            #endregion

            #region ENEMY'S HEALTH
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 2;
            Console.CursorLeft = 0;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{enemy.Name} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("életereje:");

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
            if (yellowHealth) { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.Write($"{player.Health} ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"/ {player.MaxHealth}");
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
        private void writeEndOfSubRound(string textToWrite, string statToWrite)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = (Console.WindowWidth - textToWrite.Length) / 2;
            Console.CursorTop = (Console.WindowHeight / 2);
            Console.WriteLine(textToWrite);

            Console.CursorLeft = (Console.WindowWidth - statToWrite.Length) / 2;
            Console.WriteLine(statToWrite);
        }
    }
    #endregion
}
