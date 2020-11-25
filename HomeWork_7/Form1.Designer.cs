namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlusOne = new System.Windows.Forms.Button();
            this.PlusTwo = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.ResultText = new System.Windows.Forms.Label();
            this.ClickerCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RandomNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlusOne
            // 
            this.PlusOne.Location = new System.Drawing.Point(12, 211);
            this.PlusOne.Name = "PlusOne";
            this.PlusOne.Size = new System.Drawing.Size(103, 37);
            this.PlusOne.TabIndex = 0;
            this.PlusOne.Text = "+1";
            this.PlusOne.UseVisualStyleBackColor = true;
            this.PlusOne.Click += new System.EventHandler(this.PlusOne_Click);
            // 
            // PlusTwo
            // 
            this.PlusTwo.Location = new System.Drawing.Point(144, 211);
            this.PlusTwo.Name = "PlusTwo";
            this.PlusTwo.Size = new System.Drawing.Size(100, 37);
            this.PlusTwo.TabIndex = 1;
            this.PlusTwo.Text = "+2";
            this.PlusTwo.UseVisualStyleBackColor = true;
            this.PlusTwo.Click += new System.EventHandler(this.PlusTwo_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(269, 211);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(101, 37);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // ResultText
            // 
            this.ResultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ResultText.Location = new System.Drawing.Point(159, 102);
            this.ResultText.Name = "ResultText";
            this.ResultText.Size = new System.Drawing.Size(100, 39);
            this.ResultText.TabIndex = 3;
            this.ResultText.Text = "1";
            // 
            // ClickerCounter
            // 
            this.ClickerCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ClickerCounter.Location = new System.Drawing.Point(333, 9);
            this.ClickerCounter.Name = "ClickerCounter";
            this.ClickerCounter.Size = new System.Drawing.Size(37, 21);
            this.ClickerCounter.TabIndex = 4;
            this.ClickerCounter.Text = "0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(11, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ваше Число :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Нужное Число :";
            // 
            // RandomNumber
            // 
            this.RandomNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.RandomNumber.Location = new System.Drawing.Point(159, 19);
            this.RandomNumber.Name = "RandomNumber";
            this.RandomNumber.Size = new System.Drawing.Size(100, 39);
            this.RandomNumber.TabIndex = 7;
            this.RandomNumber.Text = "1";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label4.Location = new System.Drawing.Point(241, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Нажатие :";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(269, 152);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 37);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(382, 284);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RandomNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClickerCounter);
            this.Controls.Add(this.ResultText);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.PlusTwo);
            this.Controls.Add(this.PlusOne);
            this.Name = "Form1";
            this.Text = "Double";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button CancelButton;

        private System.Windows.Forms.Label RandomNumber;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label ClickerCounter;

        private System.Windows.Forms.Label ResultText;

        private System.Windows.Forms.Button PlusOne;
        private System.Windows.Forms.Button PlusTwo;
        private System.Windows.Forms.Button Reset;

        #endregion
    }
}