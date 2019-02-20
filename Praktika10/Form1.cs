using System;
using System.Drawing;
using System.Windows.Forms;

namespace Praktika10
{
    public partial class Form1 : Form
    {
        Figure figure = new Figure();
        Field field = new Field();
        Movement movement = new Movement();
        PressKey presskey = new PressKey();
       

        public Form1()
        {
            Program.form1 = this;
            InitializeComponent();
            figure.ChoiceFigure();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            movement.MovementTimer();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.SuppressKeyPress = true;
            presskey.PressKeyDown(sender, e);            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                if (miLevelEasy.Checked == true)
                    timer1.Interval = 250;
                else
                    if (miLevelMedium.Checked == true)
                        timer1.Interval = 170;
                    else
                        if (miLevelHard.Checked == true)
                            timer1.Interval = 100;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnPause.Enabled = false;
            btnContinue.Enabled = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnContinue.Enabled = false;
            btnPause.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            field.ResetArray();
            movement.points = 0;
            label1.Text = movement.points.ToString();
            timer1.Enabled = true;
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            movement.newGame = true;
            menuStrip1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnPause.Enabled = false;
            btnContinue.Enabled = false;

            if (Avtoriz.simpleGame == true)
                miRecords.Enabled = false;
        }

        private void miLevelEasy_Click(object sender, EventArgs e)
        {
            miLevelEasy.Checked = true;
            miLevelMedium.Checked = false;
            miLevelHard.Checked = false;
            timer1.Interval = 250;
        }

        private void miLevelMedium_Click(object sender, EventArgs e)
        {
            miLevelEasy.Checked = false;
            miLevelMedium.Checked = true;
            miLevelHard.Checked = false;
            timer1.Interval = 170;
        }

        private void miLevelHard_Click(object sender, EventArgs e)
        {
            miLevelEasy.Checked = false;
            miLevelMedium.Checked = false;
            miLevelHard.Checked = true;
            timer1.Interval = 100;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void miCommonRecords_Click(object sender, EventArgs e)
        {
            TableRecord tableRecord = new TableRecord();
            tableRecord.Show();
        }

        private void miDiagramRecords_Click(object sender, EventArgs e)
        {
            Diagram diagram = new Diagram();
            diagram.Show();
        }

        private void miAboutProgram_Click(object sender, EventArgs e)
        {
            AboutProgram aboutProgram = new AboutProgram();
            aboutProgram.Show();
        }

        private void miAboutAvtor_Click(object sender, EventArgs e)
        {
            AboutAvtor aboutAvtor = new AboutAvtor();
            aboutAvtor.Show();
        }

        private void miRegulationGame_Click(object sender, EventArgs e)
        {
            RegulationGame regulationGame = new RegulationGame();
            regulationGame.Show();
        }
    }
}
