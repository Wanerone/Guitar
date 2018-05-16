using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Guitar.Models;
using Guitar.ViewModel;

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
        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicScore ms = db.MusicScore.Find(id);
            MusicScoreStatistics msta = db.MusicScoreStatistics.Find(id);
            var usid = (from m in db.MusicScore.Where(p => p.Ms_id == id) select m.User_id).FirstOrDefault();
            Users us = db.Users.Find(usid);
            //MusicScoreStatistics msta = db.MusicScoreStatistics.Find(id);

            if (ms == null&&msta==null&&us==null)
            {
                return HttpNotFound();
            }
          
            //var us=from m in db.Users.Where(p=>p.User_id==usid) select m;
            var ms1 = (from m in db.MusicScore.Where(p => p.User_id == usid).OrderByDescending(p => p.Ms_addtime) select m).Take(5);
            var msc = from m in db.MusicScoreComment.Where(p => p.Ms_id == id).OrderByDescending(p => p.Addtime) select m;
            var msr =( from n in db.MusicScoreReply
                      join m in msc on n.Ms_commentid equals m.Ms_commentid
                      join q in db.Users on n.User_id equals q.User_id
                      select new MusicCommentReplyViewModel
                      {
                          Ms_replyid = n.Ms_replyid,
                          Ms_commentid = m.Ms_commentid,
                          content = n.content,
                          Addtime = n.Addtime,
                          Ms_id = m.Ms_id,
                          User_id=n.User_id,
                          User_name=q.User_name,
                          User_img=q.User_img
                      });
            int commentid = Convert.ToInt32(Request["Commentid1"]);
            var msrr= from m in db.MusicScoreReply.Where(p=>p.Ms_commentid==commentid).OrderByDescending(p => p.Addtime) select m;
            //var msta = from m in db.MusicScoreStatistics.Where(p => p.Ms_id == id) select m;
            //var msta = from m in db.MusicScoreStatistics where m.Ms_id == id select m;
            var index = new Guitar.ViewModel.MusicDetailsViewModel()
            {
                Us=us,
                MScore = ms,
                MScore1 = ms1,
                MSStatistics = msta,
                MSC=msc,
                MSR=msr,
                Msr=msrr,
            };
            return View(index);
        }
        [HttpPost]
        public ActionResult Comment(MusicScoreComment msc,MusicScoreStatistics mss)
        {
            string pingluntextarea = Request["pingluntextarea"];
            int Ms_id = Convert.ToInt32(Request["Ms_id"]);
            if (ModelState.IsValid)
            {
                msc.Ms_id = Ms_id;
                msc.content = pingluntextarea;
                msc.User_id = Convert.ToInt32(Session["Users_id"].ToString());
                msc.Addtime = System.DateTime.Now;
                db.MusicScoreComment.Add(msc);
                db.SaveChanges();
                return Content("<script>;alert('评论成功!');history.go(-1)</script>");
            }
            
            return RedirectToAction("Display", "MusicScore");
        }
        [HttpPost]
        public ActionResult Reply(MusicScoreReply msr)
        {
            string pingluntextarea = Request["pingluntextarea2"];
            int Ms_id = Convert.ToInt32(Request["Ms_id2"]);
            int commentid= Convert.ToInt32(Request["Commentid"]);
            int commentid1 = Convert.ToInt32(Request["Commentid1"]);
            int commentid2 = Convert.ToInt32(Request["Commentid2"]);
            if (ModelState.IsValid)
            {
                msr.Ms_id = Ms_id;
                msr.content = pingluntextarea;
                msr.Ms_commentid = commentid;
                msr.User_id = Convert.ToInt32(Session["Users_id"].ToString());
                msr.Addtime = System.DateTime.Now;                
                db.MusicScoreReply.Add(msr);
                db.SaveChanges();               
                return Content("<script>;alert('回复成功!');history.go(-1)</script>");
            }

                return RedirectToAction("Display", "MusicScore");
        }
        [HttpPost]
        public ActionResult Collection(MusicScoreCollection msc)
        {
            int Ms_id = Convert.ToInt32(Request["Ms_id3"]);
            int User_id = Convert.ToInt32(Session["User_id"]);
            if (ModelState.IsValid)
            {
                msc.Ms_id = Ms_id;
                msc.User_id = User_id;
                msc.State = 1;
                db.MusicScoreCollection.Add(msc);
                db.SaveChanges();
                return Content("<script>;alert('收藏成功!');history.go(-1)</script>");
            }

            return RedirectToAction("Display", "MusicScore");
        }
        public ActionResult UserIndex(int User_Id)
        {
            Users users = db.Users.Find(User_Id);
            var index = new Guitar.ViewModel.UsersViewModel
            {
                Us=users,

            };

            return View(index);
        }

        }
    }
