using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Guitar.Models;

namespace Guitar.Controllers
{
    public class MusicScoresController : Controller
    {
        private GuitarEntities db = new GuitarEntities();

        // GET: MusicScores
        public ActionResult Index()
        {
            var musicScore = db.MusicScore.Include(m => m.Users);
            return View(musicScore.ToList());
        }

        // GET: MusicScores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicScore musicScore = db.MusicScore.Find(id);
            if (musicScore == null)
            {
                return HttpNotFound();
            }
            return View(musicScore);
        }

        // GET: MusicScores/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.Users, "User_id", "User_name");
            return View();
        }

        // POST: MusicScores/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ms_id,User_id,Ms_title,Score,Ms_img,Ms_label,Ms_description,Ms_addtime")] MusicScore musicScore)
        {
            if (ModelState.IsValid)
            {
                db.MusicScore.Add(musicScore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_id = new SelectList(db.Users, "User_id", "User_name", musicScore.User_id);
            return View(musicScore);
        }

        // GET: MusicScores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicScore musicScore = db.MusicScore.Find(id);
            if (musicScore == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.Users, "User_id", "User_name", musicScore.User_id);
            return View(musicScore);
        }

        // POST: MusicScores/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ms_id,User_id,Ms_title,Score,Ms_img,Ms_label,Ms_description,Ms_addtime")] MusicScore musicScore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicScore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.Users, "User_id", "User_name", musicScore.User_id);
            return View(musicScore);
        }

        // GET: MusicScores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicScore musicScore = db.MusicScore.Find(id);
            if (musicScore == null)
            {
                return HttpNotFound();
            }
            return View(musicScore);
        }

        // POST: MusicScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicScore musicScore = db.MusicScore.Find(id);
            db.MusicScore.Remove(musicScore);
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
