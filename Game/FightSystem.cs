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
        private int displayedSliderPosition;

        private bool sliderStopped;
        private int yTop = 5;
        private int mapSize { get { return xMax - 1; } }
        private int xGreenSpot;

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

            public int Round { get; set; }
        }
        struct Colors
        {
            public int Number { get; set; }
            public ConsoleColor Color { get; set; }
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
                playerAttack(out Attack[] attackMap);

                Attack attack = attackMap[sliderPostion];
                Thread.Sleep(100);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                #if DEBUG
                Console.WriteLine($"dmg {player.Damage} dmg * m{attack.DamageMarkiplier * player.Damage}");
                Console.WriteLine($"tényleges:  {sliderPostion} (zöld: {xGreenSpot - sliderPostion}  ({xGreenSpot}))");
                //Console.WriteLine($"megrajzolt: {displayedSliderPosition} (zöld: {xGreenSpot - displayedSliderPosition}  ({xGreenSpot}))");
                #endif
                Console.ForegroundColor = attack.Color;
                Console.WriteLine($"Sebzésed: {(int)Math.Ceiling(attack.DamageMarkiplier * player.Damage)}");

                
                enemy.Health -= (int)Math.Ceiling(attack.DamageMarkiplier * player.Damage);

                Thread.Sleep(200);
                writeFight();
                Console.ReadKey(true);

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
        private void playerAttack(out Attack[] attackMap)
        {
            sliderStopped = false;
            printAttackMapBase();
            attackMap = generateMap();
            printAttackMap(attackMap);

            moveSlider(attackMap);

            //displayedSliderPosition = sliderPostion;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 250)
            {
                Console.ReadKey(true);
            }

            sliderStopped = true;
        }

        private void printAttackMapBase()
        {

            Console.BackgroundColor = ConsoleColor.White;

            Console.CursorLeft = 0;
            Console.CursorTop = yTop;
            Console.Write(new string(' ', xMax + 1) );

            Console.CursorLeft = 0;
            Console.CursorTop = yMax;
            Console.Write(new string(' ', xMax + 1) );

            for (int j = 1; j < yMax - yTop; j++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = yTop + j;
                Console.Write(" ");
                Console.CursorLeft = xMax;
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;

        }

        private Attack[] generateMap()
        {
            xGreenSpot = random.Next(mapSize + 1 - player.SliderSpeed);
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
                attackMap[count] = new Attack() { X = count, Round=round };
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
            List<int> numOfColors = new List<int>();
            numOfColors.Add(1);

            List<ConsoleColor> numOfColors_color = new List<ConsoleColor>();
            numOfColors_color.Add(attackMap[0].Color);

            for (int i = 1; i < attackMap.Length; i++)
            {
                if (attackMap[i-1].Color == attackMap[i].Color)
                {
                    numOfColors[numOfColors.Count-1] += 1;
                }
                else
                {
                    numOfColors.Add(1);
                    numOfColors_color.Add(attackMap[i].Color);
                }
            }
            
            for (int j = 1; j < yMax - yTop; j++)
            {
                Console.CursorLeft = 1;
                for (int i = 0; i < numOfColors.Count; i++)
                {
                    Console.CursorTop = yTop + j;

                    Console.BackgroundColor = numOfColors_color[i];

                    Console.Write(new string(' ', numOfColors[i]));
                }
            }
            Console.BackgroundColor= ConsoleColor.Black;
        }
        private async Task moveSlider(Attack[] attackMap)
        {
            await Task.Run(async () =>
            {
                Stopwatch printTimer = new Stopwatch();
                int travelTime = 2000/mapSize;

                int currentRound = attackMap[0].Round;
                bool direction = false;
                sliderPostion = random.Next(2, mapSize);
                while (!sliderStopped && round == currentRound)
                {
                    printTimer.Start();
                    if ((sliderPostion >= mapSize - 1 && direction) || (sliderPostion + 1 <= 1 && !direction))
                    {
                        sliderPostion += direction ? 1 : -1;
                        direction = !direction;

                    }
                    sliderPostion += direction ? 1 : -1;

                    await printSliderMove(direction, attackMap);

                    printTimer.Stop();

                    int printTime = Convert.ToInt32(printTimer.ElapsedMilliseconds);
                    if (printTime < travelTime)
                    {
                        Task.Delay(travelTime - printTime).Wait();
                    }
                    else
                    {
                        Task.Delay(1).Wait();
                    }
                    printTimer.Reset();
                }
            });
            
        }

        private async Task printSliderMove(bool direction,Attack[] attackMap)
        {
            await Task.Run(() =>
            {
                Console.CursorTop = yTop + 1;
                if (direction && sliderPostion + 1 > 1)
                {
                    for (int j = 1; j < yMax - yTop; j++)
                    {
                        Console.CursorLeft = sliderPostion;
                        Console.BackgroundColor = attackMap[sliderPostion - 1].Color;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.CursorTop++;
                    }
                }
                else if(sliderPostion < mapSize - 1)
                {
                    for (int j = 1; j < yMax - yTop; j++)
                    {
                        Console.CursorLeft = sliderPostion + 1;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.BackgroundColor = attackMap[sliderPostion + 1].Color;
                        Console.Write(" ");
                        Console.CursorTop++;
                    }
                }
            });
            
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
            int longest = Program.PrintPlayerStat(yellowHealth);
            #endregion

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
