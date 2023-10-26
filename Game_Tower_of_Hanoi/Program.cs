using Game_Tower_of_Hanoi;
using System;
using System.Net.Quic;

namespace Game_Tower_of_Hanoi
{
    class Program
    {
        public static bool playagain;

        static void Main(string[] args)
        {
            TowerOfHanoi game = new TowerOfHanoi(numDisks: 3);
            GameSerializer serializer = new GameSerializer();
            LeaderBoardManager leaderBoardManager = new LeaderBoardManager();
            UserInterface userInterface = new UserInterface();

            bool quit = false;
            while (!quit)
            {
                userInterface.DisplayGameBoard(game);
                Console.WriteLine("Enter your moves(Enter Source & Destination rod)(e.g., ab).\nPress: 'S' to save;\n" +
                                  "'L' to load;\n'V' to view leaderboard;\n'Q' to quit");
                string input = userInterface.GetUserInput().ToUpper();
                
                if (input == "S")
                {
                    serializer.SaveGame(game, "savegame.xml");
                    Console.WriteLine("Game saved successfully.");
                }
                
                else if (input == "L")
                {
                    game = serializer.Loadgame("savegame.xml");
                    Console.WriteLine("Loading Game.");
                }
                
                else if (input == "V")
                {
                    var leaderboard = leaderBoardManager.GetLeaderboard();
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
                    leaderBoardManager.AddToLeaderBoard(playerName, game.GetMoves());
                    var leaderboard = leaderBoardManager.GetLeaderboard();
                    userInterface.DisplayLeaderBoard(leaderboard);
                    quit = true;
                }

                else
                {
                    char sourceRod = input[0];
                    char destinationRod = input[1];
                    game.MoveDisk(sourceRod, destinationRod);

                    if (game.IsGameWon())
                    {
                        userInterface.DisplayGameBoard(game);
                        Console.WriteLine($"Congratualations! You won the game in {game.GetMoves()} moves.\n");
                        break;
                    }
                }
            }
            
            Console.WriteLine("Wanna give it an another shot? (Y/N): ");
            string playAgainInput = userInterface.GetUserInput().ToUpper();
            playagain = (playAgainInput == "Y");
        }
    }
}