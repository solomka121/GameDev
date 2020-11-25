using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show(this);
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuesNumber gues = new GuesNumber();
            gues.Show(this);
            //this.Hide();
        }
    }
}