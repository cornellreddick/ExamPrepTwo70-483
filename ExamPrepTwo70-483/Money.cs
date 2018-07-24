using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    class Money
    {
        //implementing an implicit and explict conversion operator 
        public decimal Amount { get; set; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }
    }
}
