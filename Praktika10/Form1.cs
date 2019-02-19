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
            presskey.PressKeyDown(sender, e);            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
                timer1.Interval = 250;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnPause.Enabled = false;
            btnContinue.Enabled = false;
        }
    }
}
