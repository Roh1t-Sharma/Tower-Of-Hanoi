using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Game_Tower_of_Hanoi
{
    public class LeaderboardManager
    {
        private string leaderboardFilePath = "leaderboard.json";
        private List<PlayerScore> leaderboard = new List<PlayerScore>();
        public LeaderboardManager()
        {
            LoadLeaderboard();
        }

        public void AddToLeaderboard(string playerName, int score, int numDisks)
        {
            leaderboard.Add(new PlayerScore { Name = playerName, Score = score, NumDisks = numDisks });
            SaveLeaderboard();
        }


        public List<PlayerScore> GetLeaderboard()
        {
            leaderboard.Sort((a, b) => a.Score.CompareTo(b.Score));
            return leaderboard.GetRange(0, Math.Min(leaderboard.Count, 10));
        }

        public class PlayerScore
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public int NumDisks { get; set; }
        }

        private void LoadLeaderboard()
        {
            if (File.Exists(leaderboardFilePath))
            {
                string json = File.ReadAllText(leaderboardFilePath);
                leaderboard = JsonSerializer.Deserialize<List<PlayerScore>>(json);
            }
        }

        private void SaveLeaderboard()
        {
            leaderboard.Sort((a, b) => a.Score.CompareTo(b.Score));
            if (leaderboard.Count > 10)
            {
                leaderboard.RemoveRange(10, leaderboard.Count - 10);
            }

            string json = JsonSerializer.Serialize(leaderboard, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(leaderboardFilePath, json);
        }

    }
}