using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class HandEvaluator
    {
        private Card[] cards;

        public HandEvaluator(Card[] sortedHand)
        {
            this.cards = sortedHand;
        }

        public Hand EvaluateHand()
        {
            Hand hand;

            if (IsFourOfAKind())
            {
                hand = Hand.FourOfAKind;
            }
            else if (IsFullHouse())
            {
                hand = Hand.FullHouse;
            }
            else if (IsFlush())
            {
                hand = Hand.Flush;
            }
            else if (IsStraight())
            {
                hand = Hand.Straight;
            }
            else if (IsThreeOfAKind())
            {
                hand = Hand.ThreeOfAKind;
            }
            else if (IsTwoPair())
            {
                hand = Hand.TwoPair;
            }
            else if (IsOnePair())
            {
                hand = Hand.OnePair;
            }
            else
            {
                hand = Hand.HighCard;
            }

            return hand;
        }

        private bool IsFourOfAKind()
        {
            bool isFourOfAKind = false;

            // Either the first 4 cards OR the last 4 cards are of the same value.
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[0].MyValue == cards[3].MyValue) 
                || (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[1].MyValue == cards[4].MyValue))
            {
                isFourOfAKind = true;
            }

            return isFourOfAKind;
        }

        private bool IsFullHouse()
        {
            bool isFullHouse = false;

            // Either the first 3 cards and the last 2 cards are of the same value OR
            // the first 2 cards and the last 3 cards are of the same value.
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue) ||
                (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue))
            {
                isFullHouse = true;
            }

            return isFullHouse;
        }

        private bool IsFlush()
        {
            bool isFlush = false;
            int i = 1;

            // All suits are the same.
            do
            {
                if (cards[0].MySuit == cards[i].MySuit)
                {
                    isFlush = true;
                    i++;
                }
                else
                {
                    isFlush = false;
                }
            } while (isFlush && i < 5); 

            return isFlush;
        }

        private bool IsStraight()
        {
            bool isStraight = false;
            int i = 1;

            // 5 cards are of consecutive values.
            do
            {
                if (cards[i].MyValue - cards[0].MyValue == i)
                {
                    isStraight = true;
                    i++;
                }
                else
                {
                    isStraight = false;
                }
            } while (isStraight && i < 5);

            return isStraight;
        }

        private bool IsThreeOfAKind()
        {
            bool isThreeOfAKind = false;

            // Either Card 1, 2 and 3 are of the same value and Card 4 and 5 are of different value OR
            // Card 2, 3, 4 are of the same value and Card 1 and 5 are of different value OR
            // Card 3, 4 and 5 are of the same value and Card 1 and 2 are of different value.
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue != cards[4].MyValue) ||
                (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[0].MyValue != cards[4].MyValue) ||
                (cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue && cards[0].MyValue != cards[1].MyValue))
            {
                isThreeOfAKind = true;
            }

            return isThreeOfAKind;
        }

        private bool IsTwoPair()
        {
            bool isTwoPair = false;

            // Card 1, 2 and Card 3, 4 are of the same value OR
            // Card 1, 2 and Card 4, 5 are of the same value OR
            // Card 2, 3 and Card 4, 5 are of the same value.
            if ((cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue) ||
                (cards[0].MyValue == cards[1].MyValue && cards[3].MyValue == cards[4].MyValue) ||
                (cards[1].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue))
            {
                isTwoPair = true;
            }

            return isTwoPair;
        }

        private bool IsOnePair()
        {
            bool isOnePair = false;

            // Card 1,2 OR Card 2,3 OR Card 3,4 OR Card 4,5 are of the same value.
            if (cards[0].MyValue == cards[1].MyValue || cards[1].MyValue == cards[2].MyValue || 
                cards[2].MyValue == cards[3].MyValue || cards[3].MyValue == cards[4].MyValue)
            {
                isOnePair = true;
            }

            return isOnePair;
        }
    }
}