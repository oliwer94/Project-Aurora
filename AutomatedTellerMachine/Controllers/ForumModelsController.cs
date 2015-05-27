using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;

namespace AutomatedTellerMachine.Controllers
{
    public class ForumModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ForumModels
        public ActionResult Index()
        {
            var forumModels = db.ForumModels.Include(f => f.User);
            ViewBag.AppUserId = User.Identity.GetUserId();
            return View(forumModels.ToList());
        }

        [Authorize]
        // GET: ForumModels/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = User.Identity.GetUserId();
            return View();
        }


        [Authorize]
        // POST: ForumModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserId,Title,Question")] ForumModel forumModel)
        {
            ModelState.Clear();
            forumModel.ApplicationUserId = User.Identity.GetUserId();
            forumModel.Id = db.ForumModels.Count() + 1;
            forumModel.User =
                db.CheckingAccounts.Where(x => x.ApplicationUserId == forumModel.ApplicationUserId).First().User;
            
            if (ModelState.IsValid)
            {
                db.ForumModels.Add(forumModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", forumModel.ApplicationUserId);
            return View(forumModel);
        }


        [Authorize]
        // GET: ForumModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            ForumModel forumModel = db.ForumModels.Find(id);
            if (forumModel == null)
            {
                return HttpNotFound();
            }
            return View(forumModel);
        }


        [Authorize]
        // POST: ForumModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserId,Title,Question")] ForumModel forumModel)
        {
            ModelState.Clear();
            forumModel.ApplicationUserId = User.Identity.GetUserId();
           
            if (ModelState.IsValid)
            {
                db.Entry(forumModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", forumModel.ApplicationUserId);
            return View(forumModel);
        }


        [Authorize]
        // GET: ForumModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumModel forumModel = db.ForumModels.Find(id);
            if (forumModel == null)
            {
                return HttpNotFound();
            }
            return View(forumModel);
        }

        [Authorize]
        // POST: ForumModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             ForumModel forumModel = db.ForumModels.Find(id);

             foreach (var item in db.CommentModels)
             {
                 CommentModel cm = db.CommentModels.Find(item.Id);

                if (cm.ForumModelId == forumModel.Id)
                {
                    db.CommentModels.Remove(cm);
                }
            }

            db.ForumModels.Remove(forumModel);
            db.SaveChanges();
            
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
