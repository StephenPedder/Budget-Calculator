using BudgetCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BudgetCalculator.Controllers
{
    public class SavingController : Controller
    {
        private IBudgetCalculatorRepository _repo;
        public SavingController(IBudgetCalculatorRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var savings = _repo.GetSavings()
                .OrderBy(entry => entry.Name)
                .ToList();

            return View(savings);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Saving newSaving)
        {
            if (_repo.AddSaving(newSaving) && _repo.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        //public HttpResponseMessage Post(int savingId, [FromBody]Saving newSaving)
        //{
        //    if (_repo.AddSaving(newSaving) && _repo.Save())
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Created, newSaving);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}

    }
}
