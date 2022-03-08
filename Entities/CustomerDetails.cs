using System;
using System.ComponentModel.DataAnnotations;

namespace TovutiAPI.Entities
{
    public class CustomerDetails
    {
        [Key]
        public Int64 id { get; set; }
        public string user_id { get; set; }
        public decimal credit_limit { get; set; } 
        public string payment_terms { get; set; }     
    }
}
