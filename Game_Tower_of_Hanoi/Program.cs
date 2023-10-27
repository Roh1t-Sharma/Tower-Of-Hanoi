using Game_Tower_of_Hanoi;
using System;

namespace Game_Tower_of_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            TowerOfHanoi game = new TowerOfHanoi(numDisks: 3);
            LeaderboardManager leaderboardManager = new LeaderboardManager();
            UserInterface userInterface = new UserInterface();

            bool playAgain = true; // Initialize playAgain to true

            while (playAgain)
            {
                bool quit = false;

                while (!quit)
                {
                    userInterface.DisplayGameBoard(game);
                    Console.WriteLine("Enter your moves (Enter Source & Destination rod)(e.g., ab).\nPress: 'V' to view" +
                                      " leaderboard;\n'Q' to quit");
                    string input = userInterface.GetUserInput().ToUpper();

                    if (input == "V")
                    {
                        var leaderboard = leaderboardManager.GetLeaderboard();
                        userInterface.DisplayLeaderBoard(leaderboard);
                    }
                    else if (input == "Q")
                    {
                        quit = true;
                    }
                    else
                    {
                        char sourceRod, destinationRod;
                        if (input.Length >= 2)
                        {
                            sourceRod = input[0];
                            destinationRod = input[1];
                            game.MoveDisk(sourceRod, destinationRod);
                        }
                        else
                        {
                            Console.WriteLine("Invalid move. Please enter source and destination rods (e.g., 'AB/ab').");
                            Console.ReadLine();
                        }
                    }

                    if (game.IsGameWon())
                    {
                        Console.WriteLine($"Congratulations! You won in {game.GetMoves()} moves.");
                        Console.WriteLine("Enter your name for the Leaderboard: ");

                        string playerName = userInterface.GetUserInput();
                        leaderboardManager.AddToLeaderboard(playerName, game.GetMoves(), game.GetDisks()); // Added number of disks
                        var leaderboard = leaderboardManager.GetLeaderboard();
                        userInterface.DisplayLeaderBoard(leaderboard);
                        quit = true;
                    }
                }

                userInterface.DisplayGameBoard(game);
                Console.WriteLine("Wanna give it another shot? (Y/N): ");
                string playAgainInput = userInterface.GetUserInput().ToUpper();
                playAgain = (playAgainInput == "Y");

                if (playAgain)
                {
                    game = new TowerOfHanoi(numDisks: 3);
                }
            }
        }
    }
}
