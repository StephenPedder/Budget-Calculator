using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace BudgetCalculator.Data
{
    public class BudgetCalculatorMigrationsConfiguration : DbMigrationsConfiguration<BudgetCalculatorContext>
    {
        public BudgetCalculatorMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BudgetCalculatorContext context)
        {
            base.Seed(context);

#if DEBUG
            if(context.Budgets.Count() == 0)
            {
                var budget = new Budget()
                {
                    Name = "Test Budget",
                    Amount = 10.00m
                };

                context.Budgets.Add(budget);
            }

            if (context.Savings.Count() == 0)
            {
                var saving = new Saving()
                {
                    Name = "Test Saving",
                    Amount = 50.00m
                };
                context.Savings.Add(saving);
            }

            if (context.Entries.Count() == 0)
            {
                var entry = new Entry()
                {
                    Date = DateTime.Now,
                    Description = "Test Entry",
                    BudgetCategory = "Test Budget",
                    Amount = 5.00m
                };
                context.Entries.Add(entry);
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
#endif
        }

    }
}
