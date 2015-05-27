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
    public class CommentModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private int currentForumId;
        // GET: CommentModels
        public ActionResult Index(int id)
        {
            currentForumId = id;
            ViewBag.Title = db.ForumModels.Find(id).Title;
            ViewBag.Question = db.ForumModels.Find(id).Question;
            ViewBag.Sender = db.Users.Find(db.ForumModels.Find(id).ApplicationUserId).UserName;
            ViewBag.ThreadId = id;
            ViewBag.AppUserId = User.Identity.GetUserId();
            var commentModels = db.CommentModels.Where(c => c.ForumModelId == id);
            return View(commentModels.ToList());
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(string message, string threadId)
        {
            var commentModel = new CommentModel();
            commentModel.ForumModelId = Int32.Parse(threadId);
            commentModel.Id = db.CommentModels.Count() + 1;
            commentModel.ApplicationUserId = User.Identity.GetUserId();
            commentModel.message = message;
            
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                db.CommentModels.Add(commentModel);
                db.SaveChanges();

                var ComModel = db.CommentModels.Where(c => c.ForumModelId.ToString() == threadId);
                return Index(Int32.Parse(threadId));
            }
            var commentModels = db.CommentModels.Where(c => c.ForumModelId == commentModel.ForumModelId);
            return View(commentModels.ToList());
        }
        

        // GET: CommentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentModel commentModel = db.CommentModels.Find(id);
            if (commentModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", commentModel.ApplicationUserId);
            return View(commentModel);
        }

        // POST: CommentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentModel commentModel)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                db.Entry(commentModel).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index", new { id = commentModel.ForumModelId});
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Pin", commentModel.ApplicationUserId);
            return View(commentModel);
        }

        // GET: CommentModels/Delete/5
        public ActionResult Delete(int id,string threadId)
        { 
            CommentModel commentModel = db.CommentModels.Find(id);
            try
            {
                db.CommentModels.Remove(commentModel);
                db.SaveChanges();
               return RedirectToAction("Index", new { id = Int32.Parse(threadId)});
            }
            catch
            {
            }
            return View();
        }

        // POST: CommentModels/Delete/5
       
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
