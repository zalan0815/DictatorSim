namespace Game.Minigames
{
    public class BlackJack
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

            public static List<Card> shuffleDeck(List<Card> cards)
            {
                List<Card> newCards = new List<Card>(cards);
                Random r = new Random();

                bool[] usedPosition = new bool[cards.Count];

                for (int i = 0; i < cards.Count; i++)
                {
                    int nthToGo = r.Next(cards.Count - i); //52 - 0 = 52 => 0,51 lesz szám

                    int realCount = 0;    //ahányadik elem a listában
                    int relativeCount = 0;//ahányadik állítható elem
                    while (relativeCount < nthToGo)
                    {
                        if (usedPosition[realCount] == false)
                        {
                            relativeCount++;
                        }
                        realCount++;
                    }
                    newCards[relativeCount] = cards[i];
                    usedPosition[realCount] = true;
                }

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

        private List<Card> deck;


        public BlackJack()
        {
            this.deck = Card.generateDeck();
            this.deck = Card.shuffleDeck(this.deck);
            Card.printDeck(this.deck);
        }

    }
}
