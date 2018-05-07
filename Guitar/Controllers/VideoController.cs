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
    public class VideoController : Controller
    {
        private GuitarEntities db = new GuitarEntities();

        // GET: Video
        public ActionResult Index()
        {
            var video = db.Video.Include(v => v.Users);
            return View(video.ToList());
        }

        // GET: Video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Video/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Video/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Video video)
        {
            var sel = Request["sel"];
            HttpPostedFileBase postimageBase = Request.Files["Image1"];
            HttpPostedFileBase postvideoBase = Request.Files["VideoFile"];
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
                            video.Vi_img = relativepath;
                        }

                        else
                        {
                            return Content("<script>;alert('请先上传封面！');history.go(-1)</script>");

                        }
                        if (postvideoBase != null)
                        {
                            string filePath = postvideoBase.FileName;
                            string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                            string serverpath = Server.MapPath(@"/Video/") + fileName;
                            string relativepath = @"/Video/" + fileName;
                            postvideoBase.SaveAs(serverpath);
                            video.Vi_url = relativepath;
                        }

                        else
                        {
                            return Content("<script>;alert('视频没有上传！');history.go(-1)</script>");

                        }
                        video.User_id = 1; /*Convert.ToInt32(Session["Users_id"].ToString());*/
                        //publish_food.Amount = 0;
                        video.Vi_addtime = System.DateTime.Now;
                        video.Vi_label = sel;
                        db.Video.Add(video);
                        db.SaveChanges();
                        //return Content("<script>;alert('分享成功!');window.location.href='/Publish_Food/Index_PF'</script>");
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

            }
            return View();
            //if (ModelState.IsValid)
            //{
            //    db.Video.Add(video);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.User_id = new SelectList(db.Users, "User_id", "User_name", video.User_id);
            //return View(video);
        }

        // GET: Video/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.Users, "User_id", "User_name", video.User_id);
            return View(video);
        }

        // POST: Video/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vi_id,User_id,Vi_url,Vi_title,Vi_description,Vi_img,Vi_addtime")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.Users, "User_id", "User_name", video.User_id);
            return View(video);
        }

        // GET: Video/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Video.Find(id);
            db.Video.Remove(video);
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
