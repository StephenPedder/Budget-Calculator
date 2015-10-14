using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetCalculator.Data;

namespace BudgetCalculator.Controllers
{
    public class SavingController : Controller
    {
        private BudgetCalculatorContext db = new BudgetCalculatorContext();

        //
        // GET: /Saving/

        public ActionResult Index()
        {
            return View(db.Savings.ToList());
        }


        //
        // GET: /Saving/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Saving/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Saving saving)
        {
            if (ModelState.IsValid)
            {
                db.Savings.Add(saving);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saving);
        }

        //
        // GET: /Saving/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Saving saving = db.Savings.Find(id);
            if (saving == null)
            {
                return HttpNotFound();
            }
            return View(saving);
        }

        //
        // POST: /Saving/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Saving saving)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saving).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saving);
        }

        //
        // GET: /Saving/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Saving saving = db.Savings.Find(id);
            if (saving == null)
            {
                return HttpNotFound();
            }
            return View(saving);
        }

        //
        // POST: /Saving/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saving saving = db.Savings.Find(id);
            db.Savings.Remove(saving);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}