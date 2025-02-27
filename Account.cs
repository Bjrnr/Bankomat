using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Account
    {
        public Account(int accountNr, Double balance = 0)
        {
            AccountNr = accountNr;
            Balance = balance;
        }
        private Double _balance;

        public int AccountNr { get; }

        public Double Balance
        {
            get
            {
                return _balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("");
                }
                _balance = value;
            }
        }
        public void Deposit(Double Amount)
        {
            Balance += Amount;
        }
        public void WithDraw(Double Amount)
        {
            if (Balance < Amount)
            {
                throw new InvalidOperationException("");
            }
            Balance -= Amount;

        }
        public void Transfer(Account OtherAccount, Double Amount)
        {
            WithDraw(Amount);
            OtherAccount.Deposit(Amount);

        }

        public override string ToString()
        {
            return $"Kontonummer: {AccountNr} Salod: {Balance}";
        }
    }
}
