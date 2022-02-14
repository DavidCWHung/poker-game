/*
 * Author: David Hung
 * Created: 2022-02-06
 * Updated: 2022-02-14
 */

using System;
using System.Linq;

namespace PokerGame
{
    public class DealCards : DeckOfCards
    {
        private Card[] playerHand;
        private Card[] sortedPlayerHand;
        private Card[] computerHand;
        private Card[] sortedComputerHand;

        public DealCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            computerHand = new Card[5];
            sortedComputerHand = new Card[5];
        }

        public void Deal()
        {
            base.SetUpDeck(); // Create the deck of cards and shuffle them
            this.GetHand();
            this.SortHand();
            this.DisplayHand();
            this.EvaluateHand();
        }

        public void GetHand()
        {
            // Get 5 cards for the player
            for (int i = 0; i < 5; i++)
            {
                this.playerHand[i] = base.GetDeck[i];
            }

            // Get 5 cards for the computer
            for (int i = 5; i < 10; i++)
            {
                this.computerHand[i - 5] = base.GetDeck[i];
            }
        }

        public void SortHand()
        {
            //var queryPlayer = this.playerHand.OrderBy(hand => hand.MyValue);

            var queryPlayer = from hand in this.playerHand
                              orderby hand.MyValue
                              select hand;

            //var queryComputer = this.computerHand.OrderBy(hand => hand.MyValue);

            var queryComputer = from hand in this.computerHand
                                orderby hand.MyValue
                                select hand;

            int i = 0;
            foreach (var element in queryPlayer.ToList())
            {
                this.sortedPlayerHand[i] = element;
                i++;
            }

            i = 0;
            foreach (var element in queryComputer.ToList())
            {
                this.sortedComputerHand[i] = element;
                i++;
            }
        }

        public void DisplayHand()
        {
            Console.Clear();
            int x = 0; // x position of the cursor, move it left and right
            int y = 1; // y position of the cursor, move it up and down

            // Display player hand
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("PLAYER'S HAND");
            for (int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(this.sortedPlayerHand[i], x, y);
                x++; // Move to right
            }

            y = 15; // Move the row of computer hand underneath the player hand
            x = 0; // Reset x position
            Console.SetCursorPosition(x, y);

            // Display computer hand
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("COMPUTER'S HAND");
            y++;

            for (int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(this.sortedComputerHand[i], x, y);
                x++; // Move to right
            }
        }

        public void EvaluateHand()
        {
            // Create an instance of the HandEvaluator class for each player and computer with their sorted hands.
            HandEvaluator playerHandEvaluator = new HandEvaluator(this.sortedPlayerHand);
            HandEvaluator computerHandEvaluator = new HandEvaluator(this.sortedComputerHand);

            // Get the ranking of the player's and computer's hands.
            Hand playerHand = playerHandEvaluator.EvaluateHand();
            Hand computerHand = computerHandEvaluator.EvaluateHand();

            // Display the player's and the computer's hands.
            Console.ForegroundColor = ConsoleColor.Black; // Reset color
            Console.WriteLine("\n\n\n\n\nPlayer has {0}.", playerHand);
            Console.WriteLine("Computer has {0}.", computerHand);

            // Compare their hands.
            if (playerHand > computerHand)
            {
                Console.WriteLine("Player wins!");
            }
            else if (playerHand < computerHand)
            {
                Console.WriteLine("Computer wins!");
            }
            else
            {
                // Tiebreaker rule for Flush, HighCard.
                if ((playerHand == Hand.HighCard) || (playerHand == Hand.Flush))
                {
                    int i = 4;
                    bool isWinnerFound = false;
                    string winner = "";

                    do
                    {
                        if (sortedPlayerHand[i].MyValue > sortedComputerHand[i].MyValue)
                        {
                            winner = "Player";
                            isWinnerFound = true;
                        }
                        else if (sortedPlayerHand[i].MyValue < sortedComputerHand[i].MyValue)
                        {
                            winner = "Computer";
                            isWinnerFound = true;
                        }

                        i--;
                    } while (i >= 0 && !isWinnerFound);
                    
                    if (isWinnerFound)
                    {
                        Console.WriteLine("{0} wins!", winner);
                    }
                    else
                    {
                        Console.WriteLine("It's a draw.");
                    }
                }
                else
                {
                    // Tiebreaker rule for FourOfAKind, FullHouse, Straight, ThreeOfAKind; TwoPair and OnePair [to be refined].
                    if (playerHandEvaluator.TieBreakerValue > computerHandEvaluator.TieBreakerValue)
                    {
                        Console.WriteLine("Player wins!");
                    }
                    else if (playerHandEvaluator.TieBreakerValue < computerHandEvaluator.TieBreakerValue)
                    {
                        Console.WriteLine("Computer wins!");
                    }
                    else
                    {
                        Console.WriteLine("It's a draw.");
                    }
                }
            }
        }
    }
}