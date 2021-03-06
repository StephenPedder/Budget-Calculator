﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetCalculator.Data;

namespace BudgetCalculator.Controllers
{
    public class BudgetController : Controller
    {
        private BudgetCalculatorContext db = new BudgetCalculatorContext();

        //
        // GET: /Budget/

        public ActionResult Index()
        {
            return View(db.Budgets.ToList());
        }

        //
        // GET: /Budget/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Budget/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Budgets.Add(budget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budget);
        }

        //
        // GET: /Budget/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        //
        // POST: /Budget/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budget);
        }

        //
        // GET: /Budget/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        //
        // POST: /Budget/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budget budget = db.Budgets.Find(id);
            db.Budgets.Remove(budget);
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