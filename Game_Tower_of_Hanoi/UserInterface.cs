using Newtonsoft.Json;

namespace Game_Tower_of_Hanoi
{
    public enum DifficultyLevel
    {
        Easy = 3,
        Medium = 4,
        Hard = 5
    }

    public class UserInterface
    {
        private const int MaxDisks = 5; 
        private readonly int[] _towerSizes = new int[MaxDisks];

        public UserInterface()
        {
            // Initializing tower sizes array with incremental disk values.
            for (int i = 0; i < MaxDisks; i++)
            {
                _towerSizes[i] = i + 1;
            }
        }
        
        public void DisplayGameBoard(TowerOfHanoi? game)
        {
            Console.Clear();
            Console.WriteLine("  Tower Of Hanoi  ");
            Console.WriteLine("———————————————————");
            if (game != null)
            {
                Console.WriteLine($"Moves: {game.GetMoves()}\n");

                Console.Write("Rod A: ");
                DisplayRod(game.GetRodA());

                Console.Write("Rod B: ");
                DisplayRod(game.GetRodB());

                Console.Write("Rod C: ");
                DisplayRod(game.GetRodC());
            }

            Console.WriteLine("\n");
        }

        // Displaying a single rod with disks.
        private void DisplayRod(List<int> rod)
        {
            foreach (var disksize in rod)
            {
                ConsoleColor color = GetDiskColor(disksize);
                Console.ForegroundColor = color;
                Console.Write(new string('#', disksize));
                Console.Write(new string(' ', 7 - disksize));
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private ConsoleColor GetDiskColor(int diskSize)
        {
            switch (diskSize)
            {
                case 1:
                    return ConsoleColor.Red;
                case 2:
                    return ConsoleColor.Green;
                case 3:
                    return ConsoleColor.Blue;
                case 4:
                    return ConsoleColor.Yellow;
                case 5:
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.White; 
            }
        }

        
        public string? GetPlayerName()
        {
            Console.WriteLine("Enter your name: ");
            return Console.ReadLine();
        }

        // Getting the desired difficulty level from the player.
        public DifficultyLevel GetDifficultyLevel()
        {
            Console.WriteLine("Choose difficulty Level: ");
            Console.WriteLine("1. Easy (3 Disks)");
            Console.WriteLine("2. Medium (4 Disks)");
            Console.WriteLine("3. Hard (5 Disks)");

            int choice = 0;
            while (choice < 1 || choice > 3)
            {
                Console.WriteLine("Enter your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
            }

            switch (choice)
            {
                case 1:
                    return DifficultyLevel.Easy;
                case 2:
                    return DifficultyLevel.Medium;
                case 3:
                    return DifficultyLevel.Hard;
                default:
                    return DifficultyLevel.Easy;
            }
        }
        
        public string? GetUserInput() // to get user input from the console.
        {
            return Console.ReadLine();
        }

        // to display the leaderboard for a specific number of disks.
        public void DisplayLeaderBoard(List<LeaderboardManager.PlayerScore> leaderboard, int numDisks)
        {
            Console.WriteLine($"Leaderboard for {numDisks} disks:\n");
            Console.WriteLine("Rank\tPlayer\tMoves");
            int rank = 1;
            foreach (var playerScore in leaderboard)
            {
                Console.WriteLine($"{rank}\t{playerScore.Name}\t{playerScore.Score}");
                rank++;
            }
        }

        // Saving the game state to the JSON file.
        public void SaveGameToJson(TowerOfHanoi? game, string fileName)
        {
            string json = JsonConvert.SerializeObject(game); // Serializing game data to JSON.
            File.WriteAllText(fileName, json); // Writing JSON data to a file.
            Console.WriteLine($"Game saved to {fileName} successfully.");
        }

        // Loading the game state from the JSON file.
        public TowerOfHanoi? LoadGameFromJson(string fileName)
        {
            if (File.Exists(fileName)) //to check if the file exists.
            {
                string json = File.ReadAllText(fileName); // to read JSON data from JSON file
                TowerOfHanoi? loadedGame = JsonConvert.DeserializeObject<TowerOfHanoi>(json); // Deserializing JSON data to the TowerOfHanoi object.
                Console.WriteLine($"Game loaded from {fileName} successfully.");
                return loadedGame;
            }
            else
            {
                Console.WriteLine("No saved game found.");
                return null;
            }
        }
    }
}
