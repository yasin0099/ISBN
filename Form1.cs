using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISBN_v2
{
    public partial class Form1 : Form
    {
        int z = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || !int.TryParse(textBox1.Text, out z) || textBox1.Text.Length < 10)
            {
                MessageBox.Show("Wrong Input");
                e.Cancel = true;
                DialogResult w = MessageBox.Show("Do you want to leave", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (w == DialogResult.Yes)
                {
                    System.Windows.Forms.Application.Exit();
                }

                else textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 10; int sum = 0; int y = 0;
            int[] b = new int[10];
            string a = textBox1.Text;
            for (int i = 0; i < 10; i++)
            {
                b[i] = Convert.ToInt32(a[i]);
                b[i] = b[i] - 48;
                if (i == 9)
                {
                    y = b[i];
                    break;
                }
                sum = sum + (b[i] * x);
                x--;

            }
            sum = sum % 11;
            sum = 11 - sum;
            if (sum == y) MessageBox.Show("ISBN No: "+a+" is ok");
            else MessageBox.Show("ISBN No: " + a + " not ok");

            DialogResult d = MessageBox.Show("Do you wish to continue", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                this.textBox1.Clear();
                textBox1.Focus();
                
            }
            else System.Windows.Forms.Application.Exit();
        }
    }
}
