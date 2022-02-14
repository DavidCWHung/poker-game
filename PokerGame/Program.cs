/*
 * Author: David Hung
 * Created: 2022-02-06
 * Updated: 2022-02-14
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    internal class program
    {
        static void Main(string[] args)
        {
            // Set up the Console Application's interface.
            Console.SetWindowSize(65, 40);
            Console.SetBufferSize(65, 40); // Remove the scroll bars by setting the buffer to actual window size.
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Title = "Poker Game";

            DealCards game = new DealCards();
            bool quit = false;

            do
            {
                game.Deal();

                char selection = ' ';
                do
                {
                    Console.SetCursorPosition(0, 32); // Reset position
                    Console.ForegroundColor = ConsoleColor.DarkBlue; // Reset color

                    Console.Write("Play Again? (Y/N): ");

                    try
                    {
                        selection = Convert.ToChar(Console.ReadLine().ToUpper());

                        if (selection == 'Y')
                        {
                            quit = false;
                        }
                        else if (selection == 'N')
                        {
                            quit = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Please enter again!");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Input. Please enter again!");
                    }
                } while (selection != 'Y' && selection != 'N');
            } while (!quit);

            Console.WriteLine("Thank you! Press any key to leave.");
            Console.ReadKey();
        }
    }
}
