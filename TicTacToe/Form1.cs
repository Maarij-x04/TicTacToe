using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Button[,] gridButtons = new Button[3, 3];
        private string[,] board       = new string[3, 3];
        private bool isXTurn    = true;
        private bool gameOver   = false;
        private bool singlePlayer = false;

        private int scoreX = 0, scoreO = 0, scoreDraw = 0;

        private readonly Color BtnIdle = Color.FromArgb(40, 40, 80);
        private readonly Color BtnX    = Color.FromArgb(220, 70, 70);
        private readonly Color BtnO    = Color.FromArgb(70, 140, 220);
        private readonly Color BtnWin  = Color.FromArgb(60, 180, 80);

        public Form1()
        {
            InitializeComponent();
            CreateGrid();
            ResetBoard();
        }

        private void CreateGrid()
        {
            const int cell = 110;
            const int gap  = 6;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    int row = r;
                    int col = c;

                    var btn = new Button
                    {
                        Size      = new Size(cell, cell),
                        Location  = new Point(gap + c * (cell + gap), gap + r * (cell + gap)),
                        // Smaller font so text is always visible
                        Font      = new Font("Arial", 32F, FontStyle.Bold),
                        BackColor = BtnIdle,
                        // Use dark forecolor so disabled state still shows text clearly
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Text      = "",
                        TabStop   = false,
                        UseVisualStyleBackColor = false
                    };
                    btn.FlatAppearance.BorderColor            = Color.FromArgb(80, 80, 130);
                    btn.FlatAppearance.BorderSize             = 2;
                    btn.FlatAppearance.MouseOverBackColor     = Color.FromArgb(65, 65, 115);
                    btn.FlatAppearance.MouseDownBackColor     = Color.FromArgb(50, 50, 100);

                    btn.Click += (s, e) => OnCellClick(row, col);

                    gridButtons[r, c] = btn;
                    panel1.Controls.Add(btn);
                }
            }
        }

        private async void OnCellClick(int row, int col)
        {
            if (gameOver) return;
            if (board[row, col] != "") return;

            // Place human mark
            string mark = isXTurn ? "X" : "O";
            PlaceMark(row, col, mark);

            if (CheckEndState()) return;

            // AI move
            if (singlePlayer && !isXTurn && !gameOver)
            {
                // Lock board during AI delay
                foreach (Button b in panel1.Controls)
                    b.Enabled = false;

                await Task.Delay(400);

                if (!gameOver)
                {
                    AIMove();
                    CheckEndState();
                }

                // Re-enable empty cells
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        if (board[r, c] == "")
                            gridButtons[r, c].Enabled = true;
            }
        }

        private void PlaceMark(int row, int col, string mark)
        {
            board[row, col] = mark;

            var btn = gridButtons[row, col];
            btn.Text = mark;

            // Change colour based on mark
            if (mark == "X")
            {
                btn.ForeColor = BtnX;
                btn.BackColor = Color.FromArgb(60, 30, 30);
            }
            else
            {
                btn.ForeColor = BtnO;
                btn.BackColor = Color.FromArgb(30, 40, 70);
            }

            // DO NOT disable button — just ignore clicks via board[] check
            // This ensures text always renders correctly
            isXTurn = !isXTurn;

            if (!gameOver)
                lblStatus.Text = $"Player {(isXTurn ? "X" : "O")}'s Turn";
        }

        private bool CheckEndState()
        {
            string winner = GetWinner();

            if (winner != null)
            {
                gameOver = true;
                HighlightWinner();

                if (winner == "X") { scoreX++;   lblScoreX.Text    = $"X Wins: {scoreX}"; }
                else               { scoreO++;   lblScoreO.Text    = $"O Wins: {scoreO}"; }

                lblStatus.Text = $"Player {winner} Wins!";
                MessageBox.Show($"Player {winner} wins!", "Game Over",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            if (IsDraw())
            {
                gameOver = true;
                scoreDraw++;
                lblScoreDraw.Text = $"Draws: {scoreDraw}";
                lblStatus.Text    = "It's a Draw!";
                MessageBox.Show("It's a Draw!", "Game Over",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        private string GetWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] != "" && board[i,0] == board[i,1] && board[i,1] == board[i,2]) return board[i,0];
                if (board[0,i] != "" && board[0,i] == board[1,i] && board[1,i] == board[2,i]) return board[0,i];
            }
            if (board[0,0] != "" && board[0,0] == board[1,1] && board[1,1] == board[2,2]) return board[0,0];
            if (board[0,2] != "" && board[0,2] == board[1,1] && board[1,1] == board[2,0]) return board[0,2];
            return null;
        }

        private void HighlightWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] != "" && board[i,0] == board[i,1] && board[i,1] == board[i,2])
                { gridButtons[i,0].BackColor=BtnWin; gridButtons[i,1].BackColor=BtnWin; gridButtons[i,2].BackColor=BtnWin; return; }
                if (board[0,i] != "" && board[0,i] == board[1,i] && board[1,i] == board[2,i])
                { gridButtons[0,i].BackColor=BtnWin; gridButtons[1,i].BackColor=BtnWin; gridButtons[2,i].BackColor=BtnWin; return; }
            }
            if (board[0,0] != "" && board[0,0] == board[1,1] && board[1,1] == board[2,2])
            { gridButtons[0,0].BackColor=BtnWin; gridButtons[1,1].BackColor=BtnWin; gridButtons[2,2].BackColor=BtnWin; return; }
            if (board[0,2] != "" && board[0,2] == board[1,1] && board[1,1] == board[2,0])
            { gridButtons[0,2].BackColor=BtnWin; gridButtons[1,1].BackColor=BtnWin; gridButtons[2,0].BackColor=BtnWin; }
        }

        private bool IsDraw()
        {
            foreach (var cell in board)
                if (cell == "") return false;
            return true;
        }

        private void AIMove()
        {
            int bestScore = int.MinValue, bestRow = 0, bestCol = 0;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (board[r, c] == "")
                    {
                        board[r, c] = "O";
                        int score = Minimax(0, false);
                        board[r, c] = "";
                        if (score > bestScore) { bestScore = score; bestRow = r; bestCol = c; }
                    }
            PlaceMark(bestRow, bestCol, "O");
        }

        private int Minimax(int depth, bool isMaximising)
        {
            string w = GetWinner();
            if (w == "O") return 10 - depth;
            if (w == "X") return depth - 10;
            if (IsDraw())  return 0;

            if (isMaximising)
            {
                int best = int.MinValue;
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        if (board[r,c] == "") { board[r,c]="O"; best=Math.Max(best,Minimax(depth+1,false)); board[r,c]=""; }
                return best;
            }
            else
            {
                int best = int.MaxValue;
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        if (board[r,c] == "") { board[r,c]="X"; best=Math.Min(best,Minimax(depth+1,true)); board[r,c]=""; }
                return best;
            }
        }

       private void ResetBoard()
{
    board = new string[3, 3];

    for (int r = 0; r < 3; r++)
        for (int c = 0; c < 3; c++)
            board[r, c] = "";

    isXTurn = true;
    gameOver = false;
    lblStatus.Text = "Player X's Turn";

    for (int r = 0; r < 3; r++)
        for (int c = 0; c < 3; c++)
        {
            gridButtons[r, c].Text = "";
            gridButtons[r, c].BackColor = BtnIdle;
            gridButtons[r, c].ForeColor = Color.White;
            gridButtons[r, c].Enabled = true;
        }
}
        private void btnRestart_Click(object sender, EventArgs e) => ResetBoard();

        private void chkSinglePlayer_CheckedChanged(object sender, EventArgs e)
        {
            singlePlayer = chkSinglePlayer.Checked;
            ResetBoard();
        }
    }
}