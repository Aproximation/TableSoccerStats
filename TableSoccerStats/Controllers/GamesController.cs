using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TableSoccerStats.Database.EntityModel;
using TableSoccerStats.Models;

namespace TableSoccerStats.Controllers
{
    public class GamesController : Controller
    {
        private TssDbContext db = new TssDbContext();

        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DatePlayed,Team12Points,Team34Points, Player1A, Player1B, Player2A, Player2B")] NewGameInfo newGameInfo)
        {
            //ValidatePlayers();
            //ModelState.AddModelError("DatePlayed", "Date is mandatory");
            var game = new Game();
            if (ModelState.IsValid)
            {
                game.DatePlayed = newGameInfo.DatePlayed;
                game.Player1A = db.Players.Find(newGameInfo.Player1A);
                game.Player1B = db.Players.Find(newGameInfo.Player1B);
                game.Player2A = db.Players.Find(newGameInfo.Player2A);
                game.Player2B = db.Players.Find(newGameInfo.Player2B);
                game.Team12Points = newGameInfo.Team12Points;
                game.Team34Points = newGameInfo.Team34Points;
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newGameInfo);
        }

        //// GET: Games/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Game game = db.Games.Find(id);
        //    if (game == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(game);
        //}

        //// POST: Games/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "GameId,DatePlayed,Team12Points,Team34Points")] Game game)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(game).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(game);
        //}

        //// GET: Games/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Game game = db.Games.Find(id);
        //    if (game == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(game);
        //}

        //// POST: Games/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Game game = db.Games.Find(id);
        //    db.Games.Remove(game);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
