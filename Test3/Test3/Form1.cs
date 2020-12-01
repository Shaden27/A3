using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test3
{
    public partial class Form1 : Form
    {
        Thread a, b;
        Bank bank = new Bank();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double dep = Convert.ToDouble(textBox1.Text);
            double test = bank.netBal + dep;
            if(bank.netBal>100000)
            {
                bank.netBal = bank.netBal + 0.7 * dep;
                Console.WriteLine("Tax Cut");
            }
            else if (test > 100000)
            {
                test = test - 100000;
                test = 0.3 * test;
                bank.netBal = bank.netBal + dep - test;
                MessageBox.Show("Tax Cut");
            }
            else
            {
                bank.netBal = bank.netBal + dep;
            }
            label1.Text = Convert.ToString(bank.netBal);
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double wit = Convert.ToDouble(textBox2.Text);
            double test = bank.netBal - wit;
            if (test < 5000)
            {
                MessageBox.Show("Cannot Withdraw Minimun Balance should be 5000");
            }
            else
            {
                bank.netBal = bank.netBal - wit;
            }
            label1.Text = Convert.ToString(bank.netBal);
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object lo = new object();
            lock (lo)
            {
                Bank b2 = new Bank();
                a = new Thread(bank.withdraw);
                b = new Thread(bank.deposit);
                label1.Text = Convert.ToString(bank.netBal);
            }
        }
        void ASC()
        {

        }
    }
}
