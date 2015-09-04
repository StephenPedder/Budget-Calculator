using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Data
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}