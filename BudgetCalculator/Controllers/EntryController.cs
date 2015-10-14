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
    public class EntryController : Controller
    {
        private BudgetCalculatorContext db = new BudgetCalculatorContext();

        //
        // GET: /Entry/

        public ActionResult Index()
        {
            return View(db.Entries.ToList().OrderByDescending(e => e.Date));
        }

 

        //
        // GET: /Entry/Create

        public ActionResult Create()
        {
            Entry entry = new Entry();
            entry.Date = DateTime.Now;
            return View(entry);
        }

        //
        // POST: /Entry/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entries.Add(entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        //
        // GET: /Entry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        //
        // POST: /Entry/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        //
        // GET: /Entry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Entry entry = db.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        //
        // POST: /Entry/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entry entry = db.Entries.Find(id);
            db.Entries.Remove(entry);
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