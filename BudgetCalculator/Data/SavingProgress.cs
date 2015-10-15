using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Data
{
    public class SavingProgress
    {
        public string Name { get; set; }
        public decimal Target { get; set; }
        public decimal Saved { get; set; }
        public decimal Left { get; set; }
    }
}