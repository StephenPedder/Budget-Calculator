using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetCalculator.Data
{
    public interface IBudgetCalculatorRepository
    {
        IQueryable<Entry> GetEntries();
        IQueryable<Saving> GetSavings();
        IQueryable<Budget> GetBudgets();
        
        bool AddEntry(Entry newEntry);
        bool AddSaving(Saving newSaving);
        bool AddBudget(Budget newBudget);

        bool RemoveEntry(Entry entry);
        bool RemoveSaving(Saving saving);
        bool RemoveBudget(Budget budget);

        bool Save();
    }
}
