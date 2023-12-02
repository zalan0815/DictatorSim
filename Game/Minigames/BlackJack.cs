using System.Linq;
using System.Runtime.CompilerServices;
using static Game.Minigames.BlackJack;

namespace Game.Minigames
{
    class BlackJack
    {
        public enum CardColor
        {
            clubs,
            pikes,
            diamonds,
            hearts
        }

        public enum BlackJackAction
        {
            Hit,
            Stand,
            Double,
            Split,
            Insurance,
            Surrender
        }
        public struct Card
        {
            private static Dictionary<string, int> numeralvalues = new Dictionary<string, int>()
            {
                { "A", 11 },
                { "K", 10 },
                { "Q", 10 },
                { "J", 10 },
            };
            public static string[] CardColorSymbole = new string[]
            {
                //"♣",
                //"♠",
                //"♦",
                //"♥"
                "-",
                ".",
                "[",
                "]",
            };

            private CardColor color;
            private string numeral;
            private int value;

            public CardColor Color { get { return color; } }
            public string Numeral { get { return numeral; } }
            public int Value { get { return value; } }

            public Card(CardColor color, string numeral)
            {
                this.color = color;
                this.numeral = numeral;
                if (numeralvalues.ContainsKey(numeral))
                {
                    this.value = numeralvalues[numeral];
                    return;
                }
                if (int.TryParse(numeral, out int value) && value > 1 && value <= 10)
                {
                    this.value = value;
                    return;
                }
                throw new Exception("Nem létező kártya, rossz adatok");
            }

            public static List<Card> generateDeck()
            {
                List<Card> cards = new List<Card>();
                foreach (CardColor name in Enum.GetValues(typeof(CardColor)))
                {
                    for (int i = 2; i < 11; i++)
                    {
                        cards.Add(new Card(name, $"{i}"));
                    }
                    foreach (string key in numeralvalues.Keys)
                    {
                        cards.Add(new Card(name, key));
                    }
                }
                return cards;
            }

            public static List<Card> shuffleDeck(List<Card> cards, int howManyTimes = 1)
            {
                List<Card> newCards;
                Random r;
                int count = 0;

                do
                {
                    newCards = new List<Card>(cards);
                    r = new Random();

                    for (int i = 0; i < newCards.Count; i++)
                    {
                        int randomIndex = r.Next(cards.Count);

                        newCards[i] = cards[randomIndex];
                        cards.RemoveAt(randomIndex);
                    }

                    cards = newCards;
                    count++;
                }
                while (count < howManyTimes);


                return newCards;
            }

            public static void printDeck(List<Card> cards)
            {
                foreach (Card card in cards)
                {
                    Console.Write($"{Card.CardColorSymbole[(int)card.Color]}{card.Numeral}, ");
                }
            }
        }
        public class BlackJackInventory
        {
            public List<Card> Cards { get; set; }
            public int Bet { get; set; }
            public int InsuranceBet { get; set; }
            public bool isHidden { get; set; }
            public bool hasSurrendered { get; set; }
            public string Text { get; set; }
            public bool gameOver { get; set; }
            public int round { get; set; }
            public string endString { get; set; }
            public int playerGetsMoney { get; set; }
            public int CardsValue
            {
                get
                {
                    int value = 0;
                    int aces = 0;
                    foreach (Card card in Cards)
                    {
                        if (card.Numeral == "A")
                        {
                            aces++;
                        }
                        else
                        {
                            value += card.Value;
                        }

                    }
                    if (aces >= 1)
                    {
                        value += 1 * (aces - 1);
                        if (value + 11 > 21)
                        {
                            value += 1;
                        }
                        else
                        {
                            value += 11;
                        }
                    }


                    return value;
                }
            }
            public BlackJackInventory(List<Card> cards, int bet = 0, bool isHidden = false, string text = "")
            {
                this.Cards = cards;
                this.Bet = bet;
                this.isHidden = isHidden;
                this.Text = text;
                this.InsuranceBet = 0;
                this.hasSurrendered = false;
                this.gameOver = false;
                this.round = 1;
                this.endString = "";
                this.playerGetsMoney = 0;
            }

        }
        private List<Card> deck;
        private List<Card> allCards;
        private Player player;

        private List<BlackJackInventory> blackJackInventories;
        private BlackJackInventory[] playerInventories;

        private BlackJackInventory playerInventory;
        private BlackJackInventory dealerInventory;

        public BlackJack(ref Player player)
        {
            this.deck = Card.shuffleDeck(Card.generateDeck(), 6);
            this.allCards = new List<Card>(deck);
            this.player = player;
        }

        public void Run()
        {
            Console.Clear();

            if (player.Money <= 0)
            {
                return;
            }
            Start();
        }

