namespace Game_Tower_of_Hanoi;

class Program
{
    static void Main()
    {
        UserInterface userInterface = new UserInterface();
        LeaderboardManager leaderboardManager = new LeaderboardManager();

        bool playAgain = true;

        while (playAgain)
        {
            string? playerName = userInterface.GetPlayerName();
            DifficultyLevel difficultyLevel = userInterface.GetDifficultyLevel();

            TowerOfHanoi? game;

            // Load saved game or start a new game based on user input
            Console.WriteLine("Do you want to load a saved game? (Y/N): ");
            string? loadGameChoice = userInterface.GetUserInput()?.ToUpper();
            if (loadGameChoice == "Y")
            {
                try
                {
                    game = userInterface.LoadGameFromJson("savegame.json");
                    Console.WriteLine("Game loaded successfully.");
                }
                catch (Exception)
                {
                    Console.WriteLine("No saved game found. Starting a new game.");
                    game = new TowerOfHanoi((int)difficultyLevel);
                }
            }
            else
            {
                game = new TowerOfHanoi((int)difficultyLevel);
            }

            bool quit = false;
            while (!quit)
            {
                userInterface.DisplayGameBoard(game);
                Console.WriteLine("Enter your moves below (source-rod, destination-rod)");
                Console.WriteLine("Press:\n'S' to Save the game.\n'V' to View Leaderboard.\n'Q' to Quit. ");
                string? input = userInterface.GetUserInput()?.ToUpper();

                if (input == "S")
                {
                    userInterface.SaveGameToJson(game, "savegame.json");
                    Console.WriteLine("Game saved successfully.");
                }
                else if (input == "V")
                {
                    Console.WriteLine("Enter the level to view the leaderboard for: ");
                    Console.WriteLine(" 3 for Easy");
                    Console.WriteLine(" 4 for Medium");
                    Console.WriteLine(" 5 for Hard");

                    if (int.TryParse(userInterface.GetUserInput(), out int numDisks) && 
                        (numDisks == 3 || numDisks == 4 || numDisks == 5))
                    {
                        var leaderboard = leaderboardManager.GetLeaderboard(numDisks);
                        userInterface.DisplayLeaderBoard(leaderboard, numDisks);
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
                    if (input != null && input.Length >= 2)
                    {
                        char sourceRod = input[0];
                        char destinationRod = input[1];
                        game?.MoveDisk(sourceRod, destinationRod);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please enter source and destination rods (e.g., 'AB').");
                        Console.ReadLine();
                    }

                    if (game != null && game.IsGameWon())
                    {
                        userInterface.DisplayGameBoard(game);
                        Console.WriteLine($"Congratulations! You won in {game.GetMoves()} moves.");

                        int numDisks = game.GetDisks();
                        leaderboardManager.AddToLeaderboard(playerName, game.GetMoves(), numDisks);
                        var leaderboard = leaderboardManager.GetLeaderboard(numDisks);
                        userInterface.DisplayLeaderBoard(leaderboard, numDisks);

                        Console.WriteLine("Do you want to play another game? (Y/N): ");
                        string? playAgainInput = userInterface.GetUserInput()?.ToUpper();
                        playAgain = (playAgainInput == "Y");
                        quit = true;
                    }
                }
            }
        }
    }
}