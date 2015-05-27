using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;


namespace AutomatedTellerMachine.Controllers
{

    public class GameInfoesController : Controller
    {
        //private GameInfoDbContext db = new GameInfoDbContext();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameInfoes
        public ActionResult Index()
        {
            return View(db.GamesInfos.ToList());
        }

        public ActionResult GameCatalogTemp()
        {
            return View(db.GamesInfos.ToList());
        }

        // GET: GameInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameInfo gameInfo = db.GamesInfos.Find(id);
            if (gameInfo == null)
            {
                return HttpNotFound();
            }
            return View(gameInfo);
        }

        [Authorize(Roles = "Admin")]
        // GET: GameInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Developer,Publisher,Platforms,ReleaseDate,Genre,MetaCriticScore,Description,InPageImage,Thumbnail,Thumbnail2,Thumbnail3,Thumbnail4,VideoUrl,VideoUrl2,ReviewLinks,ReviewLinks2,ReviewLinks3,ReviewLinks4")] GameInfo gameInfo)
        {
            if (ModelState.IsValid)
            {
                db.GamesInfos.Add(gameInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameInfo);
        }
        [Authorize(Roles = "Admin")]
        // GET: GameInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameInfo gameInfo = db.GamesInfos.Find(id);
            if (gameInfo == null)
            {
                return HttpNotFound();
            }
            return View(gameInfo);
        }

        // POST: GameInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Developer,Publisher,Platforms,ReleaseDate,Genre,MetaCriticScore,Description,InPageImage,Thumbnail,Thumbnail2,Thumbnail3,Thumbnail4,VideoUrl,VideoUrl2,ReviewLinks,ReviewLinks2,ReviewLinks3,ReviewLinks4")] GameInfo gameInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameInfo);
        }
        [Authorize(Roles = "Admin")]
        // GET: GameInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameInfo gameInfo = db.GamesInfos.Find(id);
            if (gameInfo == null)
            {
                return HttpNotFound();
            }
            return View(gameInfo);
        }
        [Authorize(Roles = "Admin")]
        // POST: GameInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameInfo gameInfo = db.GamesInfos.Find(id);
            db.GamesInfos.Remove(gameInfo);
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
