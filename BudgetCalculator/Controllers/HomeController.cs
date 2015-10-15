using BudgetCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetCalculator.Controllers
{
    public class HomeController : Controller
    {
        private IBudgetCalculatorRepository _repo;
        public HomeController(IBudgetCalculatorRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var entries = _repo.GetEntries()
                .OrderByDescending(entry => entry.Date)
                .ToList();

            var budgets = _repo.GetBudgets()
                .ToList();

            var savings = _repo.GetSavings()
                .ToList();

            @ViewBag.CurrentBalance = GetCurrentBalance();

            return View();
        }


        public ActionResult BudgetProgress()
        {
            var budgetProgress = GetBudgetProgress();
            return PartialView("_BudgetProgress", budgetProgress);
        }


        public ActionResult SavingProgress()
        {
            var savingProgress = GetSavingProgress();
            return PartialView("_SavingProgress", savingProgress);
        }

        public decimal GetCurrentBalance()
        {
            var entries = _repo.GetEntries();

            var incomingData = from e in entries
                           where e.BudgetCategory == "Starting"
                           select new { Name = e.BudgetCategory, Amount = e.Amount };

            var outgoingData = from e in entries
                           where e.BudgetCategory != "Starting"
                           select new { Name = e.BudgetCategory, Amount = e.Amount };

            var incoming = incomingData.Sum(i => i.Amount);
            var outgoing = outgoingData.Sum(i => i.Amount);

            return incoming - outgoing;
        }


        public List<BudgetCalculator.Data.BudgetProgess> GetBudgetProgress()
        {
            var entries = _repo.GetEntries()
                .ToList();

            var budgets = _repo.GetBudgets()
                .ToList();

            var filtered = from e in entries
                            join b in budgets
                            on e.BudgetCategory equals b.Name
                            group e by new { b.Name, e.BudgetCategory, b.Amount } into g
                            orderby g.Key.Name
                            select new { Budget = g.Key.BudgetCategory, Target = g.Key.Amount, Amount = g.Sum(e => e.Amount),  Actual = g.Key.Amount - g.Sum(e => e.Amount) };

            var data = filtered.ToList();

            List<BudgetProgess> budgetProgress = new List<BudgetProgess>();

            foreach (var item in data)
            {
                BudgetProgess bp = new BudgetProgess();
                bp.Name = item.Budget;
                bp.Target = item.Target;
                bp.Spent = item.Amount;
                bp.Left = item.Actual;
                budgetProgress.Add(bp);
            }
            
            return budgetProgress;
        }


        public List<BudgetCalculator.Data.SavingProgress> GetSavingProgress()
        {
            var entries = _repo.GetEntries()
                .ToList();

            var savings = _repo.GetSavings()
                .ToList();


            var filtered = from s in savings
                           join e in entries
                           on s.Name equals e.BudgetCategory into g
                           orderby s.Name
                           select new { Saving = s.Name, Target = s.Amount, Amount = g.Sum(e => e.Amount), Actual = s.Amount - g.Sum(e => e.Amount) };

            var data = filtered.ToList();

            List<SavingProgress> savingProgress = new List<SavingProgress>();

            foreach (var item in data)
            {
                SavingProgress sp = new SavingProgress();
                sp.Name = item.Saving;
                sp.Target = item.Target;
                sp.Saved = item.Amount;
                sp.Left = item.Actual;
                savingProgress.Add(sp);
            }

            return savingProgress;
        }


    }
}
