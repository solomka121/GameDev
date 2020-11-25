using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int _a = 1;
        private int _lastNumber = 1;
        private int _clicksCount = 0;

        private int _randomNumber;

        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            _randomNumber = rnd.Next(24, 600);
            RandomNumber.Text = Convert.ToString(_randomNumber);
        }

        private void CheckNumber()
        {
            if (_a == _randomNumber)
            {
                MessageBox.Show($"WIN , Clicks used : {_clicksCount}");
                this.Close();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void PlusOne_Click(object sender, EventArgs e)
        {
            _lastNumber = _a;
            
            _clicksCount++;
            ClickerCounter.Text = Convert.ToString(_clicksCount);
            
            _a++;
            ResultText.Text = Convert.ToString(_a);

            CheckNumber();
        }

        private void PlusTwo_Click(object sender, EventArgs e)
        {
            _lastNumber = _a;
            
            _clicksCount++;
            ClickerCounter.Text = Convert.ToString(_clicksCount);
            
            _a = _a * 2;
            ResultText.Text = Convert.ToString(_a);

            CheckNumber();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            _lastNumber = _a;
            
            _clicksCount++;
            ClickerCounter.Text = Convert.ToString(_clicksCount);
            
            _a = 1;
            ResultText.Text = Convert.ToString(_a);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _a = _lastNumber;
            
            _clicksCount++;
            ClickerCounter.Text = Convert.ToString(_clicksCount);
            
            ResultText.Text = Convert.ToString(_a);
        }
    }
}