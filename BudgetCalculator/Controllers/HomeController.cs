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

            return View();
        }
        
    }
}
