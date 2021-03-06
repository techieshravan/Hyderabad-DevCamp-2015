﻿

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    public class QuestionController : Controller
    {
        private TriviaContext db = new TriviaContext();

        // GET: /Question/
        public async Task<ActionResult> Index()
        {
            return View(await db.TriviaQuestions.ToListAsync());
        }

        // GET: /Question/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaQuestion triviaquestion = await db.TriviaQuestions.FindAsync(id);
            if (triviaquestion == null)
            {
                return HttpNotFound();
            }
            return View(triviaquestion);
        }

        // GET: /Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Title")] TriviaQuestion triviaquestion)
        {
            if (ModelState.IsValid)
            {
                db.TriviaQuestions.Add(triviaquestion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(triviaquestion);
        }

        // GET: /Question/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaQuestion triviaquestion = await db.TriviaQuestions.FindAsync(id);
            if (triviaquestion == null)
            {
                return HttpNotFound();
            }
            return View(triviaquestion);
        }

        // POST: /Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Title")] TriviaQuestion triviaquestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triviaquestion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(triviaquestion);
        }

        // GET: /Question/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaQuestion triviaquestion = await db.TriviaQuestions.FindAsync(id);
            if (triviaquestion == null)
            {
                return HttpNotFound();
            }
            return View(triviaquestion);
        }

        // POST: /Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TriviaQuestion triviaquestion = await db.TriviaQuestions.FindAsync(id);
            db.TriviaQuestions.Remove(triviaquestion);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
