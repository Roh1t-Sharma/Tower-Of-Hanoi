# Tower-Of-Hanoi
Console based application of the game "Tower of Hanoi" in C#. Developed by Angel Chama and Rohit Sharma.

### Task Analysis:

The task involves creating a console-based game called "Tower of Hanoi" using C#. The game includes a user interface for player interaction, a backend game logic implementation, and a leaderboard system to track player scores. Below is the documentation covering task analysis, application architecture, and leaderboard architecture.

### Application Architecture:

#### Game Architecture (`TowerOfHanoi` Class):

- The `TowerOfHanoi` class represents the game state.
- Private members:
  - `_moves`: Tracks the number of moves made in the game.
  - `_disks`: Represents the difficulty level (number of disks).
  - `_rodA`, `_rodB`, `_rodC`: Lists representing the three rods with disks.
- Public methods:
  - `GetRodA`, `GetRodB`, `GetRodC`: Accessors for the rods.
  - `GetDisks`: Accessor for the difficulty level.
  - `MoveDisk`: Moves a disk from one rod to another.
  - `IsGameWon`: Checks if the game is won.
  - `GetMoves`: Accessor for the number of moves.
  - `SaveGame`: Serializes and saves the game state to a JSON file.
  - `LoadGame`: Deserializes and loads the game state from a JSON file.

#### User Interface (`UserInterface` Class):

- The `UserInterface` class handles interactions with the player.
- Public methods:
  - `DisplayGameBoard`: Clears the console and displays the current game state.
  - `GetPlayerName`: Gets the player's name.
  - `GetDifficultyLevel`: Gets the desired difficulty level from the player.
  - `GetUserInput`: Gets user input from the console.
  - `DisplayLeaderBoard`: Displays the leaderboard for a specific number of disks.
  - `SaveGameToJson`: Serializes and saves the game state to a JSON file.
  - `LoadGameFromJson`: Deserializes and loads the game state from a JSON file.

#### Leaderboard Management (`LeaderboardManager` Class):

- The `LeaderboardManager` class manages the leaderboard.
- Private members:
  - `_leaderboardFilePath`: Path to the leaderboard JSON file.
  - `_leaderboards`: Dictionary storing player scores for different difficulty levels.
- Public methods:
  - `AddToLeaderboard`: Adds a player's score to the leaderboard.
  - `GetLeaderboard`: Retrieves the leaderboard for a specific number of disks.
  - `LoadLeaderboard`: Loads the leaderboard from the JSON file.
  - `SaveLeaderboard`: Saves the leaderboard to the JSON file.

### Database Architecture:

- The game state is saved and loaded using JSON files.
- Leaderboard information is stored in a JSON file.
- The structure of the leaderboard file is a dictionary with difficulty levels as keys and lists of player scores as values.

### Listing:

1. **Program.cs (`Program` Class):**
   - Manages the game loop, user interface, and leaderboard interactions.
   - Controls the flow of the game and handles player input.

2. **TowerOfHanoi.cs (`TowerOfHanoi` Class):**
   - Represents the game state and logic.
   - Manages the movement of disks, checks for a win condition, and handles serialization.

3. **UserInterface.cs (`UserInterface` Class):**
   - Manages interactions with the player.
   - Displays the game board, retrieves user input, and handles saving/loading game states.

4. **LeaderboardManager.cs (`LeaderboardManager` Class):**
   - Manages the leaderboard.
   - Handles adding scores, retrieving leaderboards, and saving/loading leaderboard data.

### Note:
- The `DifficultyLevel` enum defines the difficulty levels of the game.
- The project uses Newtonsoft.Json for JSON serialization/deserialization.

This documentation provides an overview of the project's structure and key components, facilitating understanding and future development.
