namespace TicTacToe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1       = new System.Windows.Forms.Panel();
            this.lblStatus    = new System.Windows.Forms.Label();
            this.lblTitle     = new System.Windows.Forms.Label();
            this.btnRestart   = new System.Windows.Forms.Button();
            this.chkSinglePlayer = new System.Windows.Forms.CheckBox();
            this.lblScoreX    = new System.Windows.Forms.Label();
            this.lblScoreO    = new System.Windows.Forms.Label();
            this.lblScoreDraw = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ── Title ──────────────────────────────────────────────
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(0, 12);
            this.lblTitle.Size      = new System.Drawing.Size(460, 50);
            this.lblTitle.Text      = "Tic-Tac-Toe";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Status ─────────────────────────────────────────────
            this.lblStatus.AutoSize  = false;
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatus.ForeColor = System.Drawing.Color.LightYellow;
            this.lblStatus.Location  = new System.Drawing.Point(0, 65);
            this.lblStatus.Size      = new System.Drawing.Size(460, 30);
            this.lblStatus.Text      = "Player X's Turn";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Game board panel  (3×110 cells + 4×6 gaps = 354) ──
            this.panel1.Location  = new System.Drawing.Point(53, 105);
            this.panel1.Size      = new System.Drawing.Size(354, 354);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(25, 25, 55);

            // ── Score labels ───────────────────────────────────────
            this.lblScoreX.AutoSize  = false;
            this.lblScoreX.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScoreX.ForeColor = System.Drawing.Color.Tomato;
            this.lblScoreX.Location  = new System.Drawing.Point(20, 475);
            this.lblScoreX.Size      = new System.Drawing.Size(130, 25);
            this.lblScoreX.Text      = "X Wins: 0";
            this.lblScoreX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblScoreDraw.AutoSize  = false;
            this.lblScoreDraw.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScoreDraw.ForeColor = System.Drawing.Color.Gold;
            this.lblScoreDraw.Location  = new System.Drawing.Point(165, 475);
            this.lblScoreDraw.Size      = new System.Drawing.Size(130, 25);
            this.lblScoreDraw.Text      = "Draws: 0";
            this.lblScoreDraw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblScoreO.AutoSize  = false;
            this.lblScoreO.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScoreO.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblScoreO.Location  = new System.Drawing.Point(310, 475);
            this.lblScoreO.Size      = new System.Drawing.Size(130, 25);
            this.lblScoreO.Text      = "O Wins: 0";
            this.lblScoreO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Single-player checkbox ─────────────────────────────
            this.chkSinglePlayer.AutoSize  = false;
            this.chkSinglePlayer.Font      = new System.Drawing.Font("Segoe UI", 10F);
            this.chkSinglePlayer.ForeColor = System.Drawing.Color.White;
            this.chkSinglePlayer.Location  = new System.Drawing.Point(140, 510);
            this.chkSinglePlayer.Size      = new System.Drawing.Size(180, 25);
            this.chkSinglePlayer.Text      = "Single Player (vs AI)";
            this.chkSinglePlayer.CheckedChanged += new System.EventHandler(this.chkSinglePlayer_CheckedChanged);

            // ── Restart button ─────────────────────────────────────
            this.btnRestart.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Location  = new System.Drawing.Point(155, 548);
            this.btnRestart.Size      = new System.Drawing.Size(150, 42);
            this.btnRestart.Text      = "Restart Game";
            this.btnRestart.Click    += new System.EventHandler(this.btnRestart_Click);

            // ── Form ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(20, 20, 45);
            this.ClientSize          = new System.Drawing.Size(460, 610);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblScoreX);
            this.Controls.Add(this.lblScoreDraw);
            this.Controls.Add(this.lblScoreO);
            this.Controls.Add(this.chkSinglePlayer);
            this.Controls.Add(this.btnRestart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "Form1";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Tic-Tac-Toe";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.CheckBox chkSinglePlayer;
        private System.Windows.Forms.Label lblScoreX;
        private System.Windows.Forms.Label lblScoreO;
        private System.Windows.Forms.Label lblScoreDraw;
    }
}
