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
    public class MusicScoreController : Controller
    {
        private GuitarEntities db = new GuitarEntities();

        // GET: MusicScore
        public ActionResult Index()
        {
            var musicScore = db.MusicScore.Include(m => m.Users);
            return View(musicScore.ToList());
        }

        // GET: MusicScore/Details/5
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
            return View();
        }

        // POST: MusicScores/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(MusicScore musicScore)
        {
            var sel = Request["sel"];
            HttpPostedFileBase postimageBase = Request.Files["Image1"];
            //HttpFileCollectionBase files = Request.Files;
            //HttpPostedFileBase postimageBase = files["Image1"];//获取上传的文件
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (postimageBase != null)
                        {
                            string filePath = postimageBase.FileName;
                            string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                            string serverpath = Server.MapPath(@"/Images/FM/") + filename;
                            string relativepath = @"/Images/FM/" + filename;
                            postimageBase.SaveAs(serverpath);
                            musicScore.Ms_img = relativepath;
                        }

                        else
                        {
                            return Content("<script>;alert('请先上传封面！');history.go(-1)</script>");

                        }
                        musicScore.User_id = 1;/*Convert.ToInt32(Session["Users_id"].ToString());*/
                        //publish_food.Amount = 0;
                        musicScore.Ms_addtime = System.DateTime.Now;
                        musicScore.Ms_label = sel;
                        db.MusicScore.Add(musicScore);
                        db.SaveChanges();
                        //return Content("<script>;alert('发布成功!');window.location.href='/Publish_Food/Index_PF'</script>");
                        return Content("<script>;alert('发布成功!');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>;alert('发布失败！');history.go(-1)</script>");
                    }
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
                //var score = musicScore["Score"];
                //db.MusicScore.Add(musicScore);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View();
        }

        // GET: MusicScore/Edit/5
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

        // POST: MusicScore/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ms_id,User_id,Ms_title,Score,Ms_img,Ms_label,Ms_addtime")] MusicScore musicScore)
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

        // GET: MusicScore/Delete/5
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

        // POST: MusicScore/Delete/5
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
        public ActionResult Display()
        {
            return View();
        }
    }
}
