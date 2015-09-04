using BudgetCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetCalculator.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetCalculatorRepository _repo;
        public BudgetController(IBudgetCalculatorRepository repo)
        {
            _repo = repo;
        }


        public ActionResult Index()
        {
            var budgets = _repo.GetBudgets()
                .OrderBy(entry => entry.Name)
                .ToList();

            return View(budgets);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Budget newBudget)
        {
            if (_repo.AddBudget(newBudget) && _repo.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        

        //public HttpResponseMessage Post(int budgetId, [FromBody]Budget newBudget)
        //{
        //    if (_repo.AddBudget(newBudget) && _repo.Save())
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Created, newBudget);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}

    }
}