        private void Start()
        {
            playerInventory = new BlackJackInventory(new List<Card>(), 0, false, "Lapjaid:\t ");
            playerInventories = new BlackJackInventory[] { playerInventory };

            dealerInventory = new BlackJackInventory(new List<Card>(), 0, true, "Osztó lapjai:\t ");
            blackJackInventories = new List<BlackJackInventory> { playerInventory, dealerInventory };

            Bet();
            FirstDeal();

            if (playerInventory.CardsValue == 21)
            {
                playerInventory.gameOver = true;
            }

            for (int i = 0; i < playerInventories.Length; i++)
            {
                playerInventory = playerInventories[i];

                while (!playerInventory.gameOver)
                {
                    PrintTable();
                    BlackJackAction action = Choose();
                    switch (action)
                    {
                        case BlackJackAction.Hit:
                            Deal(ref playerInventory);

                            break;

                        case BlackJackAction.Stand:

                            if(playerInventories.Length == 1 || playerInventories[1] == playerInventory)
                            {
                                DealerHits();
                            }

                            playerInventory.gameOver = true;

                            break;

                        case BlackJackAction.Double:
                            player.Money -= playerInventory.Bet;
                            playerInventory.Bet *= 2;
                            Deal(ref playerInventory);

                            if (playerInventories.Length == 1 || playerInventories[1] == playerInventory)
                            {
                                DealerHits();
                            }
                            playerInventory.gameOver = true;

                            break;

                        case BlackJackAction.Split:
                            Card nextDeckCard = playerInventory.Cards[1];
                            playerInventory.Cards.RemoveAt(1);
                            playerInventory.Text = "1. Lapjaid:\t";

                            playerInventories = new BlackJackInventory[] { playerInventory, new BlackJackInventory(new List<Card> { nextDeckCard}, 0, false, "2. Lapjaid:\t") };
                            blackJackInventories[1] = playerInventories[1];
                            blackJackInventories.Add(dealerInventory);

                            if(player.Money >= playerInventory.Bet)
                            {
                                playerInventories[1].Bet = playerInventory.Bet;
                                player.Money -= playerInventories[1].Bet;
                            }
                            else
                            {
                                playerInventories[1].Bet = player.Money;
                                player.Money = 0;
                            }

                            Deal(ref playerInventories[0]);
                            Deal(ref playerInventories[1]);

                            playerInventory.round--;
                            break;

                        case BlackJackAction.Insurance:
                            playerInventory.InsuranceBet = insuranceBet();

                            break;

                        case BlackJackAction.Surrender:
                            playerInventory.playerGetsMoney += playerInventory.Bet / 2;

                            playerInventory.hasSurrendered = true;
                            playerInventory.gameOver = true;

                            break;
                    }
                    if (playerInventory.CardsValue > 21)
                    {
                        playerInventory.gameOver = true;
                    }
                    playerInventory.round++;
                }
            }

            #region KIÉRTÉKELÉS
            for (int i = 0; i < playerInventories.Length; i++)
            {
                playerInventory = playerInventories[i];

                if (!playerInventory.hasSurrendered)
                {
                    if (dealerInventory.Cards[1].Value == 10)
                    {
                        playerInventory.playerGetsMoney += 2 * playerInventory.InsuranceBet;
                    }

                    if (playerInventory.CardsValue > 21)
                    {
                        playerInventory.endString = "Bust... Vesztettél.";
                    }
                    else if (dealerInventory.CardsValue > 21)
                    {
                        playerInventory.endString = $"Bust! Nyertél! ({2 * playerInventory.Bet})";
                        playerInventory.playerGetsMoney += 2 * playerInventory.Bet;
                    }
                    else
                    {
                        if (playerInventory.CardsValue == dealerInventory.CardsValue)
                        {
                            playerInventory.endString = $"Döntetlen... Pénzed ({playerInventory.Bet}) visszajár";
                            playerInventory.playerGetsMoney += playerInventory.Bet;
                        }
                        else if (playerInventory.CardsValue == 21 && playerInventory.Cards.Count == 2)
                        {
                            playerInventory.endString = $"BlackJack!!! ({3 * playerInventory.Bet / 2})";
                            playerInventory.playerGetsMoney += 3 * playerInventory.Bet / 2;
                        }
                        else if (playerInventory.CardsValue > dealerInventory.CardsValue)
                        {
                            playerInventory.endString = $"Nyertél! ({2 * playerInventory.Bet})";
                            playerInventory.playerGetsMoney += 2 * playerInventory.Bet;
                        }
                        else if (playerInventory.CardsValue < dealerInventory.CardsValue)
                        {
                            playerInventory.endString = $"Vesztettél...";
                        }
                        else
                        {
                            playerInventory.endString = "How did you get here?";
                            playerInventory.playerGetsMoney += playerInventory.Bet;
                        }

                    }
                }
                else
                {
                    playerInventory.endString = $"Feladtad. Pénzed fele ({playerInventory.Bet / 2}) visszajár";
                }

            }
            #endregion

            Program.PrintPlayerStat();

            dealerInventory.isHidden = false;

            playerInventories[0].Bet = 0;
            player.Money += playerInventories[0].playerGetsMoney;
            if(playerInventories.Length > 1)
            {
                playerInventories[1].Bet = 0;
                player.Money += playerInventories[1].playerGetsMoney;
            }
            PrintTable();
            Console.WriteLine(playerInventories[0].endString);
            if (playerInventories.Length > 1)
            {
                Console.WriteLine(playerInventories[playerInventories.Length - 1].endString);
            }
            Console.ReadKey(true);
        }

