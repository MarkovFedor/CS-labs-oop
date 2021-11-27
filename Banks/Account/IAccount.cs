using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Account
{
    public interface IAccount
    {
        void Withdraw(int amount);
        void Raise(int amount);
    }
}
