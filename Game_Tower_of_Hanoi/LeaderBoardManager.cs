using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Game_Tower_of_Hanoi
{
    public class LeaderboardManager
    {
        private string leaderboardFilePath = "leaderboard.json";
        private Dictionary<int, List<PlayerScore>> leaderboards = new Dictionary<int, List<PlayerScore>>();

        public LeaderboardManager()
        {
            LoadLeaderboard();
        }

        public void AddToLeaderboard(string playerName, int score, int numDisks)
        {
            if (!leaderboards.ContainsKey(numDisks))
            {
                leaderboards[numDisks] = new List<PlayerScore>();
            }

            leaderboards[numDisks].Add(new PlayerScore { Name = playerName, Score = score });
            SaveLeaderboard();
        }

        public List<PlayerScore> GetLeaderboard(int numDisks)
        {
            if (leaderboards.ContainsKey(numDisks))
            {
                leaderboards[numDisks].Sort((a, b) => a.Score.CompareTo(b.Score));
                return leaderboards[numDisks].GetRange(0, Math.Min(leaderboards[numDisks].Count, 10));
            }
            return new List<PlayerScore>();
        }

        public class PlayerScore
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }

        private void LoadLeaderboard()
        {
            if (File.Exists(leaderboardFilePath))
            {
                try
                {
                    string json = File.ReadAllText(leaderboardFilePath);
                    leaderboards = JsonSerializer.Deserialize<Dictionary<int, List<PlayerScore>>>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading leaderboard: " + ex.Message);
                    // Handle the error, e.g., create a new leaderboard or report the issue.
                }
            }
            else
            {
                Console.WriteLine("Leaderboard file not found. Creating a new leaderboard.");
                // Handle the case where the file doesn't exist, e.g., create a new leaderboard.
            }
        }


        private void SaveLeaderboard()
        {
            string json = JsonSerializer.Serialize(leaderboards, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(leaderboardFilePath, json);
        }
    }
}