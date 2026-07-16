# Tic-Tac-Toe Game (C# Windows Forms)

A Tic-Tac-Toe game built with **C# Windows Forms (.NET 10)**. Two players take turns marking a 3x3 grid, with win/draw detection, live score tracking, a restart option, and a single-player mode where the second player is controlled by an unbeatable AI using the **Minimax algorithm**.

## Features

- **Two-Player Mode** — Players alternate placing `X` and `O` marks by clicking cells on the board.
- **3x3 Grid Board** — Built dynamically at runtime as a `Button[3,3]` grid inside a `Panel`, styled with custom colors for idle, X, O, and winning cells.
- **Win Detection** — Checks all 3 rows, 3 columns, and both diagonals after every move.
- **Draw Detection** — If all 9 cells are filled with no winner, the game is declared a draw.
- **Winning Line Highlight** — The three winning cells are highlighted in green when a player wins.
- **Game-Over Message Box** — A `MessageBox` announces the winner or a draw.
- **Live Scoreboard** — Tracks and displays running totals of X wins, O wins, and draws across rounds.
- **Restart Button** — Clears the board and starts a new round without resetting the scoreboard.
- **Bonus: Single-Player Mode (vs Computer)** — A checkbox toggles single-player mode. When enabled, Player O is controlled by the computer using the **Minimax algorithm**, making it play optimally (unbeatable). A short delay (`Task.Delay(400)`) is added before the AI's move so it doesn't feel instant.

## Requirements

- Windows OS
- .NET 10 SDK (Windows Forms support — `net10.0-windows` target framework)
- Visual Studio 2022 (17.8+) or later, or the `dotnet` CLI

## Project Structure

```
TicTacToe/
├── TicTacToe.csproj          # Project file (net10.0-windows, WinForms enabled)
├── Program.cs                 # Application entry point (Main)
├── Form1.cs                    # Game logic: moves, win/draw checks, scoring, Minimax AI
├── Form1.Designer.cs           # UI layout (title, status label, panel, score labels, buttons, checkbox)
└── README.md
```

## How to Run

### Visual Studio
1. Clone the repository:
   ```
   git clone <your-repo-url>
   ```
2. Open `TicTacToe.csproj` (or the containing solution) in Visual Studio 2022.
3. Build the project (**Build > Build Solution** or `Ctrl+Shift+B`).
4. Run the application (**Debug > Start Without Debugging** or `Ctrl+F5`).

### CLI
```
dotnet build
dotnet run
```

## How to Play

1. Launch the game — Player **X** always goes first, shown in the status label at the top ("Player X's Turn").
2. Click any empty cell on the 3x3 grid to place your mark.
3. Players alternate turns until:
   - A player forms 3 matching marks in a row, column, or diagonal → that player wins, and the winning line is highlighted green.
   - All 9 cells fill with no winner → the game is a draw.
4. A message box announces the result, and the scoreboard (X Wins / O Wins / Draws) updates.
5. Click **Restart Game** to clear the board and play another round (scores persist).

## Bonus: Single-Player Mode

- Check **"Single Player (vs AI)"** to switch from two-human mode to Player vs Computer.
- In this mode, you play as **X**, and the computer plays as **O**.
- After your move, the board is briefly disabled while the AI "thinks," then the computer selects its move.
- The AI uses the **Minimax algorithm** (`Minimax(depth, isMaximising)`) to evaluate every possible future board state recursively and always picks the optimal move — meaning it plays perfectly and cannot be beaten (best case for the human is a draw).
- Toggling the checkbox at any time resets the board for the new mode.

## Win Conditions Checked

- 3 rows
- 3 columns
- 2 diagonals

## Possible Future Improvements

- Difficulty levels for the AI (e.g., random-move "Easy" mode vs. Minimax "Hard" mode)
- Persist scores across app restarts
- Sound effects and win animations
- Customizable player names

## Author

Maarij — Air University
