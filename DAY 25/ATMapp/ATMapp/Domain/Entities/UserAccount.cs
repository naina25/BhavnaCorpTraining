using System;
using System.Collections.Generic;
using System.Text;

namespace ATMapp.Domain.Entities
{
    public class UserAccount
    {
        public int id { get; set; }
        public long CardNumber { get; set; }
        public int CardPin { get; set; }
        public long AccountNumber { get; set; }
        public string FullName { get; set; }
        public decimal AccountBalance { get; set; }
        public int TotalLogin { get; set; }
        public bool isLocked { get; set; }

    }
}
