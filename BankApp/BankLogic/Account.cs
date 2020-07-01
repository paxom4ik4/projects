using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    public class Account
    {
        #region Fields
        private decimal _money;
        #endregion

        #region Properties
        public decimal Money
        {
            get
            {
                return _money;
            }
            set
            {
                if (value >= 0)
                {
                    _money = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Not enough money");
                }
            }
        }
        #endregion

        #region Ctors
        public Account()
        {
            Money = 0;
        }
        public Account(decimal money)
        {
            Money = money;
        }
        #endregion

    }
}
