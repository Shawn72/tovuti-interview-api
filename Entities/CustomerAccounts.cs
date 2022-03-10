using System;
using System.ComponentModel.DataAnnotations;

namespace TovutiAPI.Entities
{
    public class CustomerAccounts
    {
        [Key]
        public Int64 id { get; set; }
        public Int64 customer_id { get; set; }
        public string account_number { get; set; }
        public decimal account_balance { get; set; }
        public bool active { get; set; }
    }
}
