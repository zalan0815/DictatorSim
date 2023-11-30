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

        private List<Card> deck;


        public BlackJack()
        {
            this.deck = Card.generateDeck();
            this.deck = Card.shuffleDeck(this.deck,6);
        }

    }
}
