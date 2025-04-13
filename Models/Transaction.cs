using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashFlowz.Models
{
    public enum TransactionType
    {
        Income,
        Expense
    }

    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; } // Use decimal for currency
        public TransactionType Type { get; set; }
        public string Category { get; set; } // Add categories later

        // Constructor
        public Transaction(DateTime date, string description, decimal amount, TransactionType type, string category = "Uncategorized")
        {
            Date = date;
            Description = description ?? string.Empty; // Ensure not null
            Amount = amount;
            Type = type;
            Category = category ?? "Uncategorized";
        }

        // Parameterless constructor for serialization if needed
        public Transaction()
        {
            Description = string.Empty;
            Category = "Uncategorized";
            Date = DateTime.Now;
        }

    }
}
