﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    internal class SupportClass
    {
        public static void PrintBoard(char[,] gameBoard)
        {
            //loop through 2-dimensional array and print board
            for (int iOuter = 0; iOuter <= 2; iOuter++)
            {
                for (int iInner = 0; iInner <= 2; iInner++)
                {
                    Console.Write(gameBoard[iOuter, iInner] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool CheckForWinner(char[,] gameBoard, string name)
        {
            for (int i = 0; i <= 2; i++)
            {
                //Check rows to see if not empty and are the same symbol
                if (gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2] && gameBoard[i, 0] != ' ')
                {
                    Console.WriteLine($"{name} is the winner!"); //confirm that player wins
                    return true;
                }

                //Check columns to see if not empty and are the same symbol
                if (gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i] && gameBoard[0, i] != ' ')
                {
                    Console.WriteLine($"{name} is the winner!"); //confirm that player wins
                    return true;
                }
            }

            // Check cross to see if not empty and are same symbol
            if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2] && gameBoard[0, 0] != ' ')
            {
                Console.WriteLine($"{name} is the winner!"); //confirm winner
                return true;
            }

            //check other cross
            if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0] && gameBoard[0, 2] != ' ')
            {
                Console.WriteLine($"{name} is the winner!"); //confirm winner
                return true;
            }

            //check for tie
            if (gameBoard[0,0] != '1' && gameBoard[1,0] != '4' && gameBoard[2,0] != '7' &&
                gameBoard[0,1] != '2' && gameBoard[1,1] != '5' && gameBoard[2,1] != '8' &&
                gameBoard[0,2] != '3' && gameBoard[1,2] != '6' && gameBoard[2,2] != '9')
            {
                Console.WriteLine("This game is a tie. Restart the program to play again.");
                return true;
            }

            return false; //return no winner if nothing matches
        }
    }
}

