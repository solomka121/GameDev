using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class GuesNumber : Form
    {
        Random rnd = new Random();
        private int _machineNumber;
        public GuesNumber()
        {
            InitializeComponent();

            _machineNumber = rnd.Next(1, 100);
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            string userNumber = InputBox.Text;
            int userInt;

            if (userNumber == null)
            {
                Result.Text = "Жду";
                return;
            }

            try
            {
                userInt = Int32.Parse(userNumber);

                int differences = _machineNumber - userInt;
                if (userInt == _machineNumber)
                {
                    Result.Text = "YES";
                    MessageBox.Show("You got it");
                    this.Close();
                }
                else if (differences < 20)
                {
                    Result.Text = "ещё ближе";
                } 
                else if (differences < 40)
                {
                    Result.Text = "Уже близко";
                }
                else
                {
                    Result.Text = "Совсем не то";
                }
               


            }
            catch (Exception exception)
            {
                Result.Text = "Это не цыфра (";
            }

        }
    }
}