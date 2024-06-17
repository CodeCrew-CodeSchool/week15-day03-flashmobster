using System;
using System.Linq;

namespace TicTacToe
{
    class Player
    {
        public string id { get; set; } = "";
        public string marker { get; set; } = "";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my tic tac toe game!\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("You are player 1. You will be using X\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();

            string[][] gameBoard = new string[][]
            {
                new string[] { "1", "2", "3" },
                new string[] { "4", "5", "6" },
                new string[] { "7", "8", "9" }
            };

            Player player1 = new Player();
            player1.id = "1";
            player1.marker = "X";

            Player player2 = new Player();
            player2.id = "2";
            player2.marker = "O";

            Player currentPlayer = player1;
            bool gameOver = false;
            string winMessage = "";

            while (!gameOver)
            {
                Console.WriteLine("This is the board\n");
                DisplayBoard(gameBoard);

                Console.WriteLine($"\nPlayer {currentPlayer.id}. Make a move!");
                string? playerChoice = Console.ReadLine();
                
                if (playerChoice != null)
                {
                    MarkBoard(playerChoice, currentPlayer, gameBoard);
                }
                else
                {
                    Console.WriteLine("Invalid move. Please enter a valid choice.");
                    continue; // Exit loop
                }

                Console.Clear();

                // Check for win after moves
                if (CheckForWin(gameBoard, currentPlayer.marker, out winMessage))
                {
                    Console.WriteLine($"Player {currentPlayer.id} wins!\n{winMessage}");
                    gameOver = true;
                    break;
                }

                // Check for draw
                if (!gameBoard.Any(row => row.Any(cell => cell != "X" && cell != "O")))
                {
                    Console.WriteLine("It's a draw!");
                    gameOver = true;
                    break;
                }

                // Switch the current player
                if (currentPlayer.id == "1")
                {
                    currentPlayer = player2;
                }
                else if (currentPlayer.id == "2")
                {
                    currentPlayer = player1;
                }
            }
        }

        static void DisplayBoard(string[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                string[] row = board[i];
                for (int x = 0; x < row.Length; x++)
                {
                    string value = row[x];
                    Console.Write("|" + value + "|");
                }
                Console.WriteLine();
            }
        }

        static void MarkBoard(string playerChoice, Player currentPlayer, string[][] gameBoard)
        {
            if (playerChoice == "1")
            {
                gameBoard[0][0] = currentPlayer.marker;
            }
            else if (playerChoice == "2")
            {
                gameBoard[0][1] = currentPlayer.marker;
            }
            else if (playerChoice == "3")
            {
                gameBoard[0][2] = currentPlayer.marker;
            }
            else if (playerChoice == "4")
            {
                gameBoard[1][0] = currentPlayer.marker;
            }
            else if (playerChoice == "5")
            {
                gameBoard[1][1] = currentPlayer.marker;
            }
            else if (playerChoice == "6")
            {
                gameBoard[1][2] = currentPlayer.marker;
            }
            else if (playerChoice == "7")
            {
                gameBoard[2][0] = currentPlayer.marker;
            }
            else if (playerChoice == "8")
            {
                gameBoard[2][1] = currentPlayer.marker;
            }
            else if (playerChoice == "9")
            {
                gameBoard[2][2] = currentPlayer.marker;
            }
        }

        static bool CheckForWin(string[][] gameBoard, string marker, out string winMessage)
        {
            winMessage = "";

            // Horizontal
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i][0] == marker && gameBoard[i][1] == marker && gameBoard[i][2] == marker)
                {
                    winMessage = $"Horizontal win in row {i + 1}";
                    return true; // Horizontal win
                }
            }

            // Vertical
            for (int i = 0; i < gameBoard[0].Length; i++)
            {
                if (gameBoard[0][i] == marker && gameBoard[1][i] == marker && gameBoard[2][i] == marker)
                {
                    winMessage = $"Vertical win in column {i + 1}";
                    return true; // Vertical win
                }
            }

            // Diagonal
            if (gameBoard[0][0] == marker && gameBoard[1][1] == marker && gameBoard[2][2] == marker)
            {
                winMessage = "Diagonal win (top-left to bottom-right)";
                return true; 
            }
            if (gameBoard[0][2] == marker && gameBoard[1][1] == marker && gameBoard[2][0] == marker)
            {
                winMessage = "Diagonal win (top-right to bottom-left)";
                return true; 
            }

            return false; // If no win happens
        }
    }
}
