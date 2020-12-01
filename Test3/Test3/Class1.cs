using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    class Bank
    {
        public double netBal;
        public Bank()
        {
            netBal = 5000;
        }
        public void deposit()
        {
            double dep=0;
            double test = netBal + dep;
            if (test > 100000)
            {
                test = test - 100000;
                test = 0.7 * test;
                netBal = netBal + dep - test;
                Console.WriteLine("Tax Cut");
            }
            else
            {
                netBal = netBal + dep;
            }
        }
        public void withdraw()
        {
            double wit = 0;
            double test = netBal - wit;
            if (test < 5000)
            {
                Console.WriteLine("Cannot Withdraw Minimun Balance should ve 5000");
            }
            else
            {
                netBal = netBal - wit;
            }
        }
    }
    
}
