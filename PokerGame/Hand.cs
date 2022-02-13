namespace PokerGame
{
    /// <summary>
    /// Specifies a poker hand.
    /// </summary>
    public enum Hand
    {
        /// <summary>
        /// The nothing hand.
        /// </summary>
        HighCard, 

        /// <summary>
        /// The one pair hand.
        /// </summary>
        OnePair, 

        /// <summary>
        /// The two pair hand.
        /// </summary>
        TwoPair,

        /// <summary>
        /// The three of a kind hand.
        /// </summary>
        ThreeOfAKind,

        /// <summary>
        /// The straight hand.
        /// </summary>
        Straight,

        /// <summary>
        /// The flush hand.
        /// </summary>
        Flush,

        /// <summary>
        /// The full house hand.
        /// </summary>
        FullHouse,

        /// <summary>
        /// The four of a kind hand.
        /// </summary>
        FourOfAKind
    }
}