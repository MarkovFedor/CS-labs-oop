using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Notifications
{
    public class BankNotification
    {
        private int _dailyDepositePercent;
        private int _transferLimit;
        private int _commission;
        private int _creditLimit;
        public BankNotification(int dailyDepositePercent, int transferLimit, int commission, int creditLimit)
        {
            _dailyDepositePercent = dailyDepositePercent;
            _transferLimit = transferLimit;
            _commission = commission;
            _creditLimit = creditLimit;
        }

        public int GetDailyDepositePercent()
        {
            return _dailyDepositePercent;
        }

        public int GetTransferLimit()
        {
            return _transferLimit;
        }

        public int GetCommission()
        {
            return _commission;
        }

        public int GetCreditLimit()
        {
            return _creditLimit;
        }
    }
}
