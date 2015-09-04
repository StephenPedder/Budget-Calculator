using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Data
{
    public class BudgetCalculatorContext : DbContext
    {

        public BudgetCalculatorContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BudgetCalculatorContext, BudgetCalculatorMigrationsConfiguration>());
        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<Entry> Entries { get; set; }

    }
}