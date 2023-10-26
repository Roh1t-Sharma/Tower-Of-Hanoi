namespace Game_Tower_of_Hanoi;

public interface UserInterface
{
    public void DisplayGame(TowerOfHanoi game)
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
            Console.Write(new string(' ', 5 - disksize));

            Console.ResetColor();
        }
        Console.WriteLine();
    }

    private ConsoleColor GetDiskColor(int disksize)
    {
        switch (disksize)
        {
            case 1:
                return ConsoleColor.Red;
            case 2:
                return ConsoleColor.Green;
            case 3:
                return ConsoleColor.Blue;
            case 4:
                return ConsoleColor.White;
        }
    }
    
    public string GetUserInput()
    {
        return Console.ReadLine();
    }

    public void DisplayLeaderBoard(List<PlayerScore> leaderboard)
    {
        Console.WriteLine("LeaderBoard: \n");
        Console.WriteLine("Rank \t Player \t Moves");
        int rank = 1;
        foreach (var playerScore in leaderboard)
        {
            Console.WriteLine($"{rank} \t {playerScore.Name} \t {playerScore.Score}");
            rank++;
        }
    }
}