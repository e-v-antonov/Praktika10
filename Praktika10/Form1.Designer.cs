namespace Praktika10
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.miLevelEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.miLevelMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.miLevelHard = new System.Windows.Forms.ToolStripMenuItem();
            this.miRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.miCommonRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.miDiagramRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.miAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.miAboutAvtor = new System.Windows.Forms.ToolStripMenuItem();
            this.miRegulationGame = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pBox1
            // 
            this.pBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pBox1.Location = new System.Drawing.Point(24, 48);
            this.pBox1.Name = "pBox1";
            this.pBox1.Size = new System.Drawing.Size(429, 617);
            this.pBox1.TabIndex = 1;
            this.pBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(48, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPause.Location = new System.Drawing.Point(520, 312);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(120, 56);
            this.btnPause.TabIndex = 0;
            this.btnPause.TabStop = false;
            this.btnPause.Text = " Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnContinue.Location = new System.Drawing.Point(520, 408);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(120, 56);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.TabStop = false;
            this.btnContinue.Text = "Продолжить";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(520, 216);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 56);
            this.btnStart.TabIndex = 5;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLevel,
            this.miRecords,
            this.miAboutProgram,
            this.miAboutAvtor,
            this.miRegulationGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miLevel
            // 
            this.miLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLevelEasy,
            this.miLevelMedium,
            this.miLevelHard});
            this.miLevel.Name = "miLevel";
            this.miLevel.Size = new System.Drawing.Size(160, 24);
            this.miLevel.Text = "Уровень сложности";
            // 
            // miLevelEasy
            // 
            this.miLevelEasy.Checked = true;
            this.miLevelEasy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miLevelEasy.Name = "miLevelEasy";
            this.miLevelEasy.Size = new System.Drawing.Size(150, 26);
            this.miLevelEasy.Text = "Легкий";
            this.miLevelEasy.Click += new System.EventHandler(this.miLevelEasy_Click);
            // 
            // miLevelMedium
            // 
            this.miLevelMedium.Name = "miLevelMedium";
            this.miLevelMedium.Size = new System.Drawing.Size(150, 26);
            this.miLevelMedium.Text = "Средний";
            this.miLevelMedium.Click += new System.EventHandler(this.miLevelMedium_Click);
            // 
            // miLevelHard
            // 
            this.miLevelHard.Name = "miLevelHard";
            this.miLevelHard.Size = new System.Drawing.Size(150, 26);
            this.miLevelHard.Text = "Сложный";
            this.miLevelHard.Click += new System.EventHandler(this.miLevelHard_Click);
            // 
            // miRecords
            // 
            this.miRecords.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCommonRecords,
            this.miDiagramRecords});
            this.miRecords.Name = "miRecords";
            this.miRecords.Size = new System.Drawing.Size(81, 24);
            this.miRecords.Text = "Рекорды";
            // 
            // miCommonRecords
            // 
            this.miCommonRecords.Name = "miCommonRecords";
            this.miCommonRecords.Size = new System.Drawing.Size(292, 26);
            this.miCommonRecords.Text = "Общая таблица рекордов";
            this.miCommonRecords.Click += new System.EventHandler(this.miCommonRecords_Click);
            // 
            // miDiagramRecords
            // 
            this.miDiagramRecords.Name = "miDiagramRecords";
            this.miDiagramRecords.Size = new System.Drawing.Size(292, 26);
            this.miDiagramRecords.Text = "Диаграмма отношения очков";
            this.miDiagramRecords.Click += new System.EventHandler(this.miDiagramRecords_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(520, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 76);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(544, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Очки:";
            // 
            // miAboutProgram
            // 
            this.miAboutProgram.Name = "miAboutProgram";
            this.miAboutProgram.Size = new System.Drawing.Size(116, 24);
            this.miAboutProgram.Text = "О программе";
            this.miAboutProgram.Click += new System.EventHandler(this.miAboutProgram_Click);
            // 
            // miAboutAvtor
            // 
            this.miAboutAvtor.Name = "miAboutAvtor";
            this.miAboutAvtor.Size = new System.Drawing.Size(93, 24);
            this.miAboutAvtor.Text = "Об авторе";
            this.miAboutAvtor.Click += new System.EventHandler(this.miAboutAvtor_Click);
            // 
            // miRegulationGame
            // 
            this.miRegulationGame.Name = "miRegulationGame";
            this.miRegulationGame.Size = new System.Drawing.Size(121, 24);
            this.miRegulationGame.Text = "Правила игры";
            this.miRegulationGame.Click += new System.EventHandler(this.miRegulationGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 680);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.pBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тетрис";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.PictureBox pBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnPause;
        public System.Windows.Forms.Button btnContinue;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miLevel;
        private System.Windows.Forms.ToolStripMenuItem miLevelEasy;
        private System.Windows.Forms.ToolStripMenuItem miLevelMedium;
        private System.Windows.Forms.ToolStripMenuItem miLevelHard;
        public System.Windows.Forms.ToolStripMenuItem miRecords;
        private System.Windows.Forms.ToolStripMenuItem miCommonRecords;
        private System.Windows.Forms.ToolStripMenuItem miDiagramRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem miAboutProgram;
        private System.Windows.Forms.ToolStripMenuItem miAboutAvtor;
        private System.Windows.Forms.ToolStripMenuItem miRegulationGame;
    }
}

