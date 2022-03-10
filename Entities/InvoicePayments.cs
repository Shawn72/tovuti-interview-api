using System;
using System.ComponentModel.DataAnnotations;

namespace TovutiAPI.Entities
{
    public class InvoicePayments
    {
        [Key]
        public Int64 id { get; set; }
        public Int64 invc_id { get; set; }
        public DateTime date_paid { get; set; }
        public decimal amount_paid { get; set; }
    }
}
