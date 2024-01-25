using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountsDemo.Models
{
    public class DepositRequest
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
