using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
        private int[] towerSizes = new int[MaxDisks];

        public UserInterface()
        {
            for (int i = 0; i < MaxDisks; i++)
            {
                towerSizes[i] = i + 1;
            }
        }

        public void DisplayGameBoard(TowerOfHanoi game)
        {
            Console.Clear();
            Console.WriteLine("Game of Tower Of Hanoi");
            Console.WriteLine("———————————————————————");
            Console.WriteLine($"Moves: {game.GetMoves()}\n");

            Console.Write("Rod A: ");
            DisplayRod(game.GetRodA());

            Console.Write("Rod B: ");
            DisplayRod(game.GetRodB());

            Console.Write("Rod C: ");
            DisplayRod(game.GetRodC());

            Console.WriteLine("\n");
        }

        private void DisplayRod(List<int> rod)
        {
            foreach (var disksize in rod)
            {
                ConsoleColor color = GetDiskColor(disksize);
                Console.ForegroundColor = color;
                Console.Write(new string('*', disksize));
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

        public string GetPlayerName()
        {
            Console.WriteLine("Enter your name: ");
            return Console.ReadLine();
        }

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

        // Other existing methods...

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

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

        public void SaveGameToJson(TowerOfHanoi game, string fileName)
        {
            string json = JsonConvert.SerializeObject(game);
            File.WriteAllText(fileName, json);
            Console.WriteLine($"Game saved to {fileName} successfully.");
        }

        public TowerOfHanoi LoadGameFromJson(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                TowerOfHanoi loadedGame = JsonConvert.DeserializeObject<TowerOfHanoi>(json);
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
