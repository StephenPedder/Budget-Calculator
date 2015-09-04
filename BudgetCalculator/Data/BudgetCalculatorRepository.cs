using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Data
{
    public class BudgetCalculatorRepository : IBudgetCalculatorRepository
    {
        private BudgetCalculatorContext _ctx;
        public BudgetCalculatorRepository(BudgetCalculatorContext ctx)
        {
            _ctx = ctx;
        }


        IQueryable<Budget> IBudgetCalculatorRepository.GetBudgets()
        {
            return _ctx.Budgets;
        }


        public IQueryable<Saving> GetSavings()
        {
            return _ctx.Savings;
        }


        public IQueryable<Entry> GetEntries()
        {
            return _ctx.Entries;
        }


        public bool AddEntry(Entry newEntry)
        {
            try
            {
                newEntry.Date = DateTime.UtcNow;
                _ctx.Entries.Add(newEntry);
                return true;
            }
            catch (Exception)
            {
                //TODO log this error
                return false;
            }
        }


        public bool AddSaving(Saving newSaving)
        {
            try
            {
                _ctx.Savings.Add(newSaving);
                return true;
            }
            catch (Exception)
            {
                //TODO log this error
                return false;
            }
        }


        public bool AddBudget(Budget newBudget)
        {
            try
            {
                _ctx.Budgets.Add(newBudget);
                return true;
            }
            catch (Exception)
            {
                //TODO log this error
                return false;
            }
        }


        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {
                //TODO log this error
                return false;
            }
        }

    }
}