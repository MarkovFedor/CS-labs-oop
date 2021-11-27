using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.BankStructures
{
    public class CentralBank
    {
        public CentralBank()
        {
        }

        public Bank CreateBank(string name)
        {
            return new Bank(name);
        }

        public void DoTransaction()
        {

        }
    }
}
