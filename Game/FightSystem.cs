using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
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
        private int widthSize = 2; //map bal-jobb szélének mérete

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

        private bool hardMode;
        private bool direction = false;

        public FightSystem(Player player, Enemy enemy, out bool Victory, bool hardMode = false)
        {
            this.player = player;
            this.enemy = enemy;
            this.hardMode = hardMode;
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

        public static class BackgroundColors
        {
            public static string White = "\x1B[48;5;15m";
            public static string Black = "\x1B[48;5;16m";

            public static string DarkRed = "\x1B[48;5;160m";
            public static string Red = "\x1B[48;5;214m";
            public static string Yellow = "\x1B[48;5;220m";
            public static string Green = "\x1B[48;5;76m";
        }

        struct Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
            public ConsoleColor Color { get; set; }
        }

        struct Attack
        {
            public int X { set; get; }
            public string Color { get; set; }
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
            return enemy.Health <= 0;
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

                if (direction)
                {
                    sliderPostion -= 2;
                }
                if(sliderPostion < 0)
                {
                    sliderPostion = 0;
                }
                Attack attack = attackMap[(sliderPostion < attackMap.Length -1 ? sliderPostion : attackMap.Length - 1)];
                
                Thread.Sleep(100);

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.CursorLeft = 0;
                Console.CursorTop = 5;
                int dmg = (int)Math.Ceiling(attack.DamageMarkiplier * player.Damage);
                Console.Write($"  Sebzésed: {dmg}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                enemy.Health -= dmg;

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
            Console.CursorLeft = 0;
            Console.CursorTop = yTop;
            Console.Write(BackgroundColors.White);

            Console.Write(new string(' ', xMax + widthSize) );

            Console.CursorLeft = 0;
            Console.CursorTop = yMax;
            Console.Write(new string(' ', xMax + widthSize) );

            for (int j = 1; j < yMax - yTop; j++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = yTop + j;
                Console.Write(new string(' ', widthSize));
                Console.CursorLeft = xMax;
                Console.Write(new string(' ',widthSize));
            }

            Console.Write(BackgroundColors.Black);

        }

        private Attack[] generateMap()
        {
            xGreenSpot = random.Next(3,mapSize - player.SliderSpeed);
            int xGreenSpotRight = xGreenSpot + player.SliderSpeed - 1;
            /* MapSize (exc. GreenSpots):
             * 25% - 0%      dmg    - DarkRed
             * 45% - 10%-25% dmg    - Red
             * 30% - 50%-90% dmg    - Yellow
             
             */
            Attack[] attackMap = new Attack[mapSize - widthSize + 1];
            int count = 0;


            while (count < mapSize - widthSize + 1)
            {
                attackMap[count] = new Attack() { X = count, Round=round };
                if(count >= xGreenSpot && count <= xGreenSpot + player.SliderSpeed - 1)
                {
                    attackMap[count].Color = BackgroundColors.Green;
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
                        attackMap[count].Color = BackgroundColors.DarkRed;
                        attackMap[count].DamageMarkiplier = .0;
                    }
                    else if (ratio < .70)
                    {
                        double maxDamageClosenessMarkiplier = (ratio - .25) / (.70 - .25);       //.70 => 1, .50 => 0.555, .25 => 0
                        double minDamageClosenessMarkiplier = 1 - maxDamageClosenessMarkiplier;  //.70 => 0, .50 => 0.445, .25 => 1

                        attackMap[count].Color = BackgroundColors.Red;
                        attackMap[count].DamageMarkiplier = maxDamageClosenessMarkiplier * .25 + minDamageClosenessMarkiplier * .10; //.70 => .25, .50 => (0.555 * .25) + (0.445 * .10) = 0.138 + 0.0445 = 0.1825, .25 => .10
                    }
                    else
                    {
                        double maxDamageClosenessMarkiplier = (ratio - .70) / (1 - .70);         //1 => 1, .85 => 0.5, .70 => 0
                        double minDamageClosenessMarkiplier = 1 - maxDamageClosenessMarkiplier;  //1 => 0, .85 => 0.5, .70 => 1
                        attackMap[count].Color = BackgroundColors.Yellow;
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

            List<string> numOfColors_color = new List<string>();
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

            Console.Write($"\x1B[{yTop + 2}H");
            for (int j = 1; j < yMax - yTop; j++)
            {
                Console.Write($"\x1B[{widthSize + 1}G");
                for (int i = 0; i < numOfColors.Count; i++)
                {
                    Console.CursorTop = yTop + j;

                    Console.Write(numOfColors_color[i]);

                    Console.Write(new string(' ', numOfColors[i]));
                }
            }
            Console.Write(BackgroundColors.Black);
        }
        private async Task moveSlider(Attack[] attackMap)
        {
            await Task.Run(() =>
            {
                int travelTime = 2000 /mapSize;

                int currentRound = attackMap[0].Round;
                direction = false;

                byte[][] directionPrints = generateSliderMoveActions(true, attackMap);
                byte[][] notDirectionPrints = generateSliderMoveActions(false, attackMap);

                sliderPostion = random.Next(1 + widthSize, mapSize);

                Console.Write($"\x1B[{sliderPostion + widthSize + (direction ? 0 : 1)}G");

                while (!sliderStopped && round == currentRound)
                {
                    if ((sliderPostion >= mapSize - widthSize + 2 && direction) || (sliderPostion + 1 <= 1 && !direction))
                    {
                        sliderPostion += direction ? 1 : -1;
                        direction = !direction;
                    }
                    sliderPostion += direction ? 1 : -1;

                    
                    if ((direction && sliderPostion + 1 > 1) || (!direction && sliderPostion < mapSize - 1 - widthSize + 1))
                    {
                        Console.Write($"\x1B[{yTop + 2};{sliderPostion + widthSize + (direction ? 0 : 1)}H");

                        printSliderMove(direction ? directionPrints[sliderPostion - 1] : notDirectionPrints[sliderPostion + 1]);
                    }

                    Task.Delay(travelTime).Wait();
                }
            });
            
        }

        private async Task printSliderMove(bool direction,Attack[] attackMap)
        {
            await Task.Run(() =>
            {
                char[] toWriteChars;
                //Console.Write($"\x1B[{yTop + 2}H");
                if (direction && sliderPostion + 1 > 1)
                {
                    //Console.Write($"\x1B[{sliderPostion + widthSize}G");

                    toWriteChars = (attackMap[sliderPostion - 1].Color + " " + BackgroundColors.Black + " \b\b\x1B[B").ToCharArray();

                }
                else if (sliderPostion < mapSize - 1 - widthSize + 1)
                {
                    //Console.Write($"\x1B[{sliderPostion + widthSize + 1}G");
                    toWriteChars = (BackgroundColors.Black + " " + attackMap[sliderPostion + 1].Color + " \b\b\x1B[B").ToCharArray();
                }
                else
                {
                    return;
                }

                byte[] toWriteByte = Enumerable.Range(0, toWriteChars.Length).Select(i => (byte)toWriteChars[i]).ToArray();
                using (Stream stdout = Console.OpenStandardOutput(toWriteChars.Length))
                {
                    for (int j = 1; j < yMax - yTop; j++)
                    {
                        stdout.Write(toWriteByte, 0, toWriteByte.Length);
                    }
                }
                
            });
            
        }

        private async Task printSliderMove(byte[] printData)
        {
            await Task.Run(() =>
            {
                using (Stream stdout = Console.OpenStandardOutput(printData.Length))
                {
                    for (int j = 1; j < yMax - yTop; j++)
                    {
                        stdout.Write(printData, 0, printData.Length);
                    }
                }
                displayedSliderPosition = sliderPostion;
            });

        }

        private byte[][] generateSliderMoveActions(bool direction, Attack[] attackMap)
        {
            char[] toWriteChars;
            byte[][] toWriteBytesArray = new byte[attackMap.Length + 2][];

            if (direction)
            {
                for (int i = 0; i < attackMap.Length + 2; i++)
                {
                    string attackColor = i - 2 >= 0 ? attackMap[i - 2].Color : BackgroundColors.White;
                    string sliderColor = i - 1 >= 0 ? BackgroundColors.Black : BackgroundColors.White;
                    toWriteChars = ("\b\b" + attackColor + " " + sliderColor + " \x1B[B").ToCharArray();
                    toWriteBytesArray[i] = Enumerable.Range(0, toWriteChars.Length).Select(j => (byte)toWriteChars[j]).ToArray();
                }
            }
            else
            {
                for (int i = 0; i < attackMap.Length; i++)
                {
                    toWriteChars = (BackgroundColors.Black + " " + attackMap[i].Color + " \b\b\x1B[B").ToCharArray();
                    toWriteBytesArray[i] = Enumerable.Range(0, toWriteChars.Length).Select(j => (byte)toWriteChars[j]).ToArray();
                }
            }

            return toWriteBytesArray;
        }
        #endregion

        #region ENEMY_ATTACK
        private void enemyAttack(out int realLen, out int defeated)
        {
            int enemyAttacks;
            realLen = 0;
            int maxEnemyAttacks = 15;
            if (!hardMode)
            {
                enemyAttacks = 2 + round / 2;
            }
            else
            {
                enemyAttacks = 5 + round;
            }

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
                int attempts = 0;
                do
                {
                    rX = random.Next(4, xMax - 4);
                    rY = random.Next(9, yMax - 4);
                    attempts++;
                }
                while (isEnemyCloseToSpawn(spawnList, rX, rY) && attempts < 5);
                if(attempts >= 5)
                {
                    break;
                }
                
                spawnList[i] = new EnemyAttack() { X = rX, Y = rY, Char = charsToSpawn[random.Next(0,charsToSpawn.Length)], Round = round, Defeated = false, ID=i};
                realLen = i+1;
            }
            int howLongTillSpawn = 0;
            EnemyAttack[] currentSpawnList = new List<EnemyAttack>(spawnList).ToArray();
            for (int i = 0; i < spawnList.Length; i++)
            {
                spawnList[i].howLongTillSpawn = howLongTillSpawn;
                spawnList[i].coordinates = generatePatternForEnemyAttack(spawnList[i].X, spawnList[i].Y);
                spawnEnemyAttacks(currentSpawnList, i, waitMin, waitMax);


                howLongTillSpawn += random.Next(waitMin, waitMax);
            }
            #endregion

            defeated = 0;
            while (spawnedEnemyId < realLen || defeated < realLen)
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

        private async Task spawnEnemyAttacks(EnemyAttack[] currentSpawnList,int id, int waitMin, int waitMax)
        {
            await Task.Run(() =>
            {
                Task.Delay(spawnList[id].howLongTillSpawn).Wait();
                if (lostDeffence || currentSpawnList[id].Round != round)
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
                    if (lostDeffence || currentSpawnList[id].Round != round || spawnList[id].Defeated)
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(new string(' ', Console.WindowWidth));
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
            Console.Write(new string(' ', Console.WindowWidth - Console.CursorLeft - 1));
            if(enemy.Health != enemy.MaxHealth)
            {
                Console.Write(" ");
            }
            #endregion

            #region YOUR STATS
            int longest = Program.PrintPlayerStat(yellowHealth);
            #endregion

            xMax = Console.WindowWidth - longest - 4;
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
