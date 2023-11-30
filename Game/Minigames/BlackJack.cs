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

            public static List<Card> shuffleDeck(List<Card> cards, int howManyTimes=1)
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
                foreach(Card card in cards)
                {
                    Console.Write($"{Card.CardColorSymbole[(int)card.Color]}{card.Numeral}, ");
                }
            }
        }
        public struct BlackJackInventory
        {
            public List<Card> Cards { get; set; }
            public int Bet { get; set; }
            public bool isHidden { get; set; }
            public int CardsValue { 
                get
                {
                    int value = 0;
                    int aces = 0;
                    foreach (Card card in Cards)
                    {
                        if(card.Numeral == "A")
                        {
                            aces++;
                        }
                        else
                        {
                            value += card.Value;
                        }
                        
                    }
                    if(aces >= 1)
                    {
                        value += 1 * (aces - 1);
                        if(value + 11 > 21)
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
            public BlackJackInventory(List<Card> cards, int bet = 0, bool isHidden = false)
            {
                this.Cards = cards;
                this.Bet = bet;
                this.isHidden = isHidden;
            }

        }
        private List<Card> deck;
        private List<Card> allCards;
        private Player player;

        private BlackJackInventory playerInventory;
        private BlackJackInventory dealerInventory;

        public BlackJack(ref Player player)
        {
            this.deck = Card.shuffleDeck(Card.generateDeck(), 6);
            this.allCards = deck;
            this.player = player;
        }
        
        public void Run()
        {
            if (player.Money <= 0)
            {
                return;
            }
            playerInventory = new BlackJackInventory(new List<Card>(), 0, false);
            dealerInventory = new BlackJackInventory(new List<Card>(), 0, false);
            Bet();
            FirstDeal();
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

            } while (!int.TryParse(input, out bet) && bet > 0 && bet <= player.Money);

            playerInventory.Bet = bet;
            player.Money -= bet;
        }

        private void FirstDeal()
        {
            for (int i = 0; i < 2; i++)
            {
                if (deck.Count > 0)
                {
                    playerInventory.Cards.Add(deck[0]);
                    deck.RemoveAt(0);
                }
                if (deck.Count > 0)
                {
                    dealerInventory.Cards.Add(deck[0]);
                    deck.RemoveAt(0);
                }
            }
        }
    }
}
