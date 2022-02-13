using System;

namespace PokerGame
{
    public class DeckOfCards
    {
        // Fields
        const int NumberOfCards = 52; // Number of all cards
        private Card[] deck; // Array of all playing cards

        // Constructor
        public DeckOfCards()
        {
            this.deck = new Card[NumberOfCards];
        }

        public Card[] GetDeck
        {
            // Get current deck.
            get
            {
                return this.deck;
            }
        }

        // Create deck of 52 cards: 13 values, 4 suits for each value
        public void SetUpDeck()
        {
            int i = 0;

            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    this.deck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }

            this.ShuffleCards();
        }

        // Shuffle the deck
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;

            // Run the shuffle 1000 times
            for (int shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (int i = 0; i < NumberOfCards; i++)
                {
                    // Swap the cards
                    int secondCardIndex = rand.Next(52);

                    temp = this.deck[i];
                    this.deck[i] = this.deck[secondCardIndex];
                    this.deck[secondCardIndex] = temp;
                }
            }
        }
    }
}