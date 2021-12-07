using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Transactions
{
    public enum TransactionStatus
    {
        /// <summary>
        /// Transaction successful
        /// </summary>
        SUCCESS,

        /// <summary>
        /// Transaction failed
        /// </summary>
        FAIL,
    }
}