        private void Bet()
        {
            Program.PrintPlayerStat();
            Console.WriteLine("Mennyi pénzt teszel fel? ");
            string input;
            int bet;
            do
            {
                input = Console.ReadLine();

            } while (!int.TryParse(input, out bet) || bet < 0 || bet > player.Money);

            playerInventory.Bet = bet;
            player.Money -= bet;
        }

        private int insuranceBet()
        {
            Console.WriteLine("Mennyi pénzt teszel biztosítás végett? ");
            string input;
            int bet;
            do
            {
                input = Console.ReadLine();

            } while (!int.TryParse(input, out bet) || bet < 0 || bet > player.Money || bet > playerInventory.Bet / 2);

            return bet;
        }

        private void FirstDeal()
        {
            for (int i = 0; i < 2; i++)
            {
                if (deck.Count < 2)
                {
                    MakeNewDeck();
                }
                playerInventory.Cards.Add(deck[0]);
                deck.RemoveAt(0);

                dealerInventory.Cards.Add(deck[0]);
                deck.RemoveAt(0);
            }
        }

        private void Deal(ref BlackJackInventory inventory)
        {
            if (deck.Count == 0)
            {
                MakeNewDeck();
            }
            inventory.Cards.Add(deck[0]);
            deck.RemoveAt(0);
        }

        private void MakeNewDeck()
        {
            deck = new List<Card>(allCards);
            foreach (BlackJackInventory inventory in blackJackInventories)
            {
                foreach (Card card in inventory.Cards)
                {
                    deck.Remove(card);
                }
            }
            deck = Card.shuffleDeck(deck, 6);
        }

        private void PrintTable()
        {
            Console.Clear();
            Program.PrintPlayerStat();

            if (playerInventories.Length > 1 && playerInventory == playerInventories[0])
            {
                Console.WriteLine($"Betett pénzed: {playerInventories[0].Bet} + {playerInventories[1].Bet}\n\n");
            }
            else
            {
                Console.WriteLine($"Betett pénzed: {playerInventory.Bet}\n\n");
            }
            

            foreach (BlackJackInventory inventory in blackJackInventories)
            {
                if (playerInventories.Contains(inventory) && playerInventory != inventory)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.Write(inventory.Text);
                for (int i = 0; i < inventory.Cards.Count - 1; i++)
                {
                    Card card = inventory.Cards[i];
                    PrintCard(card);
                }
                if (inventory.isHidden)
                {
                    Console.Write($"?? ");
                }
                else
                {
                    PrintCard(inventory.Cards[inventory.Cards.Count - 1]);
                }
                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("\n");
            
        }

        private void PrintCard(Card card)
        {
            Console.Write($"{Card.CardColorSymbole[(int)card.Color]}{card.Numeral} ");
        }
        
        private BlackJackAction Choose()
        {
            bool[] allowed = new bool[6]
            {   
                playerInventory.CardsValue < 21,
                true,
                playerInventory.round == 1 && player.Money >= playerInventory.Bet,
                playerInventory.round == 1 && playerInventories.Length == 1 && playerInventory.Cards[0].Numeral == playerInventory.Cards[1].Numeral,
                playerInventory.round == 1 && dealerInventory.Cards[0].Numeral == "A",
                playerInventory.round == 1
            };

            Console.WriteLine("Mit akarsz csinálni:");
            for (int i = 0; i < 6; i++)
            {
                if (!allowed[i])
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine($"{i+1} - {Enum.GetName(typeof(BlackJackAction),i)}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            int choice;
            bool error = false;
            while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out choice) || choice < 1 || choice > allowed.Length || !allowed[choice-1])
            {
                if (!error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ilyet nem tudsz csinálni!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Próbáld újra!");
                    error = true;
                }
            }

            return (BlackJackAction) (choice - 1);
        }

        private void DealerHits()
        {
            dealerInventory.isHidden = false;
            PrintTable();
            while (dealerInventory.CardsValue <= 16)
            {
                Deal(ref dealerInventory);
                PrintTable();
            }
        }
    }
}
