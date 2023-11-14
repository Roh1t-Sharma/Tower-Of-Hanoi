# Tower of Hanoi Game

## Overview
This project implements the classic Tower of Hanoi game in C#. The Tower of Hanoi is a mathematical puzzle that involves three rods and a number of disks of different sizes. The goal is to move the entire stack of disks from one rod to another, obeying specific rules: only one disk can be moved at a time, and a disk can only be placed on top of a larger disk or an empty rod.

## Features

- **User Interface:** Simple console-based user interface for an interactive gaming experience.
- **Difficulty Levels:** Choose from three difficulty levels: Easy (3 disks), Medium (4 disks), and Hard (5 disks).
- **Save and Load:** Save your game progress to continue later or load a previously saved game.
- **Leaderboard:** Compete for the best scores and view the leaderboard for each difficulty level.

## How to Play

1. **Run the Program:**
   - Open the project in a C# development environment.
   - Compile and run the program.

2. **Enter Player Name:**
   - Enter your name when prompted.

3. **Choose Difficulty Level:**
   - Select a difficulty level (Easy, Medium, or Hard).

4. **Gameplay:**
   - Enter moves by specifying the source and destination rods (e.g., 'AB').
   - Type 'S' to save the game, 'V' to view the leaderboard, and 'Q' to quit.

5. **Winning:**
   - The game is won when all disks are successfully moved to another rod.

6. **Leaderboard:**
   - View the leaderboard for each difficulty level to see the top scores.

## Save and Load
- Type 'S' during gameplay to save your current game progress.
- Upon restarting the program, you can choose to load a saved game.

## Leaderboard
- Type 'V' during gameplay to view the leaderboard for a specific difficulty level.
- Leaderboards are saved and loaded from a file (`leaderboard.json`).

## Error Handling
- The program includes error handling for various scenarios, such as invalid moves and file-related issues.
- Exception messages are displayed to guide the user in case of errors.

## Dependencies
- The project uses the Newtonsoft.Json library for JSON serialization/deserialization.

## Contributions
Contributions to this project are welcome. If you find issues or have suggestions, please open an issue or create a pull request.

