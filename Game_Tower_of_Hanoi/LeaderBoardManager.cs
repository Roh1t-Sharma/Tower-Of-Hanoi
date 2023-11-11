using System.Text.Json;

namespace Game_Tower_of_Hanoi
{
    public class LeaderboardManager
    {
        private readonly string _leaderboardFilePath = "leaderboard.json";
        private Dictionary<int, List<PlayerScore>>? _leaderboards = new Dictionary<int, List<PlayerScore>>();

        public LeaderboardManager()
        {
            LoadLeaderboard();
        }

        public void AddToLeaderboard(string? playerName, int score, int numDisks)
        {
            if (_leaderboards != null && !_leaderboards.ContainsKey(numDisks))
            {
                _leaderboards[numDisks] = new List<PlayerScore>();
            }

            _leaderboards?[numDisks].Add(new PlayerScore { Name = playerName, Score = score });
            SaveLeaderboard();
        }

        public List<PlayerScore> GetLeaderboard(int numDisks)
        {
            if (_leaderboards != null && _leaderboards.ContainsKey(numDisks))
            {
                _leaderboards[numDisks].Sort((a, b) => a.Score.CompareTo(b.Score));
                return _leaderboards[numDisks].GetRange(0, Math.Min(_leaderboards[numDisks].Count, 10));
            }
            return new List<PlayerScore>();
        }

        public class PlayerScore
        {
            public string? Name { get; set; }
            public int Score { get; set; }
        }

        private void LoadLeaderboard()
        {
            if (File.Exists(_leaderboardFilePath))
            {
                try
                {
                    string json = File.ReadAllText(_leaderboardFilePath);
                    _leaderboards = JsonSerializer.Deserialize<Dictionary<int, List<PlayerScore>>>(json);
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
            string json = JsonSerializer.Serialize(_leaderboards, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_leaderboardFilePath, json);
        }
    }
}
