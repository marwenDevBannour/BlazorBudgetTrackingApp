using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBudgetTrackingApp.Shared.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateTransaction { get; set; } = DateTime.Now.Date;
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number.")]
        public decimal Amount { get; set; }
        [Required]
        public string Desription { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
