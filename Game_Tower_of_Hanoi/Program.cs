using Game_Tower_of_Hanoi;
using System;

namespace Game_Tower_of_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface UserInterface = new UserInterface();
            LeaderboardManager leaderboardManager = new LeaderboardManager();

            bool playAgain = true;

            while (playAgain)
            {
                string playerName = UserInterface.GetPlayerName();
                int difficultyLevel = UserInterface.GetDifficultyLevel();

                TowerOfHanoi? game;

                // Load saved game or start a new game based on user input
                Console.WriteLine("Do you want to load a saved game? (Y/N): ");
                string loadGameChoice = UserInterface.GetUserInput().ToUpper();
                if (loadGameChoice == "Y")
                {
                    try
                    {
                        game = TowerOfHanoi.LoadGame("savegame.json");
                        Console.WriteLine("Game loaded successfully.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No saved game found. Starting a new game.");
                        game = new TowerOfHanoi(difficultyLevel);
                    }
                }
                else
                {
                    game = new TowerOfHanoi(difficultyLevel);
                }

                bool quit = false;
                while (!quit)
                {
                    UserInterface.DisplayGameBoard(game);
                    Console.WriteLine("Enter your move (source rod, destination rod), 'S' to save, 'V' to View ScoreBoard 'Q' to quit: ");
                    string input = UserInterface.GetUserInput().ToUpper();

                    if (input == "S")
                    {
                        game.SaveGame("savegame.json");
                        Console.WriteLine("Game saved successfully.");
                    }
                    else if (input == "L")
                    {
                        game = TowerOfHanoi.LoadGame("savegame.json");
                        Console.WriteLine("Game loaded successfully.");
                    }
                    else if (input == "V")
                    {
                        Console.WriteLine("Enter the number of disks (3, 4, or 5) to view the leaderboard: ");
                        if (int.TryParse(UserInterface.GetUserInput(), out int numDisks) && (numDisks == 3 || numDisks == 4 || numDisks == 5))
                        {
                            var leaderboard = leaderboardManager.GetLeaderboard(numDisks); // Pass the number of disks
                            UserInterface.DisplayLeaderBoard(leaderboard, numDisks); // Pass the number of disks
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for the number of disks.");
                        }
                    }
                    else if (input == "Q")
                    {
                        quit = true;
                        playAgain = false;
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
                            Console.WriteLine("Invalid move. Please enter source and destination rods (e.g., 'AB').");
                            Console.ReadLine();
                        }

                        if (game.IsGameWon())
                        {
                            UserInterface.DisplayGameBoard(game);
                            Console.WriteLine($"Congratulations! You won in {game.GetMoves()} moves.");
                            Console.WriteLine("Enter your name for the leaderboard: ");

                            int numDisks = game.GetDisks();
                            leaderboardManager.AddToLeaderboard(playerName, game.GetMoves(), numDisks);
                            var leaderboard = leaderboardManager.GetLeaderboard(numDisks);
                            UserInterface.DisplayLeaderBoard(leaderboard, numDisks);

                            Console.WriteLine("Do you want to play another game? (Y/N): ");
                            string playAgainInput = UserInterface.GetUserInput().ToUpper();
                            playAgain = (playAgainInput == "Y");
                            quit = true;
                        }
                    }
                }
            }
        }
    }
}
