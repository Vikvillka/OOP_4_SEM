using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8_2
{
    public class Account
    {
        public Owner Owner { get; set; }
        public int? AccoyntNumber { get; set; }
        public string AccountType { get; set; }
        public int? Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public string Wallet { get; set; }

        public Account() { 
            Owner = new Owner();
        }    
    }
}
