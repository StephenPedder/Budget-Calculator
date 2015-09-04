using BudgetCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetCalculator.Controllers
{
    public class EntryController : Controller
    {
        private IBudgetCalculatorRepository _repo;
        public EntryController(IBudgetCalculatorRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var entries = _repo.GetEntries()
                .OrderByDescending(entry => entry.Date)
                .ToList();

            return View(entries);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Entry newEntry)
        {
            if (_repo.AddEntry(newEntry) && _repo.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new NotImplementedException();
            }
        }



        //public bool Insert(Entry newEntry)
        //{
        //    try
        //    {
        //        if (_repo.AddEntry(newEntry) && _repo.Save())
        //        { 
        //            return true; 
        //        }
        //        else 
        //        { 
        //            return false; 
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //TODO log error
        //        return false;  
        //    }
        //}

        //public HttpResponseMessage Post(int entryId, [FromBody]Entry newEntry)
        //{
        //    if (_repo.AddEntry(newEntry) && _repo.Save())
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Created, newEntry);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}

    }
}
