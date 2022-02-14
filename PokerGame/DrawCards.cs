/*
 * Author: David Hung
 * Created: 2022-02-06
 * Updated: 2022-02-14
 */

using System;
using System.Text;

namespace PokerGame
{
    public class DrawCards
    {
        // Draw outline of the card
        public static void DrawCardOutline(int xCoordinate, int yCoordinate)
        {
            Console.ForegroundColor = ConsoleColor.White;

            int x = xCoordinate * 12;
            int y = yCoordinate;

            Console.SetCursorPosition(x, y);
            Console.WriteLine(" __________ "); // Top edge of the card

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                if (i != 9)
                {
                    Console.WriteLine("|          |"); // Body of the card
                }
                else
                {
                    Console.WriteLine("|__________|"); // Bottom edge of the card
                }
            }
        }

        // Draw suite and value of the card inside the card outline
        public static void DrawCardSuitValue(Card card, int xCoordinates, int yCoordinates)
        {
            char cardSuit = ' ';
            int x = xCoordinates * 12;
            int y = yCoordinates;

            // Encode each byte array from the CodePage437 into a character
            // Hearts and Diamonds are red, Clubs and Spade are black
            switch (card.MySuit)
            {
                case Suit.Hearts:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case Suit.Diamonds:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case Suit.Clubs:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

                case Suit.Spades:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            // Display the encoded character and value of the card
            Console.SetCursorPosition(x + 5, y + 5);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.MyValue);
        }
    }
}